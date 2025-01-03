using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetActive_Swapper : MonoBehaviour
{
    public bool NoImputNeeded = false;
    public GameObject[] Objects;
    public TextUpdater TextUpdaterScript;
    public AudioSource _Audio;
    bool isActive = true;
    bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))isInside = true;
    }
    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player")) isInside = false;
    }

    private void Update()
    {
        if (isInside && (Input.GetKeyDown(KeyCode.E) || NoImputNeeded))
        {
            ChangeInt();
            PlayAudio();
            Activate();
        }
    }

    public void Activate()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            isActive ^= Objects[i].activeSelf;
            Objects[i].SetActive(isActive);
            isActive = true;
        }
    }

    public void PlayAudio()
    {
        if (_Audio != null) _Audio.Play();
    }

    public void ChangeInt()
    {
        if(TextUpdaterScript!= null)TextUpdaterScript.ChangeObjectiveInt(1);
    }
}
