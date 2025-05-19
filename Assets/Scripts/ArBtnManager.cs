using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class ArBtnManager : MonoBehaviour
{
    public SVGImage FixBtnBg;
    public AnchorInputListenerBehaviour AnchorInputListenerBehaviour;
    public PlaneFinderBehaviour PlaneFinderBehaviour;
    private bool flag = true;

    public GameObject ParentInArModeWhereFlat;
    public TMP_Text TextModelSize;

    public Scrollbar scrollbar;
    [SerializeField] private float curScale = 0.033f;
    [SerializeField] private float MinScale = 0.01f;
    [SerializeField] private float MaxScale = 0.09f;

    private void Start ()
    {
        scrollbar.value = (curScale-MinScale)/MaxScale;
    }

    public void _FixOrUnfixModelInWorld ()
    {
        if(flag)
        {
            FixBtnBg.color = new Color(0, 0.5803922f, 0.9803922f);
            AnchorInputListenerBehaviour.enabled = false;
            PlaneFinderBehaviour.enabled = false;
            flag = !flag;
        }
        else
        {
            FixBtnBg.color = Color.white;
            AnchorInputListenerBehaviour.enabled = true;
            PlaneFinderBehaviour.enabled = true;
            flag = !flag;
        }
    }

    public void _SizeScrollBarUpdater ()
    {
        curScale = MinScale + MaxScale * scrollbar.value;
        ParentInArModeWhereFlat.transform.GetChild(0).localScale = new Vector3(curScale, curScale, curScale);
        TextModelSize.text = (((int) (curScale * 1000)) / 10.0f).ToString();
        //Debug.Log(((int) (curScale * 100)));
    }
}
