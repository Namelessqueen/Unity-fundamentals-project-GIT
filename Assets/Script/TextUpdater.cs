using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    int _objectiveInt;
    TextMeshProUGUI _text;
    public string _textString;
    public int MaxInt = 1;
    private void Start()
    {
         _text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(_text != null)_text.text = String.Format(_textString, _objectiveInt);
        if (_objectiveInt >= MaxInt) _text.fontStyle = FontStyles.Strikethrough;
    }

    public int ChangeObjectiveInt(int change)
    {
        return _objectiveInt += change;
    }
}
