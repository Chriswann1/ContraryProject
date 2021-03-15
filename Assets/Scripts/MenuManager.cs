using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public void Onclick_Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Onclick_Exit()
    {
        Application.Quit(0);
    }

    public void Onclick_MuteSounds()
    {
        AudioListener.pause = true;
    }
}
