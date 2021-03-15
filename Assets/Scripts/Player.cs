﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject chickenrotate;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Move
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        transform.Translate(input.normalized * Time.deltaTime * speed,0f);
        
        if (input.x >= 1)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,-90); }
        if (input.x <= -1)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,90); }
        if (input.y >= 1)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,0); }
        if (input.y <= -1)
        { chickenrotate.transform.rotation = Quaternion.Euler(0,0,180); }
        #endregion
        
    }
    
}
