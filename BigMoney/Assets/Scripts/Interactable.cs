using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Message displayed when looking interactable
    public string promptMessage;

    // This will be called from player
    public void BaseInteract()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {

    }


}
