using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardID = -1;

    public bool isConfigured;
    public Image defaultImage, imageForFlashEffect;
    public Sprite defaultSprite, flippedSprite;
  
    bool isCardFlipped;

    public void Setup(int _cardID,Sprite _defaultSprite, Sprite _flippedSprite)
    {
        cardID = _cardID;
        isConfigured = true;

        defaultSprite = _defaultSprite;
        flippedSprite = _flippedSprite;

        imageForFlashEffect.gameObject.SetActive(false);
        defaultImage.sprite = defaultSprite;
        isCardFlipped = false;
        gameObject.SetActive(true);
    }

    public void DisableMe()
    {
        cardID = -1;
        imageForFlashEffect.gameObject.SetActive(false);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        gameObject.SetActive(false);
        isConfigured = false;
        isCardFlipped = false;
    }

    public void Flip(bool playSFX)
    {
        if(isCardFlipped)
            return;

        if (playSFX)
            GameManager.instance.soundManager.PlayCardFlipSound();
        StartCoroutine(FlipMe(playSFX));
    }

    public void FlipBack(bool playSFX)
    {
        if (!isCardFlipped)
            return;


        if (playSFX)
            GameManager.instance.soundManager.PlayCardFlipSound();
        StartCoroutine(FlipMeBack());
    }

    public void ShowEffectOnMatch()
    {
        StartCoroutine(EffectOnCardMatch());
    }


    private IEnumerator FlipMe(bool checkOnCardFlip)
    {
        for (float i = 0f; i <= 180f; i += 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            if (i == 90f)
            {
                defaultImage.sprite = flippedSprite;
            }
            yield return new WaitForSeconds(0.01f);
        }
        
        isCardFlipped = true;
        yield return new WaitForSeconds(0.5f);
        
        if(checkOnCardFlip)
        GameManager.instance.CheckOnCardFlip(this);
      
    }

    private IEnumerator FlipMeBack()
    {

        for (float i = 180f; i >= 0f; i -= 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            if (i == 90f)
            {
                defaultImage.sprite = defaultSprite;
            }
            yield return new WaitForSeconds(0.01f);
        }

      
        isCardFlipped = false;
    }


    private IEnumerator EffectOnCardMatch()
    {
        imageForFlashEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DisableMe();
    }
}
