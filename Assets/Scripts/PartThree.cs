using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class PartThree : MonoBehaviour
{
    [SerializeField] private ScreenOrientation screenOrientation;

    [SerializeField] private Animator tapToPlay;
    [SerializeField] private RectTransform playerHook;
    private Vector3 posHook;
    [SerializeField] private Animator barrel;

    [SerializeField] private GameObject HUD;

    [SerializeField] private Animator canvas;
    [SerializeField] private RectTransform mainFoneImage;
    [SerializeField] private RectTransform playNowButton;
    [SerializeField] private Button finishButton;

    [SerializeField] private Animator _tutorial;

    private void Start()
    {
        //HUD.SetActive(true);
        posHook = new Vector3(184, -219.299988f, 0f);
        playerHook.gameObject.SetActive(true);
        tapToPlay.gameObject.SetActive(true);
        tapToPlay.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Tap to collect";
        tapToPlay.Play("Scale");
        //Invoke("Collect", 5);
        _tutorial.gameObject.GetComponent<RectTransform>().position = tapToPlay.gameObject.GetComponent<RectTransform>().position;
        Invoke("Tutorial", 5f);
    }

    private void FixedUpdate()
    {
        _tutorial.gameObject.GetComponent<RectTransform>().position = tapToPlay.gameObject.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        float h = Screen.height;
        float w = Screen.width;
        if (mainFoneImage.gameObject.activeSelf)
        {
            if (screenOrientation.isLandscape)
            {
                mainFoneImage.localScale = new Vector3(5f+ (-3.5f*(h / w)), 5f+ (-3.5f * (h / w)), 5f+ (-3.5f * (h / w)));
                playNowButton.localPosition = new Vector3(401, -190, 0);
            }
            else
            {
                mainFoneImage.localScale = new Vector3(1.6f+ (0.48f*(h / w)), 1.6f+ (0.48f * (h / w)), 1.6f+ (0.48f * (h / w)));
                playNowButton.localPosition = new Vector3(0, -476, 0);
                
            }
        }
        if(screenOrientation.isLandscape)
        {
            playerHook.transform.localPosition = new Vector3(posHook.x, posHook.y, posHook.z);
            playerHook.localScale = new Vector3(0.67f, 0.67f, 0.67f);
        }
        else
        {
            float h_hook = 784f;
            float h_hook_in_game = h_hook * (0.67f + (0.48f * (h / w)));

            playerHook.transform.localPosition = new Vector3(posHook.x, posHook.y - (h_hook_in_game/2), posHook.z);
            playerHook.localScale = new Vector3(0.67f + (0.48f * (h / w)), 0.67f + (0.48f * (h / w)), 0.67f + (0.48f * (h / w)));
        }
    }

    public void Collect()
    {
        if(mainFoneImage.gameObject.activeSelf == false && tapToPlay.gameObject.activeSelf == true)
        {
            _tutorial.gameObject.SetActive(false);
            _tutorial.SetBool("TapAnim", false);
            tapToPlay.gameObject.SetActive(false);
            barrel.Play("barrel");
            Invoke("FinishPlayble", 1f);
        }
    }

    public void FinishPlayble()
    {
        Destroy(_tutorial.gameObject);
        mainFoneImage.gameObject.SetActive(true);
        finishButton.gameObject.SetActive(true);
        canvas.Play("PlayNow");
    }

    private void Tutorial()
    {
        _tutorial.gameObject.SetActive(true);
        _tutorial.SetBool("TapAnim", true);
    }
}
