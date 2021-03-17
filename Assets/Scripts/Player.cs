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
        if (GameplayManager.Instance.canMove == true)
        {
            #region Move
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            transform.Translate(input.normalized * Time.deltaTime * speed, 0f);

            if (input.x >= 1 && Time.timeScale != 0)
            { chickenrotate.transform.rotation = Quaternion.Euler(0, 0, -90); }
            if (input.x <= -1 && Time.timeScale != 0)
            { chickenrotate.transform.rotation = Quaternion.Euler(0, 0, 90); }
            if (input.y >= 1 && Time.timeScale != 0)
            { chickenrotate.transform.rotation = Quaternion.Euler(0, 0, 0); }
            if (input.y <= -1 && Time.timeScale != 0)
            { chickenrotate.transform.rotation = Quaternion.Euler(0, 0, 180); }
            #endregion
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            audiochicken.Play();
        }
    }
    
}
