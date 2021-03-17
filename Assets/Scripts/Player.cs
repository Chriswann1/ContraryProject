using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject chickenrotate;

    [SerializeField] private float basespeed;
    private float finalspeed;
    [SerializeField] AudioSource audiochicken;
    [SerializeField] GameObject waypointexit;
    
    // Start is called before the first frame update
    void Start()
    {
        waypointexit = GameObject.FindWithTag("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayManager.Instance.canMove && !GameplayManager.Instance.inqte)
        {
            #region Move

            if (Input.GetKey(KeyCode.LeftShift))
            {
                finalspeed = basespeed * 2;
            }
            else
            {
                finalspeed = basespeed;
            }
            
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            transform.Translate(input.normalized * Time.deltaTime * finalspeed, 0f);

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

                audiochicken.panStereo =  -(transform.position.x - waypointexit.transform.position.x)  / 20;
                audiochicken.Play();
            }
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
