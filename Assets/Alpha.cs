using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    public TextMeshPro textmeshPro;
    
    public float aplha = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.faceColor = new Color(255,255,255, aplha);
    }
}
