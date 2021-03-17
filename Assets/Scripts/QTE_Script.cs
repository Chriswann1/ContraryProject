﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Script : MonoBehaviour
{
    #region variables

    [SerializeField]private AudioClip[] audioClipQte;
    [SerializeField]private AudioSource audioSources;
    private int indexAudio;
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

    private bool audioPlay = false;
    [SerializeField]private bool qteUsed;
 
    #endregion

    private void Start()
    {
        audioSources.clip = audioClipQte[indexAudio];
    }

    // Update is called once per frame
    void Update()
    {
        if (qteDelay-Time.time > 0)
        {
            timeTxt.text = (qteDelay-Time.time).ToString("n2");
        }
        if (enableQte && !qteUsed)
        {
            if (!audioPlay)
            {
                audioSources.Play();
                audioPlay = true;
            }
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

                StartCoroutine(WaitForDisplayGameOver());
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

    IEnumerator WaitForDisplayGameOver()
    {
        yield return new WaitForSeconds(1);
        GameplayManager.Instance.GameOver();
        this.enabled = false;
    }
}
