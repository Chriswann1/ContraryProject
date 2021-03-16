using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Script : MonoBehaviour
{
    #region variables

    private int index = 0;
    [SerializeField]private KeyCode[] thisKey;
    [SerializeField]private Image[] pictures;
    [SerializeField]private Sprite[] sprites;
    public GameObject qteUI;
    
    public TextMeshProUGUI timeTxt;
    
    private bool goodKey;
    [SerializeField]private float maxTime; 
    private float qteDelay;
    private bool enableQte = true;
    private bool imgSpawned = false;

    [SerializeField]private bool qteUsed;
 
    #endregion
    
    // Update is called once per frame
    void Update()
    {
        if (qteDelay-Time.time > 0)
        {
            timeTxt.text = (qteDelay-Time.time).ToString("n2");
        }
        if (enableQte && !qteUsed)
        {
            QTe();
        }
    }

    void QTe()
    {
        if (!imgSpawned)
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                pictures[i].sprite = sprites[i];
                pictures[i].gameObject.SetActive(true);
                qteDelay = Time.time + maxTime;
            }
            qteUI.SetActive(true);
            imgSpawned = true;
        }

        if (index<pictures.Length)
        {
            if (Input.GetKeyDown(thisKey[index]))
            {
                pictures[index].color = Color.green;
                index++;
                //qteDelay = Time.time + maxTime;
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(thisKey[index]) || Time.time>qteDelay){
                Debug.Log("BadKey");
                pictures[index].color = Color.red;
                qteUsed = true;
                Invoke("disableUI", 0.4f);
                
                Invoke("GameplayManager.Instance.GameOver",0.5f);
                this.enabled = false;
            }
        }
        else
        {
            qteUsed = true;
            Invoke("disableUI", 0.5f);
            this.enabled = false;
        }
    }

    void disableUI()
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            pictures[i].gameObject.SetActive(true);
            qteDelay = Time.time + maxTime;
        }
        qteUI.SetActive(false);
        imgSpawned = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        enableQte = true;
    }
}
