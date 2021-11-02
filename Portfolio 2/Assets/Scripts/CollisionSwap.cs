using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSwap : MonoBehaviour
{

    public Camera Playercam;
    public Camera Cameraswitch;

    private void Start()
    {
        Cameraswitch.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Cameraswitch.enabled = true;
        Playercam.enabled = false;

    }

    private void OnTriggerExit(Collider other)
    {
        Playercam.enabled = true;
        Cameraswitch.enabled = false;
    }
}
