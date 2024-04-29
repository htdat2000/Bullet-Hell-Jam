using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnedUtil;

public class AudioManager : MonoBehaviour
{
    [SerializeField] EnedAudioManager manager;
    [SerializeField] AudioClip sfxClip;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.manager.PlaySound(sfxClip, EnedAudioManager.eSoundType.SFX);
        }
    }
}
