using Google.XR.Cardboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class ChangeReality : MonoBehaviour
{
    public GameObject NormalMode;
    public GameObject ArMode;
    public GameObject VrMode;

    public GameObject NormalModeUI;
    public GameObject ArModeUI;
    public GameObject VrModeUI;

    public void _OpenOrCloseAR ()
    {
        if(Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            ExitVR();
        }

        VrMode.SetActive(false);
        NormalMode.SetActive(!NormalMode.activeSelf);
        ArMode.SetActive(!ArMode.activeSelf);

        VrModeUI.SetActive(false);
        NormalModeUI.SetActive(!NormalModeUI.activeSelf);
        ArModeUI.SetActive(!ArModeUI.activeSelf);

        GetComponent<ObjectMovement>().enabled = NormalMode.activeSelf;
    }

    public void _OpenOrCloseVR ()
    {
        if(Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            EnterVR();
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            ExitVR();
        }

        VrMode.SetActive(!VrMode.activeSelf);
        NormalMode.SetActive(!VrMode.activeSelf);
        ArMode.SetActive(false);

        VrModeUI.SetActive(!VrModeUI.activeSelf);
        NormalModeUI.SetActive(!VrModeUI.activeSelf);
        ArModeUI.SetActive(false);

        GetComponent<ObjectMovement>().enabled = !VrMode.activeSelf;
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
    }
}
