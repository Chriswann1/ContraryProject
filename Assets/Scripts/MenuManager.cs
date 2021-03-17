using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    /*public void Onclick_Play()
    {
        SceneManager.LoadScene(1);
    }*/
    public void OnClickLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Onclick_Exit()
    {
        Application.Quit(0);
    }
    public void Onclick_MuteSounds()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
