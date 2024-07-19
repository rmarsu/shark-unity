using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIController : MonoBehaviour
{
    Label ScoreText;
    Label HealthText;
    public static UIController instance { get; private set; }

    private void Awake()
    {
       instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        ScoreText = uiDocument.rootVisualElement.Q<Label>("Score");
        UpdateScore(0);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
