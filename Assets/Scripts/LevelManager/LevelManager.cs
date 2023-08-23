using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CardsLayoutHandler cardsLayoutHandler;
    public CardShuffleHandler cardShuffleHandler;
    public void LoadLevel()
    {
        cardsLayoutHandler.AdjustCardsLayoutByLevelNumber(Constant.LevelNum);
        cardShuffleHandler.ShuffleCards(3);
    }
}
