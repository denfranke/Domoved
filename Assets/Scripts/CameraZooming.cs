using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZooming : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("�������� ��������������� ������ ������")]
    public float _speed;
    [Tooltip("��������� ������������ ������ ��������������� ������")]
    public float _radiusMax;
    [Tooltip("��������� ����������� ������ ��������������� ������")]
    public float _radiusMin;
    [Tooltip("����� �� ������� ��������� ��������� ������ ����������� ������ (���� ��� �� ������ � ����������, �� �� ��������� �� ������������ ��� ���������, �� ������� ��������� ��������)")]
    public Transform _target;

    private Touch _touchStart;
    private Touch _touchEnd;
    private Vector3 _targetPos;

    private void Start ()
    {
        if(_target == null)
        {
            _target = transform;
        }

        _targetPos = _target.position;
    }

    void Update ()
    {
        if(Input.touchCount == 2 && GetComponent<CameraMovement>().GetInteractive())//����������� ������ ����� ��������
        {
            _touchStart = Input.GetTouch(0);
            _touchEnd = Input.GetTouch(1);

            Vector2 touchStartDeltaPos = _touchStart.position - _touchStart.deltaPosition;
            Vector2 touchEndDeltaPos = _touchEnd.position - _touchEnd.deltaPosition;

            float distDeltaTouches = (touchStartDeltaPos - touchEndDeltaPos).magnitude;
            float currentDistTouchesPos = (_touchStart.position - _touchEnd.position).magnitude;

            float distance = distDeltaTouches - currentDistTouchesPos;

            Zooming(distance);
        }
    }

    private void Zooming (float value)
    {
        float height = this.transform.position.y + (value * _speed * Time.deltaTime);
        //float delta = Mathf.Abs(height - _targetPos.y);
        float delta = height - _targetPos.y;
        //Debug.Log(transform.position.y);
        if(delta <= _radiusMax && delta >= _radiusMin)
            this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
    }
}
