using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrompt : MonoBehaviour
{

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PromptFloating prompt = collision.transform.Find("Prompt")?.GetComponent<PromptFloating>();
            if(prompt != null)
            {
                prompt.Show();
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PromptFloating prompt = collision.transform.Find("Prompt")?.GetComponent<PromptFloating>();
            if(prompt != null)
            {
                prompt.Hide();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PromptFloating prompt = collision.transform.Find("Prompt")?.GetComponent<PromptFloating>();
            if (prompt != null)
            {
                prompt.Show();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PromptFloating prompt = collision.transform.Find("Prompt")?.GetComponent<PromptFloating>();
            if (prompt != null)
            {
                prompt.Hide();
            }
        }
    }

}
