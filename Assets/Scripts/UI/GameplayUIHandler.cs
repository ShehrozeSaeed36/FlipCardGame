using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIHandler : MonoBehaviour
{
    public GameObject levelCompleteScreen, levelFailScreen;
    public TMP_Text score, turns;
    public Image timer;

    private void Start()
    {
        UpdateScore();
    }
    public void UpdateContinuityTimer(float continuityTimerFillAmount)
    {
        timer.fillAmount = continuityTimerFillAmount;
    }

    public void UpdateScore()
    {
        score.text = Constant.Score.ToString();
    }
    

    public void UpdateTurnsCount(int remainingTurnsCount)
    {
        turns.text = remainingTurnsCount.ToString();
    }
    public void OnLevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        levelFailScreen.SetActive(false);
    }
    public void OnLevelFail()
    {
        levelFailScreen.SetActive(true);
        levelCompleteScreen.SetActive(false);
    }
    public void HomePressed()
    {
        GameManager.instance.GoHome();
    }

}
