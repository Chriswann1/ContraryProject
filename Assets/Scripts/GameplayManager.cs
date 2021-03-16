using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public Vector2 lastwaypoint;


    [SerializeField] private GameObject gameover;
    public Grid grid;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject canvasPause;
    

    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        lastwaypoint = player.transform.position;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void GameOver()
    {
        gameover.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        player.transform.position = lastwaypoint;
        gameover.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnclickPlay()
    {
        canvasPause.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public void OnclickMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
