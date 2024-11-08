using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoPanel : MonoBehaviour
{
    [Tooltip("������-������ � ������� ����� ����������� ��������")]
    public GameObject InfoLinePrefab;
    [Tooltip("������-������ ���������")]
    public GameObject HeadLinePrefab;
    [Tooltip("������ ���� ����� ����������� �������-������")]
    public GameObject Parent;

    private DbConnector dbConnector;

    public void Start ()
    {
        dbConnector = GameObject.Find("EventSystem").GetComponent<DbConnector>();
        dbConnector.getInfoAboutFlatAndHouse(PlayerPrefs.GetString("FlatNameInUnity"), Parent, GetComponent<InfoPanel>());
    }

    public void InstantiateInfoLine (string text1, string text2)
    {
        GameObject line = Instantiate(InfoLinePrefab);
        line.transform.SetParent(Parent.transform, false);
        line.transform.GetChild(0).GetComponent<TMP_Text>().text = text1;
        line.transform.GetChild(1).GetComponent<TMP_Text>().text = text2;
    }
    public void InstantiateHeadLine (string text)
    {
        GameObject line = Instantiate(HeadLinePrefab);
        line.transform.SetParent(Parent.transform, false);
        line.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
    }
}
