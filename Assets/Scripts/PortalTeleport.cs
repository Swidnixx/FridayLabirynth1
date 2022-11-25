using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [HideInInspector] public Transform player;
    [HideInInspector] public Transform receiver;

    bool playerIsPassing;

    private void FixedUpdate()
    {
        Vector3 portalToPlayer = player.position - transform.position;

        Debug.DrawLine(transform.position, transform.position + transform.up);
        Debug.DrawLine(transform.position, transform.position + portalToPlayer, Color.green);
       // Debug.Log("Dot: " + Vector3.Dot(transform.up, portalToPlayer));

        if (playerIsPassing)
        {
            float dot = Vector3.Dot(transform.up, portalToPlayer);
            if(dot < 0)
            {
                player.position = receiver.position;
                player.forward = receiver.up;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
            playerIsPassing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Exit Collision");
            playerIsPassing = false;
        }
    }
}
