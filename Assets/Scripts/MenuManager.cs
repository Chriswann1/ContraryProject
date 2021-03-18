using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{

    public GameObject panelCredits;
    public static MenuManager Instance;
    public Button[] levelsButtons;
    [SerializeField] private VideoPlayer splashscreen;
    [SerializeField] private GameObject canvas;

    public void OnClickLevel(int level)
    {
        SceneManager.LoadScene(level);
        for (int i = 0; i < PlayerPrefs.GetInt("Level")-1; i++)
        {
            levelsButtons[i].interactable = true;
        }
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            panelCredits.SetActive(false);
        }

        if (splashscreen.length <= Time.time)
        {
            canvas.SetActive(true);
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
