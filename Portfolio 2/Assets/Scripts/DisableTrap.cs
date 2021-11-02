using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTrap : MonoBehaviour
{
    public GameObject ButtonPanel = null;

    public Animator TrapAnimator;

    float animspeed;

    void Start()
    {
        ButtonPanel.SetActive(false);
        animspeed = TrapAnimator.speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ButtonPanel.SetActive(true);
        }
        
    }

    private bool IsButtonPanelActive
    {
        get
        {
            return ButtonPanel.activeInHierarchy;
        }
    }

    void Update()
    {
        if (IsButtonPanelActive)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ButtonPanel.SetActive(false);
                TrapAnimator.speed = 0;
            }
        }

    }
}
