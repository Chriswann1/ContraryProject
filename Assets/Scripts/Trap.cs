using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator animator;


    [SerializeField] bool killplayer = false;
    private bool used = false;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !used)
        {
            Debug.Log("Chicken est passé");
            animator.SetBool("isOpen", false);


            if (killplayer)
            {
                StartCoroutine(Death());
            }

            used = true;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        GameplayManager.Instance.GameOver();
    }
}
