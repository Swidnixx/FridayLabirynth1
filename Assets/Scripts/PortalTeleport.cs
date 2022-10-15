using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform receiver;

    bool playerIsPassing;

    private void FixedUpdate()
    {
        Vector3 portalToPlayer = player.position - transform.position;

        Debug.DrawLine(transform.position, transform.position + transform.up);
        Debug.DrawLine(transform.position, transform.position + portalToPlayer, Color.green);
        if (playerIsPassing)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsPassing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsPassing = false;
        }
    }
}
