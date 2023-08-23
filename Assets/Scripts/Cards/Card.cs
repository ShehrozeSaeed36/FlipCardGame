using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector]
    public int cardID = -1;

    public Image defaultImage;
    public Sprite defaultSprite, flippedSprite;

    bool isCardFlipped;

    public void Setup(int _cardID,Sprite _defaultSprite, Sprite _flippedSprite)
    {
        cardID = _cardID;

        
        defaultSprite = _defaultSprite;
        flippedSprite = _flippedSprite;


        defaultImage.sprite = defaultSprite;
        isCardFlipped = false;
        gameObject.SetActive(true);
    }

    public void DisableMe()
    {
        cardID = -1;
        gameObject.SetActive(false);
        isCardFlipped = false;
    }

    public void Flip()
    {
        if(isCardFlipped)
            return;

        StartCoroutine(FlipMe());
    }

    public void FlipBack()
    {
        if (!isCardFlipped)
            return;

        StartCoroutine(FlipMeBack());
    }

    public void ShowEffectOnMatch()
    {

    }


    private IEnumerator FlipMe()
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
        GameManager.instance.CheckOnCardFlip(this);
        GameManager.instance.soundManager.PlayCardFlipSound();
        isCardFlipped = true;
    }

    private IEnumerator FlipMeBack()
    {

        if (!isCardFlipped)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    defaultImage.sprite = defaultSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        GameManager.instance.soundManager.PlayCardFlipSound();
        isCardFlipped = false;
    }



}
