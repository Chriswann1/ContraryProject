using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public Vector2 lastwaypoint;
    
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasGameOver;
    public Grid grid;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject tomb;

    [SerializeField] private SpriteRenderer spriteRend;

    public bool canMove = true;

    
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
            Pause();
        }
    }

    public void GameOver()
    {
        canvasGameOver.SetActive(true);
        Cursor.visible = true;
        spriteRend.enabled = false;
        Instantiate(tomb, player.transform.position, player.transform.rotation);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        canvasPause.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void Retry()
    {
        player.transform.position = lastwaypoint;
        canvasGameOver.SetActive(false);
        spriteRend.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void OnclickPlay()
    {
        canvasPause.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 1;
    }
}
