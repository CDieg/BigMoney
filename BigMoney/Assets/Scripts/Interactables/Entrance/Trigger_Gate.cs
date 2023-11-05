using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Door : MonoBehaviour
{
    [SerializeField]
    private GameObject gate;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private bool openGateTrigger = false;
    [SerializeField]
    private bool closeGateTrigger = false;
    [SerializeField]
    private bool closeElevatorTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openGateTrigger)
            {
                gate.GetComponent<Animator>().SetBool("gateOpen", true);
            }
            else if (!openGateTrigger)
            {
                gate.GetComponent<Animator>().SetBool("gateOpen", false);
            }

            if (closeGateTrigger)
            {
                gate.GetComponent<Animator>().SetBool("gateClose", true);
            }
            else if (!closeGateTrigger)
            {
                gate.GetComponent<Animator>().SetBool("gateClose", false);
            }


            if (closeElevatorTrigger)
            {
                door.GetComponent<Animator>().SetBool("doorDown", true);
                
            }
            else if (!closeElevatorTrigger)
            {
                door.GetComponent<Animator>().SetBool("doorDown", false);

            }

            gameObject.SetActive(false);
        }       
    }
}