using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{

    public GarageSwitchDoor connectedDoor;

    public float pressOffset = 0.1f;
    public float pressSpeed = 5f;

    private int objectsOnButton = 0;
    private Vector3 originalPosition;
    private Vector3 pressedPosition;

    void Start()
    {
        originalPosition = transform.position;
        pressedPosition = originalPosition + Vector3.down * pressOffset;
    }

    void Update()
    {
        Vector3 targetPos = (objectsOnButton > 0) ? pressedPosition : originalPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, pressSpeed * Time.deltaTime);
    }

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
