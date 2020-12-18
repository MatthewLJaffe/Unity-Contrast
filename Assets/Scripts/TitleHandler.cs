using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHandler : MonoBehaviour
{

    [SerializeField] private RawImage titleImage;
    [SerializeField] private Sprite blackOnWhite; // Black on white
    [SerializeField] private Sprite whiteOnBlack; // White on black


    private void Update()
    {
        // move camera here
    }

    public void StartButtonClicked()
    {
        GameHandler.Instance.StartButtonClicked();
    }

    public void ExitButtonClicked()
    {
        GameHandler.Instance.ExitButtonClicked();
    }

    public void CreditButtonClicked()
    {
        GameHandler.Instance.CreditButtonClicked();
    }
    public void ReturnButtonClicked()
    {
        GameHandler.Instance.ReturnButtonClicked();
    }
}
