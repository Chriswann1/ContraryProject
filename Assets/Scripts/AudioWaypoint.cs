using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWaypoint : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    bool visited;

    // Start is called before the first frame update
    void Start()
    {
        visited = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chicken" && !visited)
        {
            audioSource.Play();
            visited = true;
        }
    }
}
