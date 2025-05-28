using System;
using UnityEngine;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using System.IO;
using System.Text;
using System.Xml;
using System.Globalization;

public class Item
{
    public int Id_Flat { get; set; }
    public int Floor { get; set; }
    public int Price { get; set; }
    public string LivingSpace { get; set; }
    public string CeilingHeight { get; set; }
    public int Id_House { get; set; }
    public int RoomsCount { get; set; }
    public string Finishing { get; set; }
    public string TypeOfHousing { get; set; }
    public string TotalArea { get; set; }
    public string FlatNameInUnity { get; set; }
    public int NorthDirectionOfFlatInDegrees { get; set; }
    public int FreeFlatsCount { get; set; }
    public string Developer { get; set; }
    public string HouseClass { get; set; }
    public string HouseType { get; set; }
    public string HouseName { get; set; }
    public string Parking { get; set; }
    public string YearOfCompletion { get; set; }
    public int Id_Street { get; set; }
    public string StreetName { get; set; }
    public int Id_District { get; set; }
    public string DistrictName { get; set; }
    public int Id_City { get; set; }
    public string CityName { get; set; }
    public string Url { get; set; }
}

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

    private string ip = "95.165.157.84";

    private string curCity = "", curDistrict = "", curStreet = "", curHouse = "";

    List<Item> itemList = new List<Item>();

    private void Awake ()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }

    private async void Start ()
    {
        if(GameObject.Find("EventSystem") != null)
            createBtn = GameObject.Find("EventSystem").GetComponent<CreateButtons>();

        itemList = LoadItemsFromXml();

        Debug.Log("Connecting to database...");
        string connectionString = $"Data Source=" + ip + ",42145; Initial Catalog=OnlyXML; User ID=ReadOnlyUser; Password=ReadOnlyUser;";

        /*dbConnection = new SqlConnection(connectionString);

        try
        {
            dbConnection.Open();
            Debug.Log("Connected to database.");
        }
        catch(Exception _exception)
        {
            Debug.LogWarning("ошибка " + _exception.ToString());
        }
        finally
        {
            if(GameObject.Find("EventSystem") != null)
                createBtn = GameObject.Find("EventSystem").GetComponent<CreateButtons>();
        }
        */

        string query = "SELECT XmlContent,CreatedAt FROM XmlStorage";

        try
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                await connection.OpenAsync();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            int dateIndex = reader.GetOrdinal("CreatedAt");
                            if(!reader.IsDBNull(dateIndex))
                            {
                                string xmlContent = reader["xmlContent"].ToString();
                                DateTime CreatedAt = reader.GetDateTime(dateIndex);
                                Debug.Log("Полученная дата: " + CreatedAt);

                                if(!PlayerPrefs.HasKey("oldCreatedAt") || (PlayerPrefs.HasKey("oldCreatedAt") && CreatedAt.ToString() != PlayerPrefs.GetString("oldCreatedAt")))
                                {
                                    PlayerPrefs.SetString("oldCreatedAt", CreatedAt.ToString());
                                    PlayerPrefs.Save();

                                    File.WriteAllText(Path.Combine(Application.persistentDataPath, "test.xml"), xmlContent);
                                    //File.WriteAllText(@"D:\test.xml", xmlContent);
                                    Debug.Log("XML файл успешно сохранён как test.xml");
                                }
                                else
                                {
                                    Debug.Log("Данные актуальны.");
                                }
                            }
                        }
                    }
                }
                connection.Close();                
            }
        }        
        catch(SqlException ex)
        {
            Debug.Log("Ошибка: " + ex.Message);            
        }
        
        itemList = LoadItemsFromXml();
    }

    public List<Item> LoadItemsFromXml ()
    {
        string path = Path.Combine(Application.persistentDataPath, "test.xml");

        if(!File.Exists(path))
        {
            Debug.LogError("XML файл не найден по пути: " + path);
            return new List<Item>();
        }

        try
        {
            string xmlContent = File.ReadAllText(path);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            List<Item> itemList = new List<Item>();

            XmlNodeList itemNodes = xmlDoc.SelectNodes("/Items/Item");
            foreach(XmlNode node in itemNodes)
            {
                Item item = new Item();

                XmlNode a = node.SelectSingleNode("Id_Flat");
                XmlNode b = node.SelectSingleNode("Floor");
                XmlNode c = node.SelectSingleNode("Price");
                XmlNode d = node.SelectSingleNode("LivingSpace");
                XmlNode e = node.SelectSingleNode("CeilingHeight");
                XmlNode f = node.SelectSingleNode("Id_House");
                XmlNode g = node.SelectSingleNode("RoomsCount");
                XmlNode h = node.SelectSingleNode("Finishing");
                XmlNode i = node.SelectSingleNode("TypeOfHousing");
                XmlNode j = node.SelectSingleNode("TotalArea");
                XmlNode k = node.SelectSingleNode("FlatNameInUnity");
                XmlNode l = node.SelectSingleNode("NorthDirectionOfFlatInDegrees");
                XmlNode m = node.SelectSingleNode("FreeFlatsCount");
                XmlNode n = node.SelectSingleNode("Developer");
                XmlNode o = node.SelectSingleNode("HouseClass");
                XmlNode p = node.SelectSingleNode("HouseType");
                XmlNode q = node.SelectSingleNode("HouseName");
                XmlNode r = node.SelectSingleNode("Parking");
                XmlNode s = node.SelectSingleNode("YearOfCompletion");
                XmlNode t = node.SelectSingleNode("Id_Street");
                XmlNode u = node.SelectSingleNode("StreetName");
                XmlNode v = node.SelectSingleNode("Id_District");
                XmlNode w = node.SelectSingleNode("DistrictName");
                XmlNode x = node.SelectSingleNode("Id_City");
                XmlNode y = node.SelectSingleNode("CityName");
                XmlNode z = node.SelectSingleNode("Url");

                if(a != null) item.Id_Flat = int.Parse(a.InnerText);
                if(b != null) item.Floor = int.Parse(b.InnerText);
                if(c != null) item.Price = int.Parse(c.InnerText);

                double number;
                if(d != null && double.TryParse(d.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                    item.LivingSpace = number.ToString("F1", CultureInfo.InvariantCulture);
                if(e != null && double.TryParse(e.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                    item.CeilingHeight = number.ToString("F1", CultureInfo.InvariantCulture);

                if(f != null) item.Id_House = int.Parse(f.InnerText);
                if(g != null) item.RoomsCount = int.Parse(g.InnerText);
                if(h != null) item.Finishing = h.InnerText;
                if(i != null) item.TypeOfHousing = i.InnerText;

                if(j != null && double.TryParse(j.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                    item.TotalArea = number.ToString("F1", CultureInfo.InvariantCulture);

                if(k != null) item.FlatNameInUnity = k.InnerText;
                if(l != null) item.NorthDirectionOfFlatInDegrees = int.Parse(l.InnerText);
                if(m != null) item.FreeFlatsCount = int.Parse(m.InnerText);
                if(n != null) item.Developer = n.InnerText;
                if(o != null) item.HouseClass = o.InnerText;
                if(p != null) item.HouseType = p.InnerText;
                if(q != null) item.HouseName = q.InnerText;
                if(r != null) item.Parking = r.InnerText;
                if(s != null) item.YearOfCompletion = s.InnerText;
                if(t != null) item.Id_Street = int.Parse(t.InnerText);
                if(u != null) item.StreetName = u.InnerText;
                if(v != null) item.Id_District = int.Parse(v.InnerText);
                if(w != null) item.DistrictName = w.InnerText;
                if(x != null) item.Id_City = int.Parse(x.InnerText);
                if(y != null) item.CityName = y.InnerText;
                if(z != null) item.Url = z.InnerText;

                itemList.Add(item);

            }
            return itemList;
        }
        catch(Exception e)
        {
            Debug.LogError("Ошибка при загрузке XML: " + e.Message);
            return new List<Item>();
        }
    }


    public void openMainMenu ()
    {
        ClearFromButtons();
        MainMenu.SetActive(true);
        CitiesMenu.SetActive(false);
    }

    public void openCitiesMenu ()
    {
        CitiesMenu.SetActive(true);
        MainMenu.SetActive(false);
        ClearFromButtons();
        //DistrictsMenu.SetActive(false);

        List<string> uniqueCities = new List<string>();

        foreach(Item item in itemList)
        {
            if(uniqueCities.Count == 0 || !uniqueCities.Contains(item.CityName))
            {
                createBtn.InstantiateCityBtnPrefab(item.CityName);
                uniqueCities.Add(item.CityName);
            }
        }
    }

    public void openCitiesMenuBtn ()
    {
        //MainMenu.SetActive(false);
        CitiesMenu.SetActive(true);
        DistrictsMenu.SetActive(false);
    }

    public void openDistrictsMenu (string nameCity)
    {
        //StreetsMenu.SetActive(false);
        DistrictsMenu.SetActive(true);
        CitiesMenu.SetActive(false);
        ClearFromButtons();

        List<string> uniqueDistricts = new List<string>();

        nameCity = nameCity == "" ? curCity : nameCity;
        curCity = nameCity;

        foreach(Item item in itemList)
        {
            if((uniqueDistricts.Count == 0 || !uniqueDistricts.Contains(item.DistrictName)) && item.CityName == nameCity)
            {
                createBtn.InstantiateDistrictsBtnPrefab(item.DistrictName, nameCity);
                uniqueDistricts.Add(item.DistrictName);
            }
        }
    }

    public void openDistrictsMenuBtn ()
    {
        //CitiesMenu.SetActive(false);
        DistrictsMenu.SetActive(true);
        StreetsMenu.SetActive(false);
    }

    public void openStreetsMenu (string nameDistrict, string nameCity)
    {
        //HousesMenu.SetActive(false);
        StreetsMenu.SetActive(true);
        DistrictsMenu.SetActive(false);
        ClearFromButtons();

        List<string> uniqueStreets = new List<string>();

        nameDistrict = nameDistrict == "" ? curDistrict : nameDistrict;
        curDistrict = nameDistrict;

        foreach(Item item in itemList)
        {
            if((uniqueStreets.Count == 0 || !uniqueStreets.Contains(item.StreetName)) && item.CityName == nameCity && item.DistrictName == nameDistrict)
            {
                createBtn.InstantiateStreetsBtnPrefab(item.StreetName, nameCity, nameDistrict);
                uniqueStreets.Add(item.StreetName);
            }
        }
    }

    public void openStreetsMenuBtn ()
    {
        //DistrictsMenu.SetActive(false);
        StreetsMenu.SetActive(true);
        HousesMenu.SetActive(false);
    }

    public void openHousesMenu (string nameStreet, string nameCity, string nameDistrict)
    {
        //FlatsMenu.SetActive(false);
        HousesMenu.SetActive(true);
        StreetsMenu.SetActive(false);
        ClearFromButtons();

        List<string> uniqueHouses = new List<string>();

        nameStreet = nameStreet == "" ? curStreet : nameStreet;
        curStreet = nameStreet;

        foreach(Item item in itemList)
        {
            if((uniqueHouses.Count == 0 || !uniqueHouses.Contains(item.HouseName)) && item.CityName == nameCity && item.DistrictName == nameDistrict && item.StreetName == nameStreet)
            {
                createBtn.InstantiateHousesBtnPrefab(item.HouseName, nameCity, nameDistrict, nameStreet);
                uniqueHouses.Add(item.HouseName);
            }
        }

        /*        string oString = "use flats Select Houses.name from Houses inner join Streets on Streets.Id_Street=Houses.Id_Street Where Streets.name='" + nameStreet + "'";
                SqlCommand oCmd = new SqlCommand(oString, dbConnection);
                using(SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while(oReader.Read())
                    {
                        // Debug.Log(oReader["Name"].ToString());
                        createBtn.InstantiateHousesBtnPrefab(oReader["Name"].ToString());
                    }
                    oReader.Close();
                }*/
    }

    public void openHousesMenuBtn ()
    {
        //StreetsMenu.SetActive(false);
        HousesMenu.SetActive(true);
        FlatsMenu.SetActive(false);
    }

    public void openFlatsMenu (string nameHouse, string nameCity, string nameDistrict, string nameStreet)
    {
        FlatsMenu.SetActive(true);
        HousesMenu.SetActive(false);
        ClearFromButtons();

        List<string> uniqueFlats = new List<string>();

        nameHouse = nameHouse == "" ? curHouse : nameHouse;
        curHouse = nameHouse;

        foreach(Item item in itemList)
        {
            if((uniqueFlats.Count == 0 || !uniqueFlats.Contains(item.FlatNameInUnity)) && item.CityName == nameCity && item.DistrictName == nameDistrict && item.StreetName == nameStreet && item.HouseName == nameHouse && item.FlatNameInUnity != "FlatTutorial")
            {
                createBtn.InstantiateFlatsBtnPrefab("Кол-во комнат:" + item.RoomsCount.ToString() + " Этаж:" + item.Floor.ToString(), item.Url, item.FlatNameInUnity, item.NorthDirectionOfFlatInDegrees, nameCity, nameDistrict, nameStreet, nameHouse);
                uniqueFlats.Add(item.FlatNameInUnity);
            }
        }

        /*string oString = "use flats Select * from Flats inner join Houses on Houses.Id_House=Flats.Id_House Where Houses.name='" + nameHouse + "' and Flats.FlatNameInUnity<>'FlatTutorial'";
        SqlCommand oCmd = new SqlCommand(oString, dbConnection);
        using(SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while(oReader.Read())
            {
                // Debug.Log(oReader["Name"].ToString());
                createBtn.InstantiateFlatsBtnPrefab("Кол-во комнат:" + oReader["RoomsCount"].ToString() + " Этаж:" + oReader["Floor"].ToString(), oReader["FlatNameInUnity"].ToString(), (int) oReader["NorthDirectionOfFlatInDegrees"]);
            }
            oReader.Close();
        }*/
    }

    public void getInfoAboutFlatAndHouse (string FlatNameInUnity, GameObject parent, InfoPanel infoPanel)
    {
        ClearFromLines(parent);

        //string oString = "use flats Select * from Flats inner join Houses on Houses.Id_House=Flats.Id_House Where Flats.FlatNameInUnity='" + FlatNameInUnity + "'";
        //SqlCommand oCmd = new SqlCommand(oString, dbConnection);

        foreach(Item item in itemList)
        {

            if(item.FlatNameInUnity == FlatNameInUnity)
            {
                const int n = 17;

                string[] str = new string[n];
                str[0] = item.Floor.ToString();
                str[1] = item.Price.ToString();
                str[2] = item.LivingSpace.ToString();
                str[3] = item.TotalArea.ToString();
                str[4] = item.CeilingHeight.ToString();
                str[5] = item.RoomsCount.ToString();
                str[6] = item.Finishing.ToString();
                int borderL = 7;
                str[8] = item.FlatNameInUnity.ToString();
                str[9] = item.NorthDirectionOfFlatInDegrees.ToString();
                int borderR = 10;
                str[10] = item.HouseName.ToString();
                str[11] = item.FreeFlatsCount.ToString();
                str[12] = item.HouseType.ToString();
                str[13] = item.HouseClass.ToString();
                str[14] = item.Parking.ToString();
                str[15] = item.Developer.ToString();
                str[16] = item.YearOfCompletion.ToString();

                string[] str2 = new string[n];
                str2[0] = "Этаж";
                str2[1] = "Цена";
                str2[2] = "Жилая площадь";
                str2[3] = "Общая площадь";
                str2[4] = "Высота потолка";
                str2[5] = "Кол-во комнат";
                str2[6] = "Отделка";

                str2[10] = "Номер дома";
                str2[11] = "Число квартир";
                str2[12] = "Тип дома";
                str2[13] = "Класс дома";
                str2[14] = "Парковка";
                str2[15] = "Застройщик";
                str2[16] = "Год постройки";


                infoPanel.InstantiateHeadLine("Информация о квартире");
                for(int i = 0; i < borderL; i++)
                {
                    infoPanel.InstantiateInfoLine(str2[i], str[i]);
                }
                infoPanel.InstantiateHeadLine("Информация о доме");
                for(int i = borderR; i < str.Length; i++)
                {
                    infoPanel.InstantiateInfoLine(str2[i], str[i]);
                }

                return;
            }
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
        PlayerPrefs.SetInt("NorthDirectionOfFlatInDegrees", -200);
        SceneManager.LoadScene("TutorialScene");
    }
}
