using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    public Sprite onBtn;
    public Sprite offBtn;

    public GameObject FlatsFurniture;
    public GameObject LightSources;
    public GameObject Walls;
    public GameObject Wallpapers;
    public GameObject FlatSizes;

    private bool flag=false;

    private void Start ()
    {
        FlatsFurniture = GameObject.Find("FlatsFurniture");
        LightSources = GameObject.Find("LightSources");
        Walls = GameObject.Find("Walls");
        Wallpapers = GameObject.Find("Wallpapers");
        FlatSizes = GameObject.Find("FlatSizes");
    }

    public void _ChangeFlatSizesVisiblity ()//���/���� ����������� ��������
    {
        FlatSizes.SetActive(!FlatSizes.activeSelf);
        changeImageInBtn();
    }
    public void _ChangeFurnituresVisiblity ()//���/���� ����������� ������
    {
        FlatsFurniture.SetActive(!FlatsFurniture.activeSelf);
        changeImageInBtn();
    }

    public void _ChangeWallsVisiblity ()//���/���� ����������� ����
    {
        Walls.SetActive(!Walls.activeSelf);
        changeImageInBtn();
    }

    public void _ChangeWallpapersVisiblity ()//���/���� ����������� �����
    {
        Wallpapers.SetActive(!Wallpapers.activeSelf);
        changeImageInBtn();
    }

    public void _ChangeLightsSourseVisiblity ()//���/���� ����������� ����, �� �� ���������
    {
        foreach(MeshRenderer l in LightSources.GetComponentsInChildren<MeshRenderer>())
        {
            if(GameObject.Find("ButtonLight").GetComponent<Image>().sprite == onBtn)
                l.enabled = flag;
            if(GameObject.Find("ButtonLight").GetComponent<Image>().sprite == offBtn && l.GetComponent<Light>()==null)
                l.enabled = flag;
        }
        flag=!flag;
        changeImageInBtn();
    }
    
    public void _TurnOnOrOffFlatLights ()//���/���� ���������
    {
        foreach(Light l in LightSources.GetComponentsInChildren<Light>())
        {
            if(GameObject.Find("ButtonMeshLight").GetComponent<Image>().sprite==onBtn)
                l.gameObject.GetComponent<MeshRenderer>().enabled= !l.enabled;
            l.enabled = !l.enabled;
        }
        changeImageInBtn();
    }

    private void changeImageInBtn ()//��� �������� 
    {
        if(GetComponent<Image>().sprite == offBtn)
            GetComponent<Image>().sprite = onBtn;
        else
            GetComponent<Image>().sprite = offBtn;
    }
}
