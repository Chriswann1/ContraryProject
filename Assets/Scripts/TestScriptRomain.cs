using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestScriptRomain : MonoBehaviour
{
    public static TestScriptRomain Instance;

    public GameObject dialogueCoq;

    public TextMeshProUGUI txtDialogueCoq;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
