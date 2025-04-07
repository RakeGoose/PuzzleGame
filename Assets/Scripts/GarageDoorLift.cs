using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorLift : MonoBehaviour
{

    public string requiredKeyID = "Red";
    public float liftHeight = 3f;
    public float liftSpeed = 2f;

    private Vector3 targetPosition;
    private bool shouldOpen = false;
    private bool isOpening = false;
    private GameObject player;

    void Start()
    {
        targetPosition = transform.position + Vector3.up * liftHeight;   
    }

    private void Update()
    {
        if(player != null && !shouldOpen && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inv = player.GetComponent<PlayerInventory>();
            if(inv != null && inv.HasKey(requiredKeyID))
            {
                shouldOpen = true;
                Debug.Log("Door is opening");
            }
            else
            {
                Debug.Log("Key is required: " + requiredKeyID);
            }
        }

        if(shouldOpen && !isOpening)
        {
            isOpening = true;
        }

        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, liftSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            player = null;
        }
    }


}
