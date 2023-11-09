using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private CanvasGroup reload;

    void Start()
    {

    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
    public void reloadShow()
    {
        reload.alpha = 1;
    }

    public void reloadHide()
    {
        reload.alpha = 0;
    }
}
