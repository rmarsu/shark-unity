using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField] private int addscore;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller!= null)
        {

            controller.Eat(addscore);
            
       
           Destroy(transform.parent.gameObject);
          
        }
        
    }  
}
