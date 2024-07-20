using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
   AudioSource src;
   public InputAction MoveAction;
   [SerializeField] float speed;
   [SerializeField] float rotateSpeed;
   Rigidbody2D rb;
   Animator animator;
   bool facingRight = true;


   // Start is called before the first frame update
   void Start()
   {
     src = GetComponent<AudioSource>();
	  rb = GetComponent<Rigidbody2D>();
     MoveAction.Enable();  
   }


   // Update is called once per frame
   void Update()
   {
        Animator animator = GetComponentInChildren<Animator>(); 
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        movement.Normalize();
        Vector2 position = (Vector2)transform.position + movement * Time.deltaTime * speed;
        transform.position = position;
        if (moveX < 0 && facingRight)
        {
          Flip();
          facingRight = false;
        }
        else if (moveX > 0 &&!facingRight)
        {
          Flip();
          facingRight = true;
        }
        

        if (movement != Vector2.zero)
        {
            animator.SetBool("Moves", true);

            if (facingRight)
            {
               float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; 
               float angleClamp = Mathf.Clamp(angle , -40.0f, 40.0f);
               transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angleClamp), rotateSpeed * Time.deltaTime);
               // Debug.Log("right" + angleClamp);
            }
            else 
            {
               Quaternion.Euler(0, 0, 0);
               float angle = Mathf.Atan2(movement.y , movement.x) * Mathf.Rad2Deg; 
                Debug.Log("leftbefore" + angle);
               if (angle == 90.0f || angle == -90.0f)
               {
                  angle = angle * -1;
                  Debug.Log("up or down");  
               }
               else if (angle < 0)
               {
                  angle = angle + 180f;
                  Debug.Log(angle);
               }
               else if (angle > 0f)
               {
                  angle = angle - 180f;
               }
               //сверху настолько дикий костыль что от него плакать хочется
               float angleClamp = Mathf.Clamp(angle , -40.0f, 40.0f);

               transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angleClamp), rotateSpeed * Time.deltaTime);
            }
        }
        else 
        {
           animator.SetBool("Moves", false);
        }
   }
   public void Eat(int addscore)
   {
     ScoreManager scoreManager = GetComponent<ScoreManager>();
     Animator animator = GetComponentInChildren<Animator>(); 
     animator.SetTrigger("Eat");
     scoreManager.IncreaseScore(addscore); 
     src.Play();

   }

   void Flip()
   {
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
   }

}
