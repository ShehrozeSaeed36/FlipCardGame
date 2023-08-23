using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIHandler : MonoBehaviour
{
    public GameObject levelCompleteScreen, levelFailScreen;
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
