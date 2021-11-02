using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    private Animator DoorAnimator;

    public GameObject OpenPanel = null;
    public GameObject TopGearDoor;
    public GameObject EquipPanel = null;
    public GameObject Gear;

    public bool Text = true;

    // Start is called before the first frame update
    void Start()
    {
        DoorAnimator = GetComponent<Animator>();
    }

    void OnTriggerExit(Collider other)
    {
      DoorAnimator.SetBool("open", false);
      OpenPanel.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        OpenPanel.SetActive(true);
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

        if (IsOpenPanelActive && Gear == null)
        {
          if (Input.GetKeyDown(KeyCode.P))
           {
            OpenPanel.SetActive(false);
            DoorAnimator.SetBool("open", true);
            TopGearDoor.SetActive(true);
            EquipPanel.SetActive(false);
                Text = false;
           }
        }

        if (!Text)
        {
            OpenPanel.SetActive(false);
        }
    }

}
