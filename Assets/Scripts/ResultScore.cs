using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private int score = ScoringSystem.theScore;
    public GameObject resultText;

    private void Update()
    {
        resultText.GetComponent<Text>().text = "You have collected " + score + "/500 gold";
    }
}
