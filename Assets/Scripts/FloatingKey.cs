using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingKey : MonoBehaviour
{

    public float floatStrength = 0.5f;
    public float floatSpeed = 2f;
    public bool rotate = true;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + newY, initialPosition.z);
    }
}
