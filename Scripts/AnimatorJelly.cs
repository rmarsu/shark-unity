using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorJelly : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Scared", true);
        }
    }
    // Update is called once per frame
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Scared", false);
        }
    }
}