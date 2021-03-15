using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] GameObject[] arraywaypoints = new GameObject[4];
    private float timespend;
    [SerializeField] private float speed;
    private bool move;

    private Vector2 position;
    private Vector2 target;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        target = arraywaypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float percent = timespend / speed;
        if (percent > 1)
        {
            percent = 1;
        }
        transform.position = Vector3.Lerp(position, target,percent);
        if (percent >= 1)
        {
            
        }
        timespend += Time.deltaTime;
    }
}
