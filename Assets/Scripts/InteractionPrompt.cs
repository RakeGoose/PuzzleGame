using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{

    public SpriteRenderer promptIcon;
    public Sprite spriteE;
    public Sprite spriteW;
    public DoorTrigger door;
    

    public void ShowPrompt(bool show, bool doorIsOpen)
    {
        promptIcon.enabled = show;

        if (show)
        {
            promptIcon.sprite = doorIsOpen ? spriteE : spriteW;
        }
    }
}
