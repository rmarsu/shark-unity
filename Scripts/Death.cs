using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private float time;
    Animator animator;
    AudioSource src;
    void Start()
    {
        src = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        // Start the countdown
        StartCoroutine(Countdown());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If player collides with the death object, trigger the death animation
            animator.SetBool("Explode", true);
            src.Play();
            ScoreManager scoreManager = other.GetComponent<ScoreManager>();

            PlayerPrefs.SetInt("Score", ScoreManager.AllScore.score);
            PlayerPrefs.SetInt("MaxScore", ScoreManager.AllScore.maxScore);
            Destroy(other.gameObject);
            StartCoroutine(WaitUntilDeath());
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(time);
        Destroy(transform.parent.gameObject);
    }
    IEnumerator WaitUntilDeath()
    {
        yield return new WaitForSeconds(0.5f);
        // Add your death animation here, or simply destroy the game object
        SceneManager.LoadScene(2);
    }
    
}
