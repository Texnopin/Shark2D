using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralControl : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;

    public void Complite(GameObject part)
    {
        switch (part.name)
        {
            case "Part1":
                parts[0].SetActive(false);
                parts[1].SetActive(true);
                break;
            case "Part2":
                parts[1].SetActive(false);
                parts[2].SetActive(true);
                break;
            case "Part3":
                parts[2].SetActive(false);
                parts[3].SetActive(true);
                break;
        }
    }
}
