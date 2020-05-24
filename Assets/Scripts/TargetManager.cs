using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject target;
    public GameObject exit;

    private void Update()
    {
        if (target)
        {
            Debug.Log("Active");
        }
        else
        {
            exit.SetActive(true);
        }
    }

}
