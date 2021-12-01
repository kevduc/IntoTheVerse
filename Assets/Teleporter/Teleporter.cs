using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter destination;

    public bool teleportEnabled = true;

    private void Teleport(GameObject player)
    {
        destination.teleportEnabled = false;
        player.transform.position = destination.transform.position;
        // player.transform.rotation = destination.transform.rotation;
        Physics.SyncTransforms();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.teleportEnabled)
        {
            Teleport(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.teleportEnabled = true;
        }
    }
}
