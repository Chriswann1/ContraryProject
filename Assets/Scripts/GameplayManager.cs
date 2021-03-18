using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public Vector2 lastwaypoint;
    
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasGameOver;
    public Grid grid;
    [SerializeField] private Player player;

    [SerializeField] private GameObject tomb;
    public TextMeshProUGUI txtDialogueCoq;
    public GameObject dialogueCoq;
    [SerializeField] private SpriteRenderer spriteRend;
    
    public bool isgameoveron = false;
    private bool ispauseon = false;
    public bool inqte = false;
    public bool canMove = true;
    private bool isendlevel = false;

    private float leveltimesec;
    private int leveltimemin;
    [SerializeField] private TextMeshProUGUI timeUItext;

    [SerializeField] private GameObject EndLevelUI;
    [SerializeField] private TextMeshProUGUI endleveltimeUItext;

    private GameObject cam;
    private Vector3 campos;
    private Vector3 playerpos;
    private bool boolretry;
    private float timespend;
    private float speed = 2f;

    [SerializeField] AudioSource chickenSource;
    [SerializeField] AudioClip[] deathsongs;
    [SerializeField] AudioClip[] respawnsongs;

    
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
        if (!isendlevel)
        {
            leveltimesec = Time.timeSinceLevelLoad - (60*leveltimemin);
            if (leveltimesec >= 60)
            {
                leveltimemin++;
            }
            timeUItext.text = leveltimemin.ToString()+":"+leveltimesec.ToString("n2");
        }

        /*if (Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }*/

        if (Input.GetButtonDown("Cancel") &&  !isgameoveron && !ispauseon && !inqte && !isendlevel)
        {
            Pause();
        }else if (ispauseon && Input.GetButtonDown("Cancel"))
        {
            OnclickPlay();
        }

        if (boolretry)
        {
            float percent = timespend / speed;

            cam.transform.position = Vector3.Lerp(campos,playerpos,percent);

            if (percent >= 1)
            {
                cam.transform.SetParent(player.transform);
                cam.transform.localPosition = new Vector3(0, 0, -1);
                canMove = true;
                timespend = 0;
                boolretry = false;
                chickenSource.clip = respawnsongs[Random.Range(0, respawnsongs.Length)];
            }
            timespend += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        chickenSource.clip = deathsongs[Random.Range(0, deathsongs.Length)];
        isgameoveron = true;
        canvasGameOver.SetActive(true);
        Cursor.visible = true;
        spriteRend.enabled = false;
        Instantiate(tomb, player.transform.position, player.transform.rotation);
        Time.timeScale = 0;
    }

    public void EndLevel()
    {
        isendlevel = true;
        canMove = false;
        timeUItext.gameObject.SetActive(false);
        endleveltimeUItext.text = Mathf.RoundToInt(leveltimemin).ToString()+":"+leveltimesec.ToString("n2");
        EndLevelUI.SetActive(true);
        Cursor.visible = true;
        if (PlayerPrefs.GetInt("Level")<=SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    public void Pause()
    {
        ispauseon = true;
        canvasPause.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void Retry()
    {
        canMove = false;
        GameObject rotatechicken = player.transform.GetChild(0).gameObject;
        cam = player.transform.GetChild(1).gameObject;
        player.transform.DetachChildren();
        rotatechicken.transform.SetParent(player.transform);
        player.transform.position = lastwaypoint;
        playerpos = player.transform.position;
        playerpos.z = -1;
        campos = cam.transform.position;
        boolretry = true;
        
        canvasGameOver.SetActive(false);
        spriteRend.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        isgameoveron = false;
        ispauseon = false;
        player.stamina = 100f;
    }

    public void Backtomenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
        Cursor.visible = false;
        Time.timeScale = 1;
        ispauseon = false;

    }
}
