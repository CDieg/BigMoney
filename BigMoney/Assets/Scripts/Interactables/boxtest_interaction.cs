using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtest : Interactable
{
    [SerializeField]
    private GameObject platform;
    private bool platformOpen;
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
        platformOpen = !platformOpen;
        platform.GetComponent<Animator>().SetBool("IsUp", platformOpen);
        Debug.Log("Raycasted" + gameObject.name);
        // Include here call to the animation of the interaction
    }
}
