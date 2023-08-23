using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource cardFlipSfx;
    public AudioSource cardFlipBackSfx;
    public AudioSource cardMatchSfx;
    public AudioSource cardNotMatchSfx;

    public void PlayCardFlipSound()
    {
        cardFlipSfx.Play();
    }
    public void PlayCardFlipBackSound()
    {
        cardFlipBackSfx.Play();
    }
    public void PlayCardMatchSound()
    {
        cardMatchSfx.Play();
    }

    public void PlayCardNotMatchSound()
    {
        cardNotMatchSfx.Play();
    }

}
