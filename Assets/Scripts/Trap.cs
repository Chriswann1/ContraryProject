using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool open = false;
    int openHash;
    [SerializeField] bool killplayer = false;

    [SerializeField] BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        openHash = Animator.StringToHash("Open");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(openHash, open);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken"))
        {
            Debug.Log("Chicken est passé");
            open = true;
            collider.enabled = true;

            if (killplayer)
            {
                Death();
            }
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        GameplayManager.Instance.GameOver();
    }
}
