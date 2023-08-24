using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffleHandler : MonoBehaviour
{
    public List<Card> allCards;
    public CardPicturesCollection cardPicturesCollection;

    List<int> cardIDs =  new List<int>();
    int tempCardNo;
    Card tempCardForConfiguration;
   
    public void ShuffleCards(int noOfImagesToMatch)
    {
        cardIDs.Clear();
        foreach (var item in allCards)
        {
            item.DisableMe();
        }

        for (int i = 0; i < noOfImagesToMatch; i++)
        {

            do
            {
                tempCardNo = cardPicturesCollection.allCardPictures[Random.Range(0, cardPicturesCollection.allCardPictures.Count)].cardPictureID;
            } while (cardIDs.Contains(tempCardNo));

            cardIDs.Add(tempCardNo);
            GameManager.instance.matchingCardsIdsList.Add(tempCardNo);

            for (int j = 0; j < 2; j++)
            {
                do
                {
                    tempCardForConfiguration = allCards[Random.Range(0, allCards.Count)];
                } while (tempCardForConfiguration.isConfigured);
                tempCardForConfiguration.Setup(cardPicturesCollection.allCardPictures[tempCardNo-1].cardPictureID, cardPicturesCollection.allCardPictures[tempCardNo-1].cardDefaultSprite, cardPicturesCollection.allCardPictures[tempCardNo-1].cardPictureSprite);
                tempCardForConfiguration.Flip(false);
            }


        }

        Invoke(nameof(FlippAllCardsBack),1f);
       
    }

    void FlippAllCardsBack()
    {
        foreach (var item in allCards)
        {
            if (item.isConfigured)
            {
                item.FlipBack(false);
            }

        }
    }
}
