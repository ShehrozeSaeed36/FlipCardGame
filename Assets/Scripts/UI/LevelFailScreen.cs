using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailScreen : MonoBehaviour
{
    public void Restart()
    {
        GameManager.instance.LoadGame();
        gameObject.SetActive(false);
    }
    public void GoHome()
    {
        GameManager.instance.GoHome();
    }

}
