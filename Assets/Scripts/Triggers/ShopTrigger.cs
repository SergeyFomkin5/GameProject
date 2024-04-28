using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject PressE;
    public GameObject Shop;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PressE.SetActive(true);

            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PressE.SetActive(false);
            Shop.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            

            if (Input.GetKey(KeyCode.Escape))
            {
                Shop.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            PressE.SetActive(false);
        }
    }
}
