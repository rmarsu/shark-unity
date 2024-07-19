using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static class AllScore
    {
        public static int score = 0;
        public static int maxScore = 0;
    }
    void Start()
    {
        AllScore.score = PlayerPrefs.GetInt("Score", 0); // i know that save using playerPrefs is not a good way , but i don't want to make serialization for 1 value
        AllScore.maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

   public void IncreaseScore(int addscore)
   {
       AllScore.score += addscore;
       Debug.Log("Score: " + AllScore.score);
       if (UIController.instance != null)
        {
        UIController.instance.UpdateScore(AllScore.score);
        }
        else
        {
        Debug.LogError("UIController instance is null. Please initialize it before calling UpdateScore.");
        }
        
        //Update maxScore
        if (AllScore.score > AllScore.maxScore)
        {
            AllScore.maxScore = AllScore.score;
            PlayerPrefs.SetInt("MaxScore", AllScore.maxScore);
        }
        
   }
}
