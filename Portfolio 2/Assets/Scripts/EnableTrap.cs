using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrap : MonoBehaviour
{

    public GameObject ButtonPanelOn = null;

    public Animator TrapAnim;

    float TrapSpeed;

    void Start()
    {
        ButtonPanelOn.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ButtonPanelOn.SetActive(true);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ButtonPanelOn.SetActive(false);
        }

    }

    private bool IsButtonPanelOnActive
    {
        get
        {
            return ButtonPanelOn.activeInHierarchy;
        }
    }

    void Update()
    {
        if (IsButtonPanelOnActive)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ButtonPanelOn.SetActive(false);
                TrapAnim.speed = 1;
            }
        }

    }
}
