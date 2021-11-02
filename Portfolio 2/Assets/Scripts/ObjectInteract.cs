using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public GameObject GearPanel = null;
    public GameObject EquipPanel = null;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GearPanel.SetActive(false);
            EquipPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GearPanel.SetActive(true);
        }
    }

    private bool IsGearPanelActive
    {
        get
        {
            return GearPanel.activeInHierarchy;
        }
    }

    void Update()
    {
        if (IsGearPanelActive)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                GearPanel.SetActive(false);
                EquipPanel.SetActive(true);
                Destroy(gameObject);

            }
        }
    }

}
