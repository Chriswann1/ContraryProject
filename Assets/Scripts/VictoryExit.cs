using UnityEngine;

public class VictoryExit : MonoBehaviour
{
    [SerializeField] private string loadscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            GameplayManager.Instance.LoadLevel(loadscene);
        }
    }
}
