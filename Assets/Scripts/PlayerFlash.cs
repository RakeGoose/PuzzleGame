using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{

    public float flashDuration = 0.15f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }


    public void FlashWhite()
    {
        Debug.Log("Flash");
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());

    }

    IEnumerator FlashRoutine()
    {
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSecondsRealtime(0.1f);
            spriteRenderer.color = originalColor;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
