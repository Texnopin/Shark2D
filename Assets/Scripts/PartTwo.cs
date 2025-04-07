using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartTwo : MonoBehaviour
{
    [SerializeField] private GeneralControl Controller;
    [SerializeField] private ScreenOrientation screenOrientation;
    [SerializeField] private GameObject foundation;

    [SerializeField] private Animator iconWood;
    [SerializeField] private Animator buttonsSpawn;
    [SerializeField] private Animator garbage;
    [SerializeField] private Animator tapToPlay;
    [SerializeField] private Animator success;
    [SerializeField] private TMPro.TextMeshProUGUI success_text;
    [SerializeField] private Animator outOfMaterial;

    [SerializeField] private GameObject HUD;

    [SerializeField] private GameObject water;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject stairs;

    private Button _buttonWater;
    private Button _buttonFire;
    private Button _buttonDoor;
    private Button _buttonStairs;

    [SerializeField] private GameObject objSpawnWhenPressWater;
    [SerializeField] private GameObject objSpawnWhenPressFire;
    [SerializeField] private GameObject objSpawnWhenPressDoor;
    [SerializeField] private GameObject objSpawnWhenPressStairs;

    [SerializeField] private GameObject select_1;
    [SerializeField] private GameObject select_2;
    [SerializeField] private GameObject select_3;

    private void Start()
    {

        HUD.SetActive(true);
        _buttonWater = water.GetComponent<Button>();
        _buttonFire = fire.GetComponent<Button>();
        _buttonDoor = door.GetComponent<Button>();
        _buttonStairs = stairs.GetComponent<Button>();

        buttonsSpawn.Play("ButtonSpawn");
        garbage.Play("red_Indication");

        tapToPlay.gameObject.SetActive(true);
        tapToPlay.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "You need food and water!";
        tapToPlay.Play("Scale");

        Invoke("ShowObjWhenPressWater", 5f);
    }

    private void Update()
    {
        if(screenOrientation.isLandscape)
        {
            foundation.transform.localScale = Vector3.one;
        }
        else
        {
            foundation.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }

    public void ShowObjWhenPressWater()
    {
        if(objSpawnWhenPressFire.activeSelf == false && objSpawnWhenPressWater.activeSelf == false)
        {
            tapToPlay.gameObject.SetActive(false);
            objSpawnWhenPressWater.SetActive(true);
            water.SetActive(false);
            fire.SetActive(false);
            door.SetActive(true);
            stairs.SetActive(true);
            select_1.SetActive(false);
            select_2.SetActive(true);
            iconWood.Play("WasteOfResources");
            Invoke("GoodChoise", 0.1f);
            Invoke("NextChoise", 1f);
            Invoke("ShowObjWhenPressDoor", 6f);
        }
    }

    public void ShowObjWhenPressFire()
    {
        tapToPlay.gameObject.SetActive(false);
        objSpawnWhenPressFire.SetActive(true);
        water.SetActive(false);
        fire.SetActive(false);
        door.SetActive(true);
        stairs.SetActive(true);
        select_1.SetActive(false);
        select_2.SetActive(true);
        iconWood.Play("WasteOfResources");
        Invoke("GoodChoise", 0.1f);
        Invoke("NextChoise", 1f);
        Invoke("ShowObjWhenPressStairs", 6f);
    }

    public void ShowObjWhenPressDoor()
    {
        if(objSpawnWhenPressStairs.activeSelf == false && objSpawnWhenPressDoor.activeSelf == false)
        {
            objSpawnWhenPressDoor.SetActive(true);
            select_2.SetActive(false);
            select_3.SetActive(true);
            _buttonDoor.interactable = false;
            _buttonStairs.interactable = false;
            iconWood.Play("WasteOfResources_1");
            iconWood.Play("EmptyWoodResources");
            buttonsSpawn.Play("idle");
            Invoke("WellDone", 0.1f);
            Invoke("NextChoise", 1.2f);
            Invoke("OutOfMaterial", 1.5f);
        }
    }

    public void ShowObjWhenPressStairs()
    {
        if(objSpawnWhenPressDoor.activeSelf == false && objSpawnWhenPressStairs.activeSelf == false)
        {
            objSpawnWhenPressStairs.SetActive(true);
            select_2.SetActive(false);
            select_3.SetActive(true);
            _buttonDoor.interactable = false;
            _buttonStairs.interactable = false;
            iconWood.Play("WasteOfResources_1");
            iconWood.Play("EmptyWoodResources");
            buttonsSpawn.Play("idle");
            Invoke("WellDone", 0.1f);
            Invoke("NextChoise", 1.2f);
            Invoke("OutOfMaterial", 1.5f);
        }
    }

    public void GoodChoise()
    {
        success.gameObject.SetActive(true);
        success_text.text = "Good choiñe!";
        success.Play("Success");
    }
    public void WellDone()
    {
        success.gameObject.SetActive(true);
        success_text.text = "Well done!";
        success.Play("Success");
    }

    public void NextChoise()
    {
        success.Play("idleSuccess");
        success.gameObject.SetActive(false);
    }

    public void OutOfMaterial()
    {
        outOfMaterial.gameObject.SetActive(true);
        outOfMaterial.Play("outOfMaterial");
        Invoke("NextPart", 1f);
    }

    public void NextPart()
    {
        outOfMaterial.gameObject.SetActive(false);
        HUD.SetActive(false);
        Controller.Complite(this.gameObject);
    }
}
