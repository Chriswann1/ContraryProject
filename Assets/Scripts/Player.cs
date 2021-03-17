using Unity.Mathematics;
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
        if (GameplayManager.Instance.canMove)
        {
            #region Move
            
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            transform.Translate(input.normalized * Time.deltaTime * speed, 0f);

            if (input.normalized == Vector2.zero)
            {
                chickenrotate.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else
            {
                chickenrotate.transform.rotation = Quaternion.Euler(0,0,VectorToAngle(input)-90f);
            }
            #endregion
        }
        
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
    
    private float VectorToAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        return angle;
    }
    
}
