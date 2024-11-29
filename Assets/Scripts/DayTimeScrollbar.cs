using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeScrollbar : MonoBehaviour
{
    [Tooltip("Максимальная высота солнца по Y")]
    [SerializeField] private float MaxAltitude = 30.2f;
    [Tooltip("Угол восхода и заката солнца (+/-)")]
    [SerializeField] private float MaxAzimuth = 83;

    private Light _light;
    [Tooltip("Объект солнце")]
    public GameObject sun;

    //[Tooltip("Значение означающее изменяется ли сейчас значение в ScrollBar")]
    //public bool inUse = false;

    void Start ()
    {
        _light = sun.GetComponent<Light>();
    }

    //void Update () { inUse = false; }
    public void Updater ()
    {
        //inUse = true;
        if(GetComponent<Scrollbar>().value <= 0.5f)
        {
            sun.transform.rotation = Quaternion.Euler(MaxAltitude * GetComponent<Scrollbar>().value * 2,
                -83 + MaxAzimuth * GetComponent<Scrollbar>().value * 2, 0);
            _light.intensity = GetComponent<Scrollbar>().value*2;
        }
        else
        {
            sun.transform.rotation = Quaternion.Euler(MaxAltitude * (1 - GetComponent<Scrollbar>().value) * 2,
                MaxAzimuth * (GetComponent<Scrollbar>().value - 0.5f) * 2, 0);
            _light.intensity = (1-GetComponent<Scrollbar>().value)*2;
        }

        if(sun.transform.rotation.x >= 0 && sun.transform.rotation.x < 90)
            _light.enabled = true;
        else
            _light.enabled = false;
        //inUse = false;
    }
}
