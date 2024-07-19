using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollect : MonoBehaviour
{
    [SerializeField] private int addscore;
    private void OnTriggerEnter(Collider other)
    {
        // Destroy(gameObject);  // Destroy the collected enemy object when it touches the player.
        PlayerController controller = other.GetComponent<PlayerController>();
        ScoreManager scoreManager = other.GetComponent<ScoreManager>();
        if (controller!= null)
        {
            scoreManager.IncreaseScore(addscore);  // Increase the player's score when they collect an enemy.
            // You can add more effects or actions based on the collected enemy type here. For example, play a sound effect or change the player's appearance.
            // Example: controller.ChangeMaterial(Material newMaterial);  // Change the player's material to a different one.
            
       
           Destroy(gameObject);
           
          
        }
        
    }  
}
