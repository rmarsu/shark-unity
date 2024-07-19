using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DeathUIManager : MonoBehaviour
{
    Label scoreText;
    Button PlayAgain;
    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        if (uiDocument!= null)
        {
            scoreText = uiDocument.rootVisualElement.Q<Label>("score");
            PlayAgain = uiDocument.rootVisualElement.Q<Button>("PlayAgain");
            PlayAgain.clicked += OnPlayAgainClick;
             
            scoreText.text = "Похоже вы наткнулись на мину.\n Избегайте их чтобы оставаться на плаву.\n Вы набрали " + PlayerPrefs.GetInt("Score", 0)+ " очков.";

        }        
        void OnPlayAgainClick()
        {
            // Implement play again button functionality here
            Debug.Log("Play again button clicked");
            // Load game scene or start game
            SceneManager.LoadScene(0);
        }
    }
}
