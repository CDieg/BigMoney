using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // Create a ray from the center of the camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
        // Debug
        Debug.DrawRay(ray.origin, ray.direction * distance);
        
        
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
