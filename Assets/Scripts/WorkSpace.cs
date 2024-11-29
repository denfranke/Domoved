using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkSpace : MonoBehaviour
{
    [Tooltip("Главное пространство")]
    public GameObject MainSpace;
    [Tooltip("Информационное пространство")]
    public GameObject InfoSpace;
    public GameObject SettingsSpace;
    public GameObject HelpSpace;
    public GameObject timeScrollBar;
    private GameObject CameraManageObj;
    private GameObject FurnitureManageObj;
    //private GameObject BGFurnitureManageObj;

    public GameObject MainSpaceInAR;
    public GameObject InfoSpaceInAR;
    public GameObject SettingsSpaceInAR;

    public GameObject MainSpaceInVR;
    public GameObject InfoSpaceInVR;
    public GameObject SettingsSpaceInVR;

    public GameObject SettingHeadLine1Prefab;
    public GameObject SettingHeadLine2Prefab;

    public GameObject SettingsContentParent;
    public GameObject SettingsInARContentParent;
    public GameObject SettingsInVRContentParent;

    public GameObject MaterialScrollViewPrefab;
    public GameObject MaterialColumnPrefab;
    public GameObject NewMaterialSptitePrefab;

    [SerializeField] private Sprite[] wallAndFloorsSprites;
    [SerializeField] private Sprite[] doorsSprites;
    [SerializeField] private Material[] wallAndFloorsMaterials;
    [SerializeField] private Material[] doorsMaterials;

    private CameraMovement ActiveInteractiveCamera;
    private ObjectMovement ActiveInteractiveObject;
    private bool flag = true;
    private bool lastState;

    public GameObject ParentInArModeWhereFlat;
    public GameObject ParentInVrModeWhereFlat;
    public GameObject ParentInNormalModeWhereFlat;

    private GameObject FlatPrefab;
    private string FlatNameInUnity;
    private int NorthDirectionOfFlatInDegrees;

    public GameObject ArMode;
    public GameObject VrMode;

    void Start ()
    {
        CreateFlatsAtScene();

        ArMode.SetActive(true);
        VrMode.SetActive(true);

        ParentInArModeWhereFlat.transform.GetChild(0).gameObject.SetActive(false);
        ParentInVrModeWhereFlat.transform.GetChild(0).gameObject.SetActive(false);
        ParentInNormalModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);

        SettingsSpace.SetActive(true);
        CreateSettingsLines("NormalMode");
        SettingsSpace.SetActive(false);

        ParentInArModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);
        ParentInNormalModeWhereFlat.transform.GetChild(0).gameObject.SetActive(false);

        SettingsSpaceInAR.SetActive(true);
        CreateSettingsLines("ArMode");
        SettingsSpaceInAR.SetActive(false);

        ParentInArModeWhereFlat.transform.GetChild(0).gameObject.SetActive(false);
        ParentInVrModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);

        SettingsSpaceInAR.SetActive(true);
        CreateSettingsLines("VrMode");
        SettingsSpaceInAR.SetActive(false);

        ParentInArModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);
        ParentInVrModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);
        ParentInNormalModeWhereFlat.transform.GetChild(0).gameObject.SetActive(true);

        ArMode.SetActive(false);
        VrMode.SetActive(false);

        InfoSpace.SetActive(true);
        InfoSpaceInAR.SetActive(true);

        HelpSpace.SetActive(false);
        timeScrollBar.SetActive(false);

        ActiveInteractiveCamera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        ActiveInteractiveCamera.SetInteractive(true);

        ActiveInteractiveObject = GetComponent<ObjectMovement>();
        ActiveInteractiveObject.SetInteractive(true);

        CameraManageObj = GameObject.Find("CameraManageObj");
        CameraManageObj.SetActive(true);

        FurnitureManageObj = GameObject.Find("FurnitureManageObj");
        FurnitureManageObj.SetActive(false);
    }

    private void Update ()
    {
        if(flag)
        {
            InfoSpace.SetActive(false);
            InfoSpaceInAR.SetActive(false);
            flag = false;
        }
    }

    private void CreateFlatsAtScene ()
    {
        NorthDirectionOfFlatInDegrees = PlayerPrefs.GetInt("NorthDirectionOfFlatInDegrees");
        FlatNameInUnity = PlayerPrefs.GetString("FlatNameInUnity");

        if(FlatNameInUnity == "" || FlatNameInUnity == null || SceneManager.GetActiveScene().name== "TutorialScene")
            FlatPrefab = Resources.Load<GameObject>("Prefabs/Flats/FlatTutorial");
        else
            FlatPrefab = Resources.Load<GameObject>("Prefabs/Flats/" + FlatNameInUnity);

        Transform FlatInNormalMode = Instantiate(FlatPrefab).transform;
        FlatInNormalMode.SetParent(ParentInNormalModeWhereFlat.transform, false);
        FlatInNormalMode.eulerAngles = new Vector3(0, NorthDirectionOfFlatInDegrees, 0);

        foreach(TeleportPoint teleportPoint in FlatInNormalMode.GetComponentsInChildren<TeleportPoint>())
        {
            if(teleportPoint.tag == "TeleportPoint")
            {
                teleportPoint.gameObject.SetActive(false);
            }
        }

        Transform FlatInVrMode = Instantiate(FlatPrefab).transform;
        FlatInVrMode.SetParent(ParentInVrModeWhereFlat.transform, false);
        FlatInVrMode.eulerAngles = new Vector3(0, NorthDirectionOfFlatInDegrees, 0);

        Transform FlatInArMode = Instantiate(FlatPrefab).transform;
        FlatInArMode.SetParent(ParentInArModeWhereFlat.transform, false);
        FlatInArMode.eulerAngles = new Vector3(0, NorthDirectionOfFlatInDegrees, 0);

        foreach(TeleportPoint teleportPoint in FlatInArMode.GetComponentsInChildren<TeleportPoint>())
        {
            if(teleportPoint.tag== "TeleportPoint")
            {
                teleportPoint.gameObject.SetActive(false);
            }
        }

        if(FlatNameInUnity != "FlatTutorial")
        {
            foreach(Light l in FlatInArMode.GetComponentsInChildren<Light>())
            {
                if(l.tag == "LightInFlat")
                {
                    l.intensity = 0.333f;
                }
            }
        }

        FlatInArMode.localScale = new Vector3(0.0333333f, 0.0333333f, 0.0333333f);
    }

    private void ClearSettingsLines ()
    {
        GameObject[] lst = GameObject.FindGameObjectsWithTag("SettingHeadLine");
        for(int i = 0; i < lst.Count(); i++)
            Destroy(lst[i]);

        lst = GameObject.FindGameObjectsWithTag("MaterialScrollView");
        for(int i = 0; i < lst.Count(); i++)
            Destroy(lst[i]);
    }

    public void CreateSettingsLines (string Mode)
    {
        wallAndFloorsSprites = Resources.LoadAll<Sprite>("Images/WallpapersAndFloors");
        doorsSprites = Resources.LoadAll<Sprite>("Images/Doors");
        wallAndFloorsMaterials = Resources.LoadAll<Material>("WallpapersAndFloorsMaterials");
        doorsMaterials = Resources.LoadAll<Material>("DoorsMaterials");

        ClearSettingsLines();
        CreateSettingsColumns("Floor", "Настройка текстур полов:", "Выбор текстуры для пола '", wallAndFloorsSprites, Mode);
        CreateSettingsColumns("Wallpaper", "Настройка текстур обоев:", "Выбор текстуры для обоев '", wallAndFloorsSprites, Mode);
        CreateSettingsColumns("Door", "Настройка текстур дверей:", "Выбор материала для двери '", doorsSprites, Mode);
    }

    private void CreateSettingsColumns (string findName, string HeadLine1Text, string HeadLine2Text, Sprite[] sprites, string Mode)
    {
        GameObject parent = Mode == "ArMode" ? SettingsInARContentParent : Mode == "NormalMode" ? SettingsContentParent : SettingsInVRContentParent;

        Transform HeadLine1 = Instantiate(SettingHeadLine1Prefab).transform;
        HeadLine1.SetParent(parent.transform, false);
        HeadLine1.GetChild(0).GetComponent<TMP_Text>().text = HeadLine1Text;

        foreach(GameObject a in GameObject.FindGameObjectsWithTag(findName))
        //foreach(GameObject a in FlatPrefab.GameObject.FindGameObjectsWithTag(findName))
        {
            Transform HeadLine2 = Instantiate(SettingHeadLine2Prefab).transform;
            HeadLine2.SetParent(parent.transform, false);
            HeadLine2.GetChild(0).GetComponent<TMP_Text>().text = HeadLine2Text + a.name + "'";
            HeadLine2.GetChild(0).GetComponent<TMP_Text>().autoSizeTextContainer = true;

            GameObject MaterialScrollView = Instantiate(MaterialScrollViewPrefab);
            MaterialScrollView.transform.SetParent(parent.transform, false);
            GameObject MaterialContentParent = MaterialScrollView.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

            for(int j = 0; j < sprites.Length; j++)
            {
                int J = j;
                GameObject A1 = a;

                Transform column = Instantiate(MaterialColumnPrefab).transform;
                column.SetParent(MaterialContentParent.transform, false);
                column.GetChild(0).GetComponent<Image>().sprite = sprites[j];
                column.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { MaterialListener(A1, sprites[J].name); });
                column.GetChild(1).GetComponent<TMP_Text>().text = sprites[j].name;
            }

            GameObject A2 = a;
            Transform columnLast = Instantiate(NewMaterialSptitePrefab).transform;
            columnLast.SetParent(MaterialContentParent.transform, false);
            columnLast.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { setNewMaterial(A2); });
        }
    }

    private void MaterialListener (GameObject obj, string SpriteName)
    {
        MeshRenderer[] objFlatInArMode = ParentInArModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();//FlatPrefab.transform.GetComponentsInChildren<MeshRenderer>();
        MeshRenderer[] objFlatInVrMode = ParentInVrModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();
        MeshRenderer[] objFlatInNormalMode = ParentInNormalModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();

        Material[] materials;

        //Debug.Log("--------"+obj.name+"_____"+SpriteName);

        if(obj.tag == "Door")
            materials = doorsMaterials;
        else
            materials = wallAndFloorsMaterials;

        foreach(Material mat in materials)
        {
            //Debug.Log(mat.name+" "+ SpriteName);
            if(mat.name == SpriteName)
            {
                Debug.Log(mat.name);
                foreach(MeshRenderer b in objFlatInArMode)
                {
                    if((obj.name == b.gameObject.transform.parent.name && obj.tag == b.gameObject.transform.parent.tag) || (obj.name == b.gameObject.name && obj.tag == b.gameObject.tag))
                    {
                        b.material = mat;
                    }
                }
                foreach(MeshRenderer b in objFlatInVrMode)
                {
                    if(obj.name == b.gameObject.transform.parent.name || obj.name == b.gameObject.name && obj.tag == b.gameObject.tag)
                    {
                        b.material = mat;
                        //Debug.Log(obj.name);
                    }
                }
                foreach(MeshRenderer b in objFlatInNormalMode)
                {
                        //Debug.Log(obj.name+" "+ b.gameObject.transform.parent.name +" "+ obj.name +" " + b.gameObject.name +" "+ obj.tag == b.gameObject.tag);
                    if(obj.name == b.gameObject.transform.parent.name || obj.name == b.gameObject.name && obj.tag == b.gameObject.tag)
                    {
                        if((obj.name == b.gameObject.transform.parent.name && obj.tag == b.gameObject.transform.parent.tag) || (obj.name == b.gameObject.name && obj.tag == b.gameObject.tag))
                            b.material = mat;
                    }
                }
                break;
            }
        }
    }

    private void setNewMaterial (GameObject obj)
    {
        PickImage(1000, obj);
    }

    private void PickImage (int maxSize, GameObject obj)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if(path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if(texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                Material myNewMaterial = new Material(Shader.Find("Standard"));
                /*if(!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");*/

                myNewMaterial.SetTexture("_MainTex", texture);

                MeshRenderer[] objFlatInArMode = ParentInArModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();
                MeshRenderer[] objFlatInVrMode = ParentInVrModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();
                MeshRenderer[] objFlatInNormalMode = ParentInNormalModeWhereFlat.transform.GetComponentsInChildren<MeshRenderer>();

                foreach(MeshRenderer b in objFlatInArMode)
                {
                    if(obj.name == b.gameObject.name && obj.tag == b.gameObject.tag)
                    {
                        b.material = myNewMaterial;
                    }
                }
                foreach(MeshRenderer b in objFlatInVrMode)
                {
                    if(obj.name == b.gameObject.name && obj.tag == b.gameObject.tag)
                    {
                        b.material = myNewMaterial;
                    }
                }
                foreach(MeshRenderer b in objFlatInNormalMode)
                {
                    if(obj.name == b.gameObject.name && obj.tag == b.gameObject.tag)
                    {
                        b.material = myNewMaterial;
                    }
                }

                /*foreach(MeshRenderer b in obj.GetComponentsInChildren<MeshRenderer>())
                {
                    b.material = myNewMaterial;
                }*/
            }
        });

        Debug.Log("Permission result: " + permission);
    }
    public void _OpenOrCloseInfoSpaceInVR ()
    {
        InfoSpaceInVR.SetActive(!InfoSpaceInVR.activeSelf);
        MainSpaceInVR.SetActive(!MainSpaceInVR.activeSelf);
    }

    public void _OpenOrCloseInfoSpaceInAR ()
    {
        InfoSpaceInAR.SetActive(!InfoSpaceInAR.activeSelf);
        MainSpaceInAR.SetActive(!MainSpaceInAR.activeSelf);
    }

    public void _OpenOrCloseInfoSpace ()
    {
        InfoSpace.SetActive(!InfoSpace.activeSelf);
        MainSpace.SetActive(!MainSpace.activeSelf);

        if(InfoSpace.activeSelf)
        {
            ActiveInteractiveCamera.SetInteractive(false);
            ActiveInteractiveObject.SetInteractive(false);
        }
        else
        {
            if(!timeScrollBar.activeSelf)
            {
                ActiveInteractiveCamera.SetInteractive(true);
                ActiveInteractiveObject.SetInteractive(true);
            }
        }
    }

    public void _OpenOrCloseSettingsSpaceInVR ()
    {
        SettingsSpaceInVR.SetActive(!SettingsSpaceInVR.activeSelf);
        MainSpaceInVR.SetActive(!MainSpaceInVR.activeSelf);
    }

    public void _OpenOrCloseSettingsSpaceInAR ()
    {
        SettingsSpaceInAR.SetActive(!SettingsSpaceInAR.activeSelf);
        MainSpaceInAR.SetActive(!MainSpaceInAR.activeSelf);
    }

    public void _OpenOrCloseSettingsSpace ()
    {
        SettingsSpace.SetActive(!SettingsSpace.activeSelf);
        MainSpace.SetActive(!MainSpace.activeSelf);

        if(SettingsSpace.activeSelf)
        {
            ActiveInteractiveCamera.SetInteractive(false);
            ActiveInteractiveObject.SetInteractive(false);
        }
        else
        {
            if(!timeScrollBar.activeSelf)
            {
                ActiveInteractiveCamera.SetInteractive(true);
                ActiveInteractiveObject.SetInteractive(true);
            }
        }
    }

    public void _OpenOrCloseHelpSpace ()
    {
        HelpSpace.SetActive(!HelpSpace.activeSelf);
        MainSpace.SetActive(!MainSpace.activeSelf);

        if(HelpSpace.activeSelf)
        {
            ActiveInteractiveCamera.SetInteractive(false);
            ActiveInteractiveObject.SetInteractive(false);
        }
        else
        {
            if(!timeScrollBar.activeSelf)
            {
                ActiveInteractiveCamera.SetInteractive(true);
                ActiveInteractiveObject.SetInteractive(true);
            }
        }
    }

    public void _OpenOrCloseScrollBar (Image btnImageBG)
    {
        if(timeScrollBar.activeSelf == false)
            btnImageBG.color = new Color(1, 0.6572326f, 0.6572326f);
        else
            btnImageBG.color = Color.white;

        timeScrollBar.SetActive(!timeScrollBar.activeSelf);
        CameraManageObj.SetActive(!timeScrollBar.activeSelf);

        if(timeScrollBar.activeSelf == false)
            FurnitureManageObj.SetActive(lastState);
        else
        {
            lastState = FurnitureManageObj.activeSelf;
            FurnitureManageObj.SetActive(!timeScrollBar.activeSelf);
        }

        ActiveInteractiveCamera.SetInteractive(!timeScrollBar.activeSelf);
        ActiveInteractiveObject.SetInteractive(!timeScrollBar.activeSelf);
    }

    public void _OpenOrCloseFurnitureManageObj ()
    {
        FurnitureManageObj.SetActive(!FurnitureManageObj.activeSelf);
        //BGFurnitureManageObj.SetActive(FurnitureManageObj.activeSelf);
    }

    public void _OpenMainMenuScene ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
