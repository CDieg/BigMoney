using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPrevention : MonoBehaviour
{
    private GameObject clipProjector;
    private float checkDistance;
    private Vector3 newDirection;

    private float lerpPos;
    private RaycastHit hit;
    void Update()
    {
        if (Physics.Raycast(clipProjector.transform.position, clipProjector.transform.forward, out hit, checkDistance))
        {
            // Get a percentaje from 0 to max distance
            lerpPos = 1 - (hit.distance / checkDistance);
        }
        else
        {
            lerpPos = 0;
        }

        Mathf.Clamp01(lerpPos);

        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(newDirection), lerpPos);
    }
}
