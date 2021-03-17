using UnityEngine;

public class Patroller : MonoBehaviour
{
    #region Move Variables
    [SerializeField] GameObject[] arraywaypoints = new GameObject[4];
    private float timespend;
    [SerializeField] private float speed;
    private bool move;
    private Vector2 position;
    private Vector2 target;
    int n = 1;
    Grid grid;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        grid = GameplayManager.Instance.grid;
        position = transform.position;
        target = arraywaypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        #region Patrol
        float percent = timespend / speed;
        if (percent > 1)
        { percent = 1; }
        
        //transform.position = Vector3.Lerp(position, target,percent);
        transform.position = Vector3.Lerp(grid.GetCellCenterWorld(grid.WorldToCell(position)), 
            grid.GetCellCenterWorld(grid.WorldToCell(target)),percent);

        if (percent >= 1)
        {
            if (Vector2.Distance(transform.position,arraywaypoints[arraywaypoints.Length-1].transform.position) < 0.5f)
            { n = 0; }
            position = transform.position;
            target = arraywaypoints[n].transform.position;
            n++;
            timespend = 0;
        }
        timespend += Time.deltaTime;
        LookToward(grid.GetCellCenterWorld(grid.WorldToCell(target)));
        
        #endregion
    }

    private void LookToward(Vector3 target) // the look toward function
    {
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90f, Vector3.forward);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chicken"))
        {
            GameplayManager.Instance.GameOver();
        }
    }
}
