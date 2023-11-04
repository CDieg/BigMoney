using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Door : MonoBehaviour
{
    [SerializeField]
    private GameObject gate;
    [SerializeField]
    private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gate.GetComponent<Animator>().SetBool("gateUp", true);
            door.GetComponent<Animator>().SetBool("doorDown", true);
            gameObject.SetActive(false);            
        }
    }
}