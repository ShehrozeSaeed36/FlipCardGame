using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScreen : MonoBehaviour
{
    private void OnEnable()
    {
        Constant.LevelNum++;
    }

    public void Next()
    {
        GameManager.instance.LoadGame();
        gameObject.SetActive(false);
    }
    public void GoHome()
    {
        GameManager.instance.GoHome();
    }

}
