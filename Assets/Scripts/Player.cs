using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject chickenrotate;

    [SerializeField] private float speed;
    [SerializeField] AudioSource audiochicken;
    [SerializeField] GameObject waypointexit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Move
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        transform.Translate(input.normalized * Time.deltaTime * speed,0f);
        
        if (input.x >= 1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,-90); }
        if (input.x <= -1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,90); }
        if (input.y >= 1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,0); }
        if (input.y <= -1 && Time.timeScale != 0)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,180); }
        #endregion
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (waypointexit.transform.position.x - transform.position.x > 0)
            {
                audiochicken.panStereo = 1;
            }
            else
            {
                audiochicken.panStereo = -1;
            }
            audiochicken.Play();
        }
    }
}
