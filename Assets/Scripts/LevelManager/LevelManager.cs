using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class LevelMeta
{
    public int noOfTurns;
    public int cardPicturesCountToMatchByLevelNum;
}
public class LevelManager : MonoBehaviour
{
    public List<LevelMeta> levelMetas;
    public CardsLayoutHandler cardsLayoutHandler;
    public CardShuffleHandler cardShuffleHandler;
    public void LoadLevel()
    {
        cardsLayoutHandler.ToggleGridLayout(true);
        cardsLayoutHandler.AdjustCardsLayoutByLevelNumber(Constant.LevelNum);
        GameManager.instance.noOfTurnsForLevel = levelMetas[Constant.LevelNum - 1].noOfTurns;
        GameManager.instance.gameplayUIHandler.UpdateTurnsCount(GameManager.instance.noOfTurnsForLevel);

        cardShuffleHandler.ShuffleCards(levelMetas[Constant.LevelNum-1].cardPicturesCountToMatchByLevelNum);
        Invoke(nameof(ActionsAfterLevelLoad),2);
    }

    void ActionsAfterLevelLoad()
    {
        cardsLayoutHandler.ToggleGridLayout(false);
    }
}
