using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptFloating : MonoBehaviour
{

    public float floatSpeed = 2f;
    public float floatHeight = 0.1f;
    public float fadeSpeed = 5f;

    private SpriteRenderer sr;
    private Vector3 originalLocalPos;
    private float targetAlpha = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalLocalPos = transform.localPosition;

        Color c = sr.color;
        c.a = 0f;
        sr.color = c;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time + floatSpeed) * floatHeight;
        transform.localPosition = originalLocalPos + new Vector3(0f, offset, 0f);

        Color c = sr.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.unscaledDeltaTime * fadeSpeed);
        sr.color = c;
    }

    public void Show()
    {
        targetAlpha = 1f;
    }

    public void Hide()
    {
        targetAlpha = 0f;
    }
}
