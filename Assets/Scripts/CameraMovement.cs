using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Settings")]
    [Tooltip("—корость передвижени€ камеры по X")]
    public float _speedX = 10;
    [Tooltip("—корость передвижени€ камеры по Z")]
    public float _speedZ = 5;
    [Tooltip("—корость поворота камеры по оси Y")]
    public float rotationSpeedY = 1;
    [Tooltip("—корость поворота камеры по оси X")]
    public float rotationSpeedX = 1;
    [Tooltip("ƒоступный радиус перемещени€ камеры")]
    public float _radius = 10;
    [Tooltip("“очка от которой считаетс€ доступный радиус перемещени€ камеры (если она не задана в инспекторе, то по умолчанию он определ€етс€ как компонент, на котором находитс€ сценарий)")]
    public Transform _target;

    public GameObject _CamObjDir;

    private Vector3 _targetPos;
    private Touch _touch;
    private Vector2 lastTouchPosition;
    private Vector3 euler;
    private bool Interactive;

    public ChangeImageInBtn changeImageInBtn;
    public DayTimeScrollbar _dayTimeScrollbar;

    private void Start ()
    {
        //changeImageInBtn = GameObject.Find("CameraManageBtnObj").GetComponent<ChangeImageInBtn>();
        // _dayTimeScrollbar = GameObject.Find("TimeScrollBar").GetComponent<DayTimeScrollbar>();
        euler = transform.localEulerAngles;

        if(_target == null)
        {
            _target = this.transform;
        }
        _targetPos = _target.position;
    }

    private void Update ()
    {
        if(Interactive)
        {
            if(changeImageInBtn.getCurrInd() == 2)//TransparentBtn
            {
                if(Input.touchCount == 1)//перемещение камеры
                {
                    _touch = Input.GetTouch(0);

                    if(_touch.phase == TouchPhase.Moved)
                    {
                        Transform camTransform = _CamObjDir.transform;

                        Vector3 ZMovement = camTransform.forward * -_touch.deltaPosition.y;
                        Vector3 XMovement = camTransform.right * -_touch.deltaPosition.x;

                        Vector3 movement = Vector3.ClampMagnitude(ZMovement + XMovement, 1);

                        if(Mathf.Pow(transform.position.x + movement.x, 2) + Mathf.Pow(transform.position.z + movement.z, 2) <= _radius * _radius)
                            transform.Translate(new Vector3(movement.x * _speedX, 0, movement.z * _speedZ) * Time.deltaTime, Space.World);
                    }
                }
            }
            else if(changeImageInBtn.getCurrInd() == 1)//RotateBtn
            {
                if(Input.touchCount == 1)//поворот камеры
                {
                    Touch touch = Input.GetTouch(0);

                    if(touch.phase == TouchPhase.Began)
                    {
                        lastTouchPosition = touch.position;
                    }
                    else if(touch.phase == TouchPhase.Moved)
                    {
                        Vector2 deltaPosition = touch.position - lastTouchPosition;

                        euler.y += deltaPosition.x * rotationSpeedY * Time.deltaTime;
                        transform.localEulerAngles = euler;

                        _CamObjDir.transform.eulerAngles = new Vector3(0, euler.y, 0);

                        lastTouchPosition = touch.position;
                    }
                }
            }
            else if(changeImageInBtn.getCurrInd() == 0)//InclineBtn
            {
                if(Input.touchCount == 1)//наклон камеры
                {
                    Touch touch = Input.GetTouch(0);
                    if(touch.phase == TouchPhase.Began)
                    {
                        lastTouchPosition = touch.position;
                    }
                    else if(touch.phase == TouchPhase.Moved)
                    {
                        Vector2 deltaPosition = touch.position - lastTouchPosition;

                        //transform.Rotate(Vector3.left, deltaPosition.y * rotationSpeed);
                        euler.x += deltaPosition.y * rotationSpeedX * Time.deltaTime;
                        euler.x = Mathf.Clamp(euler.x, 20.0f, 90.0f);
                        transform.localEulerAngles = euler;


                        lastTouchPosition = touch.position;
                    }
                }
            }
        }
    }

    public void SetInteractive (bool f)
    {
        Interactive = f;
    }

    public bool GetInteractive ()
    {
        return Interactive;
    }
}