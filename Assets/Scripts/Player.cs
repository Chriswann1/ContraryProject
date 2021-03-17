using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject chickenrotate;

    [SerializeField] private float speed;
    [SerializeField] private AudioSource audiochicken;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Move
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        transform.Translate(input.normalized * Time.deltaTime * speed);
        /*
        if (input.x >= 1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,-90); }
        if (input.x <= -1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,90); }
        if (input.y >= 1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,0); }
        if (input.y <= -1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,180); }
*/
        if (input.normalized == Vector2.zero)
        {
            chickenrotate.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            chickenrotate.transform.rotation = Quaternion.Euler(0,0,VectorToAngle(input)-90f);
        }
        
        #endregion
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            audiochicken.Play();
        }
    }
    
    private float VectorToAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        return angle;


    }
    
}
