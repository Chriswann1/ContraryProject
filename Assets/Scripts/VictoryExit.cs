using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chicken"))
        {
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                GameplayManager.Instance.Victory();
            }
            else
            {
                GameplayManager.Instance.EndLevel();
            }
        }
    }
}
