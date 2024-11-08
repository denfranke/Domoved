using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunConroller : MonoBehaviour
{
    /*public float DayLength;
    private float _rotationSpeed;

    void Update ()
    {
        _rotationSpeed = Time.deltaTime / DayLength;
        transform.Rotate(0, _rotationSpeed, 0);
    }*/
    public float speed;
    private Vector3 Axis = new Vector3(1, 0, 0); //ось x
    Light _light;

    void Start ()
    {
        _light = GetComponent<Light>();
    }
    void Update ()
    {
        transform.rotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Axis);  //получаем кватернион и совершаем поворот
        if(transform.rotation.x > 0 && transform.rotation.x < 90) // 0 и 90 смотрел в редакторе юнити, это те цифры, когда день
            _light.enabled = true;
        else //иначе ночь 
            _light.enabled = false;
    }
}