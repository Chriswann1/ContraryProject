using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Script : MonoBehaviour
{
    #region variables
    [SerializeField] private KeyCode inputedKey;
    [SerializeField] private KeyCode[] thisKey;
    private AudioClip thisAudio;
    public GameObject displayImgTouch;
    public Text inputTxt;
    
    private bool goodKey;

    #region  ImgVariables
    
    [SerializeField]private Image imgZ;
    [SerializeField]private Image imgQ;
    [SerializeField]private Image imgS;
    [SerializeField]private Image imgD;
    [SerializeField]private Image imgA;
    [SerializeField]private Image imgE;
    #endregion

    public float maxTime = 4f; 
    private float qteDelay;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        qteDelay = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (qteDelay >= 0)
        {
            maxTime -= Time.deltaTime;
        }
        if (qteDelay <= 0 && inputedKey == null)
        {
            //imgRed
        }
        else if (qteDelay >= 0 && goodKey == false)
        {
            //imgRed
        }
        else if (qteDelay >= 0 && goodKey == true)
        {
            //imgGreen
        }
        
        for (int i = 0; i <= thisKey.Length; i++)
        {
            if (thisKey[i] == inputedKey)
            {
                goodKey = true;
            }
            else if (thisKey[i] != inputedKey)
            {
                goodKey = false;
            }
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            print(imgZ);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            print(imgQ);
        }
        if (Input.GetKey(KeyCode.S))
        {
            print(imgS);
        }
        if (Input.GetKey(KeyCode.D))
        {
            print(imgD);
        }
        if (Input.GetKey(KeyCode.A))
        {
            print(imgA);
        }
        if (Input.GetKey(KeyCode.E))
        {
            print(imgE);
        }
    }
}
