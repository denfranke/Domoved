using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsManagerToNormalMode : MonoBehaviour
{
    private int currHint = 0;
    public GameObject[] hints;
    public GameObject[] ObjectsForHints;

    private void Start ()
    {
        ObjectsForHints[3].GetComponent<CameraZooming>().enabled = false;
        ObjectsForHints[8].GetComponent<ObjectMovement>().enabled = false;
    }
    public void _OpenNextHint ()
    {
        hints[currHint].SetActive(false);
        currHint++;
        updater();
        hints[currHint].SetActive(true);
    }

    public void _OpenPreviousHint ()
    {
        hints[currHint].SetActive(false);
        currHint--;
        updater();
        hints[currHint].SetActive(true);
    }

    public void _CloseAllHints ()
    {
        gameObject.SetActive(false);
    }

    public void updater ()
    {
        switch(currHint)
        {
            case 0://����������� ������
                ObjectsForHints[1].SetActive(false);
                break;
            case 1://�������� ������
                ObjectsForHints[1].SetActive(true);
                ObjectsForHints[2].SetActive(false);
                break;
            case 2://������ ������
                ObjectsForHints[2].SetActive(true);
                ObjectsForHints[3].GetComponent<CameraZooming>().enabled = false;
                break;
            case 3://�����������/���������
                ObjectsForHints[3].GetComponent<CameraZooming>().enabled=true;
                ObjectsForHints[4].SetActive(false);
                break;
            case 4://� ����
                ObjectsForHints[4].SetActive(true);                
                ObjectsForHints[5].SetActive(false);
                break;
            case 5://������
                ObjectsForHints[5].SetActive(true);
                ObjectsForHints[6].SetActive(false);
                break;
            case 6://������
                ObjectsForHints[6].SetActive(true);
                ObjectsForHints[7].SetActive(false);
                break;
            case 7://�����������
                ObjectsForHints[7].SetActive(true);
                ObjectsForHints[8].GetComponent<ObjectMovement>().enabled=false;
                break;
            case 8://�����������
                ObjectsForHints[8].GetComponent<ObjectMovement>().enabled=true;
                //ObjectsForHints[9].SetActive(false);
                break;
            case 9://����������� �������
                ObjectsForHints[9].SetActive(true);
                ObjectsForHints[10].SetActive(false);
                break;
            case 10://�������� �������
                ObjectsForHints[10].SetActive(true);
                ObjectsForHints[11].SetActive(false);
                break;
            case 11://����� ���������
                ObjectsForHints[11].SetActive(true);
                ObjectsForHints[12].SetActive(false);
                break;
            case 12://������� ������
                ObjectsForHints[12].SetActive(true);
                ObjectsForHints[13].SetActive(false);
                break;
            case 13://���������
                ObjectsForHints[13].SetActive(true);
                ObjectsForHints[14].SetActive(false);
                break;
            case 14://ar
                ObjectsForHints[14].SetActive(true);                
                break;
            case 15://vr ����������� ��� ���������
                break;
            case 16://vr ���������
                break;
            case 17://vr ��������
                ObjectsForHints[15].SetActive(false);
                break;
            case 18://vr ������
                ObjectsForHints[15].SetActive(true);
                break;
        }
    }
}
