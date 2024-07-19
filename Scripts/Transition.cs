using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private int scene;
    public GameObject fadeIn;

    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void FadeIn()
    {
        fadeIn.gameObject.SetActive(true);
    }
}
