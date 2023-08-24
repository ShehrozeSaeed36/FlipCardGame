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

    public int noOfTurnsForLevel;
    float continuityTimer = 0;
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

        if (cardsFlipped.Count % 2 == 0)
        {
            noOfTurnsForLevel--;
        }

        if (cardsFlipped.Count > 1)
        {
            if (cardsFlipped[0].cardID == cardsFlipped[1].cardID)
            {
                if (matchingCardsIdsList.Contains(cardsFlipped[0].cardID))
                {
                    matchingCardsIdsList.Remove(cardsFlipped[0].cardID);
                }
                //Debug.LogError("Cards Matched");
                cardsFlipped[0].ShowEffectOnMatch();
                cardsFlipped[1].ShowEffectOnMatch();

                
                if (continuityTimer <= 0)
                {
                    Constant.Score += 100;
                    continuityTimer = 5;
                    StartCoroutine(CheckContinuityTimer());
                }
                else
                {
                    Constant.Score += 200;
                    continuityTimer = 5;
                }

                gameplayUIHandler.UpdateScore();
                CheckLevelCompleteStatus();
            }
            else
            {
                //Debug.LogError("Cards Not Matched");
                cardsFlipped[0].FlipBack(true);
                cardsFlipped[1].FlipBack(true);

            }

            cardsFlipped.Remove(cardsFlipped[0]);
            cardsFlipped.Remove(cardsFlipped[0]);

        }

        if (noOfTurnsForLevel <= 0)
        {
            gameplayUIHandler.OnLevelFail();
        }

        
        gameplayUIHandler.UpdateTurnsCount(noOfTurnsForLevel);
    }


    IEnumerator CheckContinuityTimer()
    {
        do
        {
            continuityTimer -= 0.01f;
            gameplayUIHandler.UpdateContinuityTimer(continuityTimer/5);
            yield return new WaitForSeconds(0.01f);

        } while (continuityTimer>0);
        continuityTimer = 0;
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