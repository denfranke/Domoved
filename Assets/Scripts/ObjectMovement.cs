using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private RaycastHit hit2;
    public LayerMask layerMaskFloor;
    public LayerMask layerMaskFurniture;

    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject GHit;
    [SerializeField] private GameObject lastFurnitureObj;
    private GameObject FurnitureManageObj;
    private ChangeImageInBtn changeImageInBtn;

    public float YZoneUnInterective;
    private Vector3 pos;
    private int StartRotY;
    public TMP_Text TextYRotation;
    public Scrollbar RotateObjScrollbar;

    public float delayTimeMax;
    [SerializeField] private float timer = 0;
    [SerializeField] private bool Interactive;

    private void Start ()
    {
        //TextYRotation = GameObject.Find("TextYRotation").GetComponent<TMP_Text>();
        FurnitureManageObj = GameObject.Find("FurnitureManageObj");
        changeImageInBtn = GetComponent<ChangeImageInBtn>();
    }

    void Update ()
    {
        if(Input.touchCount == 1 && Interactive)
        {
            pos = Input.GetTouch(0).position;
            if(pos.y < YZoneUnInterective)
                pos.y = YZoneUnInterective;

            ray = Camera.main.ScreenPointToRay(pos);
            //ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if(target == null && (changeImageInBtn.getCurrInd() == 7 || changeImageInBtn.getCurrInd() < 3))
            {
                if(Physics.Raycast(ray, out hit, 100, layerMaskFurniture))
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Stationary)
                    {
                        GHit = hit.collider.gameObject;
                        if(hit.collider.tag == "Furniture")
                        {
                            if(lastFurnitureObj == GHit)
                            {
                                timer += Time.deltaTime;
                                CalculateRetention(GHit);
                            }
                            else
                                timer = 0;
                        }
                        else if(GHit.transform.parent != null)
                        {
                            if(GHit.transform.parent.gameObject.tag == "Furniture")
                            {
                                if(lastFurnitureObj == GHit)
                                {
                                    timer += Time.deltaTime;
                                    CalculateRetention(GHit.transform.parent.gameObject);
                                }
                                else
                                    timer = 0;
                            }
                            else if(GHit.transform.parent.gameObject.transform.parent != null)
                            {
                                if(GHit.transform.parent.gameObject.transform.parent.gameObject.tag == "Furniture")
                                {
                                    if(lastFurnitureObj == GHit)
                                    {
                                        timer += Time.deltaTime;
                                        CalculateRetention(GHit.transform.parent.gameObject.transform.parent.gameObject);
                                    }
                                    else
                                        timer = 0;
                                }
                                else
                                {
                                    timer = 0;
                                    target = null;
                                }
                            }
                        }
                        lastFurnitureObj = GHit;
                    }
                }
            }
            else
            {
                if(target != null && Physics.Raycast(ray, out hit2, 100, layerMaskFloor) && changeImageInBtn.getCurrInd() == 5)
                {
                    if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                        if(Input.GetTouch(0).phase != TouchPhase.Began && Input.GetTouch(0).phase != TouchPhase.Ended)
                            OnMouseDrag(target);
                }
            }
        }
        else timer = 0;


        if(Input.touchCount == 0) timer = 0;

        if(changeImageInBtn.getCurrInd() == 4)
        {
            target = null;
            timer = 0;
            changeImageInBtn.setCurrInd(2);
            GetComponent<WorkSpace>()._OpenOrCloseFurnitureManageObj();
        }

        if(changeImageInBtn.getCurrInd() == 3)
        {
            Destroy(target);
            target = null;
            timer = 0;
            changeImageInBtn.setCurrInd(2);
            GetComponent<WorkSpace>()._OpenOrCloseFurnitureManageObj();
        }
    }

    private void CalculateRetention (GameObject obj)
    {
        if(timer >= delayTimeMax)
        {
            target = obj;
            StartRotY = (int) target.transform.localEulerAngles.y;// .eulerAngles.y;
            TextYRotation.text = "Y=" + StartRotY.ToString();
            //Debug.Log(StartRotY);
            RotateObjScrollbar.value = StartRotY / 360.0f;
            changeImageInBtn.setCurrInd(5);
            changeImageInBtn.SetSelectColor(changeImageInBtn.MoveObjBtnBgCirlceImg);
            timer = 0;
            GetComponent<WorkSpace>()._OpenOrCloseFurnitureManageObj();
        }
    }

    private void OnMouseDrag (GameObject obj)
    {
        if(Input.GetTouch(0).position.y >= YZoneUnInterective)
        {
            Vector3 point = hit2.point;
            point.y = obj.transform.position.y;
            obj.transform.position = point;
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

    public void Updater (Scrollbar scrollbar)
    {
        //target.transform.rotation = Quaternion.Euler(target.transform.localEulerAngles.x, 360 * scrollbar.value, target.transform.localEulerAngles.z);
        target.transform.localEulerAngles = new Vector3(target.transform.localEulerAngles.x, 360 * scrollbar.value, target.transform.localEulerAngles.z);
        //Debug.Log(360 * scrollbar.value);
        TextYRotation.text = "Y=" + ((int) (360 * scrollbar.value)).ToString();
    }
}
