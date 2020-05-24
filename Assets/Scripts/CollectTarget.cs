using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
