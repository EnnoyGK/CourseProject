using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToggle : MonoBehaviour
{
    public static bool mapToggler = false;
    public GameObject ui;

    public void Toggle()
    {
        if (!mapToggler)
        {
            mapToggler = true;
            ui.SetActive(false);
        }
        else
        {
            mapToggler = false;
            ui.SetActive(true);
        }
    }
}
