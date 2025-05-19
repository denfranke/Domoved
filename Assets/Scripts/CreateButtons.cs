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

    public void InstantiateDistrictsBtnPrefab (string name, string nameCity)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInDistricts.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => DistrictsListener(btn, nameCity));
    }

    public void InstantiateStreetsBtnPrefab (string name, string nameCity, string nameDistrict)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInStreets.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => StreetsListener(btn, nameCity, nameDistrict));
    }

    public void InstantiateHousesBtnPrefab (string name, string nameCity, string nameDistrict, string nameStreet)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInHouses.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        btn.GetComponent<Button>().onClick.AddListener(() => HousesListener(btn, nameCity, nameDistrict, nameStreet));
    }

    public void InstantiateFlatsBtnPrefab (string name, string FlatNameInUnity, int NorthDirectionOfFlatInDegrees, string nameCity, string nameDistrict, string nameStreet, string nameHouse)
    {
        GameObject btn = Instantiate(buttonPrefab);
        btn.transform.SetParent(parentInFlats.transform, false);
        btn.name = name;
        btn.GetComponentInChildren<TMP_Text>().text = name;
        //btn.GetComponentInChildren<TMP_Text>().alignment = TextAlignmentOptions.Left;
        btn.GetComponent<Button>().onClick.AddListener(() => FlatsListener(FlatNameInUnity, NorthDirectionOfFlatInDegrees, nameCity, nameDistrict, nameStreet, nameHouse));
    }

    private void FlatsListener (string FlatNameInUnity, int NorthDirectionOfFlatInDegrees, string nameCity, string nameDistrict, string nameStreet, string nameHouse)
    {
        /*PlayerPrefs.SetString("nameCity", nameCity);
        PlayerPrefs.SetString("nameDistrict", nameDistrict);
        PlayerPrefs.SetString("nameStreet", nameStreet);
        PlayerPrefs.SetString("nameHouse", nameHouse);*/
        PlayerPrefs.SetString("FlatNameInUnity", FlatNameInUnity);
        PlayerPrefs.SetInt("NorthDirectionOfFlatInDegrees", NorthDirectionOfFlatInDegrees);
        SceneManager.LoadScene("WorkSpace");
    }

    private void HousesListener (GameObject btn, string nameCity, string nameDistrict, string nameStreet)
    {
        dbConnector.openFlatsMenu(btn.name, nameCity, nameDistrict, nameStreet);
    }

    private void StreetsListener (GameObject btn, string nameCity, string nameDistrict)
    {
        dbConnector.openHousesMenu(btn.name, nameCity, nameDistrict);
    }

    private void DistrictsListener (GameObject btn, string nameCity)
    {
        dbConnector.openStreetsMenu(btn.name, nameCity);
    }

    private void CityListener (GameObject btn)
    {
        dbConnector.openDistrictsMenu(btn.name);
    }
}
