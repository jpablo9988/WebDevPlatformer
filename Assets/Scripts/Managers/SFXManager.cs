using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfx_Mixer;
    private void Awake()
    {
        sfx_Mixer = GetComponent<AudioSource>();
    }
    public void PlaySFX(AudioClip sfx)
    {
        sfx_Mixer.PlayOneShot(sfx);
    }
}
