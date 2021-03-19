using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject panelCredits;
    public static MenuManager Instance;
    [SerializeField] private Image mutebutton;
    [SerializeField] private Sprite[] muteimages;
    public Button[] levelsButtons;

    public void OnClickLevel(int level)
    {
        SceneManager.LoadScene(level);

    }

    public void Start()
    {
        for (int i = 1; i < levelsButtons.Length; i++)
        {
            levelsButtons[i].interactable = false;
        }

    
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        
        for (int i = 1; i < PlayerPrefs.GetInt("Level"); i++)
        {
            Debug.Log(PlayerPrefs.GetInt("Level"));
            levelsButtons[i].interactable = true;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            CloseCredits();
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
        if (AudioListener.pause)
        {
            mutebutton.sprite = muteimages[1];
        }
        else
        {
            mutebutton.sprite = muteimages[0];
        }
    }

    public void CloseCredits()
    {
        panelCredits.SetActive(false);
    }

    public void resetprogression()
    {
        for (int i = 1; i < levelsButtons.Length; i++)
        {
            levelsButtons[i].interactable = false;
        }
        PlayerPrefs.SetInt("Level", 1);
        
        for (int i = 1; i < PlayerPrefs.GetInt("Level"); i++)
        {
            Debug.Log(PlayerPrefs.GetInt("Level"));
            levelsButtons[i].interactable = true;
        }

    }
}
