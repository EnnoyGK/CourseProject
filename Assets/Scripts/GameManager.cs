using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject hudContainer;
    public GameObject restartMenu;
    bool gameHasEnded = false;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("Game Over");
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            hudContainer.SetActive(false);
            restartMenu.SetActive(true);
        }
    }

     public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoringSystem.theScore = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
