using System;
using TMPro;
using UnityEngine;

public class TextDisplayer_Component : MonoBehaviour
{
    public event EventHandler<StringEventArgs> OnTextDisplayed;
    
    [SerializeField] private string prefix;
    
    private TextMeshProUGUI _textLabel;

    public void TryDisplayText(string textToDisplay)
    {
        if (!_textLabel)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        var displayedText = prefix + textToDisplay;
        _textLabel.text = displayedText;
        
        NotifyTextDisplayed(displayedText);
    }

    #region Auxiliary

    private void NotifyTextDisplayed(string displayedText)
    {
        var args = new StringEventArgs
        {
            StringValue = displayedText
        };
        OnTextDisplayed?.Invoke(this, args);
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        _textLabel = GetComponentInChildren<TextMeshProUGUI>();
        
        if (!_textLabel)
        {
            TryGetComponent(out _textLabel);
        }
    }

    #endregion
}
