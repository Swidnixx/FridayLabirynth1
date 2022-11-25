using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doorToOpen;
    public Key.KeyColor keyColor;
    bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            playerInRange = false;
        }
    }

    private void Update()
    {
       if( Input.GetKeyDown(KeyCode.E) && playerInRange )
       {
            bool playerHasProperKey = GameManager.Instance.CheckTheKey(keyColor);
            if (playerHasProperKey)
            {
                Open(); 
            }
       }
    }

    void Open()
    {
        foreach(DoorMechanim d in doorToOpen)
        {
            d.open = true;
        }
    }
}
