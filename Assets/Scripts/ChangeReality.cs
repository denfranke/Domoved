using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeReality : MonoBehaviour
{
    public GameObject NormalMode;
    public GameObject ArMode;
    public GameObject VrMode;

    public GameObject NormalModeUI;
    public GameObject ArModeUI;
    public GameObject VrModeUI;

    private void Start ()
    {
        //ArMode.SetActive(false);
        //VrMode.SetActive(false);
        //NormalMode.SetActive(true);

        //ArModeUI.SetActive(false);
        //VrModeUI.SetActive(false);
        //NormalModeUI.SetActive(true);
    }

    public void _OpenOrCloseAR ()
    {
        ArMode.SetActive(!ArMode.activeSelf);
        NormalMode.SetActive(!NormalMode.activeSelf);

        ArModeUI.SetActive(!ArModeUI.activeSelf);
        NormalModeUI.SetActive(!NormalModeUI.activeSelf);

        GetComponent<ObjectMovement>().enabled = NormalMode.activeSelf;
    }

    public void _OpenOrCloseVR ()
    {
        VrMode.SetActive(!VrMode.activeSelf);
        NormalMode.SetActive(!NormalMode.activeSelf);

        VrModeUI.SetActive(!VrModeUI.activeSelf);
        NormalModeUI.SetActive(!NormalModeUI.activeSelf);

        GetComponent<ObjectMovement>().enabled = NormalMode.activeSelf;
    }
}
