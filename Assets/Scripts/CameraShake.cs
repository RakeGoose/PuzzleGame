using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    public float shakeAmount = 0.2f;
    private float shakeDuration = 0f;
    private Vector3 originalPosition;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        originalPosition = transform.localPosition;
    }


    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    public void Shake(float duration = 0.1f)
    {
        shakeDuration = duration;
    }
}
