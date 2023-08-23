using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject mainPanel, loadingScreen;

    public void Start()
    {

    }

    public void Play()
    {
        mainPanel.SetActive(false);
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(SceneNames.Gameplay.ToString());
    }

}
