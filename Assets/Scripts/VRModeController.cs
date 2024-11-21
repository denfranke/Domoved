using System.Collections;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.XR;
using UnityEngine.XR.Management;

using InputSystemTouchPhase = UnityEngine.InputSystem.TouchPhase;

public class VRModeController : MonoBehaviour
{
    private const float _defaultFieldOfView = 60.0f;

    //[SerializeField]private Camera _mainCamera;
    [SerializeField] private ChangeReality _ChangeReality;

    private bool _isScreenTouched
    {
        get
        {
            TouchControl touch = GetFirstTouchIfExists();
            return touch != null && touch.phase.ReadValue() == InputSystemTouchPhase.Began;
        }
    }

    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }

    public void Start ()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Screen.brightness = 1.0f;

        if(!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

    public void Update ()
    {
        if(_isVrModeEnabled)
        {
            if(Api.IsCloseButtonPressed)
            {
                //ExitVR();
                _ChangeReality._OpenOrCloseVR();
            }

            if(Api.IsGearButtonPressed)
            {
                Api.ScanDeviceParams();
            }
            Api.UpdateScreenParams();
        }
        //else
        //{
        //    if(_isScreenTouched)
        //    {
        //        EnterVR();
        //    }
        //}
    }

    public void _ActiveVrBtn ()
    {
        EnterVR();
    }

    private static TouchControl GetFirstTouchIfExists ()
    {
        Touchscreen touchScreen = Touchscreen.current;
        if(touchScreen == null)
        {
            return null;
        }

        if(!touchScreen.enabled)
        {
            InputSystem.EnableDevice(touchScreen);
        }

        ReadOnlyArray<TouchControl> touches = touchScreen.touches;
        if(touches.Count == 0)
        {
            return null;
        }

        return touches[0];
    }

    public void EnterVR ()
    {
        StartCoroutine(StartXR());
        if(Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    public void ExitVR ()
    {
        StopXR();
    }

    private IEnumerator StartXR ()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if(XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    private void StopXR ()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");

        //_mainCamera.ResetAspect();
        Camera.main.ResetAspect();
        //_mainCamera.fieldOfView = _defaultFieldOfView;
        Camera.main.fieldOfView = _defaultFieldOfView;
    }
}
