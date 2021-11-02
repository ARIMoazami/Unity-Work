using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject EndText;
    void Start()
    {
        EndText.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        EndText.SetActive(true);

    }
}
