using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyToStart : MonoBehaviour
{
    [SerializeField]
    private MainMenu menu;

    private void Update()
    {
        if (Input.anyKey) { menu.PlayGame(); }
    }
}
