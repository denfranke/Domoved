using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageInBtn : MonoBehaviour
{
    [Tooltip ("Номер текущего состояния (по умолчанию 0)")]
    private int currInd;

    private void Start ()
    {
        setCurrInd(2);
    }

    /*[Tooltip("Кнопка режима: вращение камеры")]
    public GameObject RotateBtn;
    [Tooltip("Кнопка режима: перемещение камеры")]
    public GameObject TransparentBtn;
    [Tooltip("Кнопка режима: накломение камеры")]
    public GameObject InclineBtn;

    private void Start ()
    {
        TransparentBtn.SetActive(false);
        InclineBtn.SetActive(false);
    }

    public void _ChangeBtn ()
    {
        if(TransparentBtn.activeSelf)
        {
            TransparentBtn.SetActive(false);
            RotateBtn.SetActive(true);
            InclineBtn.SetActive(false);
            currInd = 0;
        }
        else
        if(RotateBtn.activeSelf)
        {
            TransparentBtn.SetActive(false);
            RotateBtn.SetActive(false);
            InclineBtn.SetActive(true);
            currInd = 1;
        }
        else
        if(InclineBtn.activeSelf)
        {
            TransparentBtn.SetActive(true);
            RotateBtn.SetActive(false);
            InclineBtn.SetActive(false);
            currInd = 2;
        }

    }
    */

    //public Image RotateBtnBgCirlceImg;
    //public Image TransparentBtnBgCirlceImg;
    //public Image InclineBtnBgCirlceImg;
    //public Image MoveObjBtnBgCirlceImg;
    //public Image RotateObjBtnBgCirlceImg;

    public SVGImage RotateBtnBgCirlceSVGImg;
    public SVGImage TransparentBtnBgCirlceSVGImg;
    public SVGImage InclineBtnBgCirlceSVGImg;
    public SVGImage MoveObjBtnBgCirlceImg;
    public SVGImage RotateObjBtnBgCirlceImg;

    public GameObject RotateObjScrollbar;


    public void _ChangeBtn (Button thisBtn)
    {
        //Debug.Log(name);
        if(thisBtn.name == "TransparentBtn")
        {
            setAllImageWhite();
            SetSelectColor(TransparentBtnBgCirlceSVGImg);
            currInd = 2;
        }
        else if(thisBtn.name == "RotateCamBtn")
        {
            setAllImageWhite();
            SetSelectColor(RotateBtnBgCirlceSVGImg);
            currInd = 1;
        }
        else if(thisBtn.name == "InclineBtn")
        {
            setAllImageWhite();
            SetSelectColor(InclineBtnBgCirlceSVGImg);
            currInd = 0;
        }
        else if(thisBtn.name == "DeleteBtn")
        {
            currInd = 3;
        }
        else if(thisBtn.name == "CloseBtn")
        {
            currInd = 4;
        }
        else if(thisBtn.name == "MoveBtn")
        {
            setAllImageWhite();
            SetSelectColor(MoveObjBtnBgCirlceImg);
            currInd = 5;
        }
        else if(thisBtn.name == "RotateObjBtn")
        {
            setAllImageWhite();
            SetSelectColor(RotateObjBtnBgCirlceImg);
            RotateObjScrollbar.SetActive(true);
            currInd = 6;
        }
        else
        {
            setAllImageWhite();
            currInd = 7;//ничего не выбрано, все кнопки белые
        }
    }

    public void setAllImageWhite ()
    {
        RotateObjScrollbar.SetActive(false);
        TransparentBtnBgCirlceSVGImg.color = Color.white;
        RotateBtnBgCirlceSVGImg.color = Color.white;
        InclineBtnBgCirlceSVGImg.color = Color.white;
        MoveObjBtnBgCirlceImg.color = Color.white;
        RotateObjBtnBgCirlceImg.color = Color.white;
    }

    public void SetSelectColor (SVGImage image)
    {
        //setAllImageWhite();
        image.color = new Color(0, 0.5803922f, 0.9803922f);
    }
    public void SetSelectColor (Image image)
    {
        //setAllImageWhite();
        image.color = new Color(1, 0.7821057f, 0.4496855f);
    }

    public int getCurrInd ()
    {
        return currInd;
    }

    public void setCurrInd (int ind)
    {
        setAllImageWhite();
        if(ind == 2)
        {
            SetSelectColor(TransparentBtnBgCirlceSVGImg);
        }
        currInd = ind;
    }
}
