using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsManagerToAR : MonoBehaviour
{
    private int currHint = 0;
    public GameObject[] hints;
    public GameObject[] ObjectsForHints;

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

    public void updater ()
    {
        switch(currHint)
        {
            case 0://��������
                ObjectsForHints[1].SetActive(false);
                break;
            case 1://����
                ObjectsForHints[1].SetActive(true);
                ObjectsForHints[2].SetActive(false);
                break;
            case 2://�����������
                ObjectsForHints[2].SetActive(true);
                ObjectsForHints[3].SetActive(false);
                break;
            case 3://fix
                ObjectsForHints[3].SetActive(true);
                ObjectsForHints[4].SetActive(false);
                break;
            case 4://���������
                ObjectsForHints[4].SetActive(true);                
                ObjectsForHints[5].SetActive(false);
                break;
            case 5://AR
                ObjectsForHints[5].SetActive(true);
                ObjectsForHints[6].SetActive(false);
                break;
            case 6://VR
                ObjectsForHints[6].SetActive(true);
                break;
        }
    }
}
