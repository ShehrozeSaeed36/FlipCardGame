using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType
{
    TimeBase,
    TurnBase,
}
public enum SceneNames
{
    Menu,
    Gameplay,
}
public class Constant : MonoBehaviour
{
   public static int LevelNum
    {
        get
        {
            return PlayerPrefs.GetInt("LevelNum", 1);
        }
        set
        {
            PlayerPrefs.SetInt("LevelNum", value);
        }
    }


    public static int Score
    {
        get
        {
            return PlayerPrefs.GetInt("Score", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Score", value);
        }
    }



}
