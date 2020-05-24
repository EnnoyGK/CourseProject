using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }
}
