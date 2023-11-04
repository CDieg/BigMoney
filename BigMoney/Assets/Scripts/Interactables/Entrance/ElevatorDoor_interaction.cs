using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : Interactable
{
    [SerializeField]
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact() 
    {
        door.GetComponent<Animator>().SetBool("doorUp", true);
        Debug.Log("Raycasted" + gameObject.name);
    }
}
