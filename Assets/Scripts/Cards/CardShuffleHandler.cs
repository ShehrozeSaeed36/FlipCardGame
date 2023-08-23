using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffleHandler : MonoBehaviour
{
    public List<Card> allCards;
    public CardPicturesCollection cardPicturesCollection;
    //public 
    int cardsToShuffleCount = 0;
    int tempCardNo;
    public void ShuffleCards(int noOfImagesToMatch)
    {
        foreach (var item in allCards)
        {
            item.DisableMe();
        }

        for (int i = 0; i < noOfImagesToMatch; i++)
        {
            
            //do
            //{

            //} while (true);
        }
    }
}
