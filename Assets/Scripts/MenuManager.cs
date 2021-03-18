using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject panelCredits;
    public static MenuManager Instance;
    public Button[] levelsButtons;

    public void OnClickLevel(int level)
    {
        SceneManager.LoadScene(level);
        for (int i = 0; i < PlayerPrefs.GetInt("Level")-1; i++)
        {
            levelsButtons[i].interactable = true;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            panelCredits.SetActive(false);
        }
    }

    public void OnClickShowCredits()
    {
        panelCredits.SetActive(true);
    }
    public void Onclick_Exit()
    {
        Application.Quit(0);
        Debug.Log("Game is closed");
    }
    public void Onclick_MuteSounds()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
