using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;

    public void Interact()
    {
        doorAnimator.SetTrigger("Interacted");
    }
}
