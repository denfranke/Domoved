using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
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

    public void _ChangeFlatSizesVisiblity ()//вкл/выкл отображения размеров
    {
        FlatSizes.SetActive(!FlatSizes.activeSelf);
        _changeImageInBtn();
    }
    public void _ChangeFurnituresVisiblity ()//вкл/выкл отображения мебели
    {
        FlatsFurniture.SetActive(!FlatsFurniture.activeSelf);
        _changeImageInBtn();
    }

    public void _ChangeWallsVisiblity ()//вкл/выкл отображения стен
    {
        Walls.SetActive(!Walls.activeSelf);
        _changeImageInBtn();
    }

    public void _ChangeWallpapersVisiblity ()//вкл/выкл отображения обоев
    {
        Wallpapers.SetActive(!Wallpapers.activeSelf);
        _changeImageInBtn();
    }

    public void _ChangeLightsSourseVisiblity ()//вкл/выкл отображения ламп, но не освещения
    {
        foreach(MeshRenderer l in LightSources.GetComponentsInChildren<MeshRenderer>())
        {
            if(GameObject.Find("ButtonLight").GetComponentInChildren<SVGImage>().sprite == onBtn)
                l.enabled = flag;
            if(GameObject.Find("ButtonLight").GetComponentInChildren<SVGImage>().sprite == offBtn && l.GetComponent<Light>()==null)
                l.enabled = flag;
        }
        flag=!flag;
        _changeImageInBtn();
    }
    
    public void _TurnOnOrOffFlatLights ()//вкл/выкл освещения
    {
        foreach(Light l in LightSources.GetComponentsInChildren<Light>())
        {
            if(GameObject.Find("ButtonMeshLight").GetComponentInChildren<SVGImage>().sprite==onBtn)
                l.gameObject.GetComponentInChildren<MeshRenderer>().enabled= !l.enabled;
            l.enabled = !l.enabled;
        }
        _changeImageInBtn();
    }

    public void _changeImageInBtn ()//для настроек 
    {
        if(GetComponentInChildren<SVGImage>().sprite == offBtn)
            GetComponentInChildren<SVGImage>().sprite = onBtn;
        else
            GetComponentInChildren<SVGImage>().sprite = offBtn;
    }
}
