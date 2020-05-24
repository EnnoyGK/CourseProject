using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
       /* if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            Debug.Log("He's there");
            //gameObject.SetActive(false);
        }
        else
        {
           //gameObject.SetActive(true);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
