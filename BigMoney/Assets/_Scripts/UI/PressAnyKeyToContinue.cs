using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyToContinue : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey) 
        {
            GameManager.instance.NextLevel();
        }
    }
}
