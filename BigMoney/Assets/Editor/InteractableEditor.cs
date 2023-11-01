using UnityEditor;

[CustomEditor(typeof(Interactable), true)]

public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if (interactable.useEvents)
        {
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
            
        } else
        {
            // If no events, remove component
            if(interactable.GetComponent<InteractionEvent>() != null)
            {
                DestroyImmediate (interactable.GetComponent<InteractionEvent>());
            }
        }
        
    } 
}
