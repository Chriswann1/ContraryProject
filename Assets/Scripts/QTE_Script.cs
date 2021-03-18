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
    private Transform[] spritesmask; 
    public GameObject qteUI;
    
    public TextMeshProUGUI timeTxt;
    
    private bool goodKey;
    [SerializeField]private float maxTime; 
    private float qteDelay;
    private bool enableQte = false;
    private bool imgSpawned = false;

    [SerializeField]private bool qteUsed;

    private float timeavailable;

    #endregion

    private void Start()
    {
        spritesmask = new Transform[pictures.Length];
        for (int i = 0; i < spritesmask.Length; i++)
        {
            spritesmask[i] = pictures[i].transform.GetChild(0);
        }
        //audioSources.clip = audioClipQte[indexAudio];
    }

    // Update is called once per frame
    void Update()
    {
        timeavailable = qteDelay - Time.time;
        if (timeavailable > 0)
        {
            timeTxt.text = timeavailable.ToString("n2");
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
            GameplayManager.Instance.inqte = true;
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
            spritesmask[index].transform.localPosition = new Vector3(0, ((timeavailable - 0f) / (maxTime - 0)) * (-100 - 0) + (0), 0);
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

                StartCoroutine(WaitForDisplayGameOver());
            }
        }
        else
        {
            qteUsed = true;
            Invoke("disableUI", 0.5f);
            GameplayManager.Instance.inqte = false;
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
        if (other.CompareTag("Chicken"))
        {
            enableQte = true;
            

        }

    }

    IEnumerator WaitForDisplayGameOver()
    {
        yield return new WaitForSeconds(1);
        GameplayManager.Instance.inqte = false;
        GameplayManager.Instance.GameOver();
        this.enabled = false;
    }
}
