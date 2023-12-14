using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Add or remove an InteractionEvent component tothis gameobject
    public bool useEvents;

    // Message displayed when looking interactable
    [SerializeField]
    public string promptMessage;

    // This will be called from player
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }
    
    protected virtual void Interact()
    {

    }


}
