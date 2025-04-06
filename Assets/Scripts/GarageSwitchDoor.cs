using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageSwitchDoor : MonoBehaviour
{

    public float liftHeight = 3f;
    public float liftSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * liftHeight;
    }

    void Update()
    {
        Vector3 target = isOpening ? openPosition : closedPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, liftSpeed * Time.deltaTime);
    }

    public void SetOpen(bool open)
    {
        isOpening = open;
    }
}
