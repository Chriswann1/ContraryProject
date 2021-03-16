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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Retry()
    {
        player.transform.position = lastwaypoint;
        gameover.SetActive(false);
    }

    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
