using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWaypoint : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] AudioSource audioSource;
    bool visited;
    [SerializeField] string txtCoq;

    // Start is called before the first frame update
    void Start()
    {
        visited = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !visited)
        {
            audioSource.clip = clip;
            audioSource.Play();
            visited = true;
            GameplayManager.Instance.txtDialogueCoq.text = txtCoq;
            StartCoroutine(Dialogue());
        }
    }

    IEnumerator Dialogue()
    {
        GameplayManager.Instance.dialogueCoq.SetActive(true);
        yield return new WaitForSeconds(audioSource.time +5);
        GameplayManager.Instance.dialogueCoq.SetActive(false);
    }
}
