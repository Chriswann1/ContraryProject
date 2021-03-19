using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Videoplay : MonoBehaviour
{
    [SerializeField] private VideoPlayer splashscreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (splashscreen.length <= Time.time)
        {
            SceneManager.LoadScene(1);
        }
    }
}
