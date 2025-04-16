using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour
{

    private bool playerInRange = false;
    public DoorTrigger linkedDoor;

    private GameObject player;
    public GameObject VictoryUI;

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.W))
        {
            if(linkedDoor != null && linkedDoor.IsOpen())
            {
                Win();
            }
            else
            {
                Debug.Log("Door is not opened yet");
            }
        }
    }

    private void Win()
    {
        Debug.Log("Level complete");
        Animator anim = player.GetComponent<Animator>();
        if(anim != null)
        {
            anim.SetTrigger("EnterDoor");
            StartCoroutine(DestroyAfterAnimation(anim));
           
        }
        else
        {
            Destroy(player);
            ActivateVictoryUI();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }

    private void ActivateVictoryUI()
    {
        if(VictoryUI != null)
        {
            VictoryUI.SetActive(true);
        }
    }

    private IEnumerator DestroyAfterAnimation(Animator anim)
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(player);
        ActivateVictoryUI();
    }
}
