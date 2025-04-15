using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatforms : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void Break()
    {
        if (!hasFallen)
        {
            hasFallen = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("Platform broken");
        }
    }
}
