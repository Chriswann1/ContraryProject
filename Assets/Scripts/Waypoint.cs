﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private bool ispassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ispassed && other.CompareTag("Chicken"))
        {
            GameplayManager.Instance.lastwaypoint = gameObject.transform.position;
            ispassed = true;
            gameObject.SetActive(false);
        }
    }
}
