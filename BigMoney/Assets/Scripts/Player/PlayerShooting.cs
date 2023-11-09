using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f;

    public GameObject shotOrigin;

    private void Start()
    {

    }
    void Update()
    {
        
    }
    public void Fire1()
    {
        RaycastHit hit;

        if (Physics.Raycast(shotOrigin.transform.position, shotOrigin.transform.forward, out hit, range))
        {
            Debug.DrawLine(shotOrigin.transform.position, hit.point, Color.red, 10f);
        }
    }    
}
