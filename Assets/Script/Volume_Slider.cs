using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Slider : MonoBehaviour
{

    public void ChangeVol(float newValue)
    {
        float newVol = newValue;
        AudioListener.volume = newVol;

    }
}