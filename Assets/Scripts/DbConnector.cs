using System;
using UnityEngine;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class DbConnector : MonoBehaviour
{
    private SqlConnection dbConnection;
    private CreateButtons createBtn;
    //private InfoPanel infoPanel;

    public GameObject MainMenu;
    public GameObject CitiesMenu;
    public GameObject DistrictsMenu;
    public GameObject StreetsMenu;
    public GameObject HousesMenu;
    public GameObject FlatsMenu;

    private string ip = "192.168.1.67";
    //private string ip = "172.23.49.114";

    private string curCity = "", curDistrict = "", curStreet = "", curHouse = "";

    private void Awake ()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }

    private void Start ()
    {
        Debug.Log("Connecting to database...");
        //string connectionString = $"Data Source=172.23.50.39,1433; Initial Catalog=Flats; User ID=sa; Password=123;";
        string connectionString = $"Data Source=" + ip + ",1433; Initial Catalog=Flats; User ID=sa; Password=123;";

        dbConnection = new SqlConnection(connectionString);

        try
        {
            dbConnection.Open();
            Debug.Log("Connected to database.");
        }
        catch(Exception _exception)
        {
            Debug.LogWarning("ошибка " + _exception.ToString());
        }

        if(GameObject.Find("EventSystem") != null)
            createBtn = GameObject.Find("EventSystem").GetComponent<CreateButtons>();

        //if(GameObject.Find("InfoSpace") != null)
        //   infoPanel = GameObject.Find("InfoSpace").GetComponent<InfoPanel>();
    }

    public void openMainMenu ()
    {
        ClearFromButtons();
        MainMenu.SetActive(true);
        CitiesMenu.SetActive(false);
    }

    public void openCitiesMenu ()
    {
        ClearFromButtons();
        MainMenu.SetActive(false);
        CitiesMenu.SetActive(true);
        DistrictsMenu.SetActive(false);

        string oString = "use flats Select * from Cities";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                //Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateCityBtnPrefab(oReader["Name"].ToString());
            }
            oReader.Close();
        }
    }

    public void openDistrictsMenu (string nameCity)
    {
        ClearFromButtons();
        CitiesMenu.SetActive(false);
        DistrictsMenu.SetActive(true);
        StreetsMenu.SetActive(false);

        nameCity = nameCity == "" ? curCity : nameCity;
        curCity = nameCity;
        string oString = "use flats Select Districts.name from Districts inner join Cities on cities.Id_City=Districts.Id_City Where cities.name='" + nameCity + "'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                // Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateDistrictsBtnPrefab(oReader["Name"].ToString());
            }
            oReader.Close();
        }
    }

    public void openStreetsMenu (string nameDistrict)
    {
        ClearFromButtons();
        DistrictsMenu.SetActive(false);
        StreetsMenu.SetActive(true);
        HousesMenu.SetActive(false);

        nameDistrict = nameDistrict == "" ? curDistrict : nameDistrict;
        curDistrict = nameDistrict;
        string oString = "use flats Select Streets.name from Streets inner join Districts on Streets.Id_District=Districts.Id_District Where Districts.name='" + nameDistrict + "'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                // Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateStreetsBtnPrefab(oReader["Name"].ToString());
            }
            oReader.Close();
        }
    }

    public void openHousesMenu (string nameStreet)
    {
        ClearFromButtons();
        StreetsMenu.SetActive(false);
        HousesMenu.SetActive(true);
        FlatsMenu.SetActive(false);

        nameStreet = nameStreet == "" ? curStreet : nameStreet;
        curStreet = nameStreet;
        string oString = "use flats Select Houses.name from Houses inner join Streets on Streets.Id_Street=Houses.Id_Street Where Streets.name='" + nameStreet + "'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                // Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateHousesBtnPrefab(oReader["Name"].ToString());
            }
            oReader.Close();
        }
    }

    public void openFlatsMenu (string nameHouse)
    {
        ClearFromButtons();
        HousesMenu.SetActive(false);
        FlatsMenu.SetActive(true);

        nameHouse = nameHouse == "" ? curHouse : nameHouse;
        curHouse = nameHouse;
        string oString = "use flats Select * from Flats inner join Houses on Houses.Id_House=Flats.Id_House Where Houses.name='" + nameHouse + "' and Flats.FlatNameInUnity<>'FlatTutorial'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                // Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateFlatsBtnPrefab("Кол-во комнат:" + oReader["RoomsCount"].ToString() + " Этаж:" + oReader["Floor"].ToString(), oReader["FlatNameInUnity"].ToString(), (int) oReader["NorthDirectionOfFlatInDegrees"]);
            }
            oReader.Close();
        }
    }

    public void getInfoAboutFlatAndHouse (string FlatNameInUnity, GameObject parent, InfoPanel infoPanel)
    {
        ClearFromLines(parent);

        string oString = "use flats Select * from Flats inner join Houses on Houses.Id_House=Flats.Id_House Where Flats.FlatNameInUnity='"+FlatNameInUnity + "'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);

        string[] str = new string[17];
        str[0] = "Floor";
        str[1] = "Price";
        str[2] = "LivingSpace";
        str[3] = "TotalArea";
        str[4] = "CeilingHeight";
        str[5] = "RoomsCount";
        str[6] = "Finishing";
        str[7] = "TypeOfHousing";
        int borderL = 8;
        str[8] = "FlatNameInUnity";
        str[9] = "NorthDirectionOfFlatInDegrees";
        int borderR = 10;
        str[10] = "Name";
        str[11] = "FreeFlatsCount";
        str[12] = "HouseType";
        str[13] = "HouseClass";
        str[14] = "Parking";
        str[15] = "Developer";
        str[16] = "YearOfCompletion";

        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                if(oReader.HasRows)
                {
                    infoPanel.InstantiateHeadLine("Информация о квартире:");
                    for(int i = 0; i < borderL; i++)
                    {
                        infoPanel.InstantiateInfoLine(str[i], oReader[str[i]].ToString());
                    }
                    infoPanel.InstantiateHeadLine("Информация о доме:");
                    for(int i = borderR; i < str.Length; i++)
                    {
                        infoPanel.InstantiateInfoLine(str[i], oReader[str[i]].ToString());
                    }
                }
            }
            oReader.Close();
        }
    }

    private void ClearFromButtons ()
    {
        GameObject[] lst = GameObject.FindGameObjectsWithTag("ListBtn");
        for(int i = 0; i < lst.Count(); i++)
            Destroy(lst[i]);
    }

    private void ClearFromLines (GameObject parent)
    {
        //GameObject[] lst = GameObject.FindGameObjectsWithTag("ListLine");
        HorizontalLayoutGroup[] lst = parent.GetComponentsInChildren<HorizontalLayoutGroup>();
        for(int i = 0; i < lst.Count(); i++)
            Destroy(lst[i].gameObject);
    }

    public void Quit ()
    {
        Application.Quit();
    }

    public void _StartTutorial ()
    {
        PlayerPrefs.SetString("FlatNameInUnity", "FlatTutorial");
       // Debug.Log("________ " + PlayerPrefs.GetString("FlatNameInUnity"));
        PlayerPrefs.SetInt("NorthDirectionOfFlatInDegrees", -200);
        SceneManager.LoadScene("TutorialScene");
    }
}
