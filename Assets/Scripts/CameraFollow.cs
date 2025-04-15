using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public int pixelsPerUnit = 16;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);


        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);


        Vector3 smoothed = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / smoothSpeed);


        float unitsPerPixel = 1f / pixelsPerUnit;
        smoothed.x = Mathf.Round(smoothed.x / unitsPerPixel) * unitsPerPixel;
        smoothed.y = Mathf.Round(smoothed.y / unitsPerPixel) * unitsPerPixel;

        transform.position = smoothed;
    }
}
