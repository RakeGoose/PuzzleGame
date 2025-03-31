using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID = "Silver";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if(inventory != null)
            {
                inventory.AddKey(keyID);
                Destroy(gameObject);
            }
        }
    }

}
