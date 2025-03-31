using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string requiredKeyID = "Silver";
    public Sprite openSprite;

    private bool playerInRange = false;
    private GameObject player;
    private bool isOpen = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(playerInRange && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = player.GetComponent<PlayerInventory>();
            if(inventory != null && inventory.HasKey(requiredKeyID))
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("You Need a Key" + requiredKeyID);
            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        if(anim != null)
        {
            anim.SetBool("isOpen", true);
        }

        Debug.Log("Door is opened");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
