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
            case 0://перемещение камеры
                ObjectsForHints[1].SetActive(false);
                break;
            case 1://вращение камеры
                ObjectsForHints[1].SetActive(true);
                ObjectsForHints[2].SetActive(false);
                break;
            case 2://наклон камеры
                ObjectsForHints[2].SetActive(true);
                ObjectsForHints[3].GetComponent<CameraZooming>().enabled = false;
                break;
            case 3://приближение/отдаление
                ObjectsForHints[3].GetComponent<CameraZooming>().enabled=true;
                ObjectsForHints[4].SetActive(false);
                break;
            case 4://в меню
                ObjectsForHints[4].SetActive(true);                
                ObjectsForHints[5].SetActive(false);
                break;
            case 5://помощь
                ObjectsForHints[5].SetActive(true);
                ObjectsForHints[6].SetActive(false);
                break;
            case 6://солнце
                ObjectsForHints[6].SetActive(true);
                ObjectsForHints[7].SetActive(false);
                break;
            case 7://подробности
                ObjectsForHints[7].SetActive(true);
                ObjectsForHints[8].GetComponent<ObjectMovement>().enabled=false;
                break;
            case 8://удерживание
                ObjectsForHints[8].GetComponent<ObjectMovement>().enabled=true;
                //ObjectsForHints[9].SetActive(false);
                break;
            case 9://перемещение обьекта
                ObjectsForHints[9].SetActive(true);
                ObjectsForHints[10].SetActive(false);
                break;
            case 10://вращение обьекта
                ObjectsForHints[10].SetActive(true);
                ObjectsForHints[11].SetActive(false);
                break;
            case 11://снять выделение
                ObjectsForHints[11].SetActive(true);
                ObjectsForHints[12].SetActive(false);
                break;
            case 12://удалить обьект
                ObjectsForHints[12].SetActive(true);
                ObjectsForHints[13].SetActive(false);
                break;
            case 13://настройки
                ObjectsForHints[13].SetActive(true);
                ObjectsForHints[14].SetActive(false);
                break;
            case 14://ar
                ObjectsForHints[14].SetActive(true);                
                break;
            case 15://vr перемещение без джойстика
                break;
            case 16://vr настройка
                break;
            case 17://vr закрытие
                ObjectsForHints[15].SetActive(false);
                break;
            case 18://vr кнопка
                ObjectsForHints[15].SetActive(true);
                break;
        }
    }
}
