using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Label Record;
    Button Play;
    Button Settings;


    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        Record = uiDocument.rootVisualElement.Q<Label>("Record");
        Play = uiDocument.rootVisualElement.Q<Button>("Play");
        Settings = uiDocument.rootVisualElement.Q<Button>("Settings");

        Play.clicked += OnPlayClick;
        Settings.clicked += OnSettingsClick;
        
        Record.text = "Ваш рекорд: " + PlayerPrefs.GetInt("MaxScore", 0);


    }
    void OnPlayClick()
    {
        Transition transition = GetComponent<Transition>();
        // Implement play button functionality here
        Debug.Log("Play button clicked");
        // Load game scene or start game
        
        transition.FadeIn();
        PlayerPrefs.SetInt("Score", 0);
    }
    void OnSettingsClick()
    {
        //TODO : Implement play button functionality here
    }

}
