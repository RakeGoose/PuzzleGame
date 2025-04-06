using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{

    public GarageSwitchDoor connectedDoor;

    private int objectsOnButton = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectsOnButton++;
            connectedDoor.SetOpen(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectsOnButton--;
            if(objectsOnButton <= 0)
            {
                connectedDoor.SetOpen(false);
            }
        }
    }

}
