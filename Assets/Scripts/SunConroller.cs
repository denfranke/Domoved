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
    private Vector3 Axis = new Vector3(1, 0, 0); //��� x
    Light _light;

    void Start ()
    {
        _light = GetComponent<Light>();
    }
    void Update ()
    {
        transform.rotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Axis);  //�������� ���������� � ��������� �������
        if(transform.rotation.x > 0 && transform.rotation.x < 90) // 0 � 90 ������� � ��������� �����, ��� �� �����, ����� ����
            _light.enabled = true;
        else //����� ���� 
            _light.enabled = false;
    }
}