using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject parentInCities;
    public GameObject parentInDistricts;
    public GameObject parentInStreets;
    public GameObject parentInHouses;
    public GameObject parentInFlats;

    private DbConnector dbConnector;

    private void Start ()
    {
        dbConnector = GameObject.Find("EventSystem").GetComponent<DbConnector>();
    }
    public void InstantiateCityBtnPrefab (string name)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInCities.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => CityListener(btn));
    }

    public void InstantiateDistrictsBtnPrefab (string name)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInDistricts.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => DistrictsListener(btn));
    }

    public void InstantiateStreetsBtnPrefab (string name)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInStreets.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => StreetsListener(btn));
    }

    public void InstantiateHousesBtnPrefab (string name)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInHouses.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => HousesListener(btn));
    }

    public void InstantiateFlatsBtnPrefab (string name, string FlatNameInUnity, int NorthDirectionOfFlatInDegrees)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInFlats.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => FlatsListener(FlatNameInUnity, NorthDirectionOfFlatInDegrees));
    }

    private void FlatsListener (string FlatNameInUnity, int NorthDirectionOfFlatInDegrees)
    {
        PlayerPrefs.SetString("FlatNameInUnity", FlatNameInUnity);
        PlayerPrefs.SetInt("NorthDirectionOfFlatInDegrees", NorthDirectionOfFlatInDegrees);
        SceneManager.LoadScene("WorkSpace");
    }

    private void HousesListener (GameObject btn)
    {
        dbConnector.openFlatsMenu(btn.name);
    }

    private void StreetsListener (GameObject btn)
    {
        dbConnector.openHousesMenu(btn.name);
    }

    private void DistrictsListener (GameObject btn)
    {
        dbConnector.openStreetsMenu(btn.name);
    }

    private void CityListener (GameObject btn)
    {
        dbConnector.openDistrictsMenu(btn.name);
    }
}
