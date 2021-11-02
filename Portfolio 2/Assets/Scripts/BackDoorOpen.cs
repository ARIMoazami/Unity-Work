using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorOpen : MonoBehaviour
{
    private Animator BackDoorAnimator;
    public GameObject OpenPanel = null;

    bool Text = true;

    // Start is called before the first frame update
    void Start()
    {
        BackDoorAnimator = GetComponent<Animator>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BackDoorAnimator.SetBool("open", false);
            OpenPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenPanel.SetActive(true);
        }
    }

    //checking to see if the panel is active in heirarchy
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (IsOpenPanelActive)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                OpenPanel.SetActive(false);
                BackDoorAnimator.SetBool("open", true);
                Text = false;
            }
        }

        if (!Text)
        {
            OpenPanel.SetActive(false);
        }
    }
}
