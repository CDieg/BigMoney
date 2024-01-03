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
    [SerializeField]
    private CanvasGroup health1;
    [SerializeField]
    private CanvasGroup health2;
    [SerializeField]
    private CanvasGroup health3;
    [SerializeField]
    private CanvasGroup health4;
    [SerializeField]
    private CanvasGroup health5;
    [SerializeField]
    private CanvasGroup health6;

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

    public void UpdateHealthUI(int status)
    {
        switch (status)
        {
            case 0:
                health1.alpha = 1;
                health2.alpha = 1;
                health3.alpha = 1;
                health4.alpha = 1;
                health5.alpha = 1;
                health6.alpha = 1;
                break;

            case 1:
                health1.alpha = 0;
                health2.alpha = 1;
                health3.alpha = 1;
                health4.alpha = 1;
                health5.alpha = 1;
                health6.alpha = 1;
                break;

            case 2:
                health1.alpha = 0;
                health2.alpha = 0;
                health3.alpha = 1;
                health4.alpha = 1;
                health5.alpha = 1;
                health6.alpha = 1;
                break;

            case 3:
                health1.alpha = 0;
                health2.alpha = 0;
                health3.alpha = 0;
                health4.alpha = 1;
                health5.alpha = 1;
                health6.alpha = 1;
                break;

            case 4:
                health1.alpha = 0;
                health2.alpha = 0;
                health3.alpha = 0;
                health4.alpha = 0;
                health5.alpha = 1;
                health6.alpha = 1;
                break;

            case 5:
                health1.alpha = 0;
                health2.alpha = 0;
                health3.alpha = 0;
                health4.alpha = 0;
                health5.alpha = 0;
                health6.alpha = 1;
                break;

            case 6:
                health1.alpha = 0;
                health2.alpha = 0;
                health3.alpha = 0;
                health4.alpha = 0;
                health5.alpha = 0;
                health6.alpha = 0;
                break;
        }
    }
}
