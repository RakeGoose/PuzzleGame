using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID = "Silver";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if(inventory != null)
            {
                inventory.AddKey(keyID);
                
            }

            PlayerFlash flash = other.GetComponent<PlayerFlash>();
            if(flash !=null)
            {
                flash.FlashWhite();
            }

            Destroy(gameObject);
        }
    }

}
