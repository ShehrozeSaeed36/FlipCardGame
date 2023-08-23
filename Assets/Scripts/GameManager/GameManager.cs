using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelManager levelManager;
    public SoundManager soundManager;
    public GameplayUIHandler gameplayUIHandler;

    public List<int> matchingCardsIdsList;
    public List<Card> cardsFlipped;
    private void Awake()
    {
        matchingCardsIdsList = new List<int>();
        cardsFlipped = new List<Card>();
        instance = this;
        LoadGame();
    }

    public void LoadGame()
    {
        cardsFlipped.Clear();
        matchingCardsIdsList.Clear();
        levelManager.LoadLevel();
    }

    public void GoHome()
    {
        SceneManager.LoadScene(SceneNames.Menu.ToString());
    }

    public void CheckOnCardFlip(Card recentFlippedCard)
    {
        cardsFlipped.Add(recentFlippedCard);

        if (cardsFlipped.Count > 1)
        {
            if (cardsFlipped[0].cardID == cardsFlipped[1].cardID)
            {
                if (matchingCardsIdsList.Contains(cardsFlipped[0].cardID))
                {
                    matchingCardsIdsList.Remove(cardsFlipped[0].cardID);
                }

                cardsFlipped[0].ShowEffectOnMatch();
                cardsFlipped[1].ShowEffectOnMatch();
                CheckLevelCompleteStatus();
            }
            else
            {
                cardsFlipped[0].FlipBack();
                cardsFlipped[1].FlipBack();
            }


            cardsFlipped.Remove(cardsFlipped[0]);
            cardsFlipped.Remove(cardsFlipped[0]);
        }
    
    }

    public bool CheckLevelCompleteStatus()
    {
        if (matchingCardsIdsList.Count == 0)
        {
            gameplayUIHandler.OnLevelComplete();
            return true;
        }

        return false;
    }
}