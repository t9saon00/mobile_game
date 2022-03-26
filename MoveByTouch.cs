using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    public class MoveByTouch : MonoBehaviour
    {
    
        public Joystick joystic;
        public float initialSpeed;
        private float moveSpeed;
        public float runSpeed;
        public float turnSpeed;
        public string target;
        private bool collisionDetect = false;
        public Rigidbody2D rb;
        private Vector2 moveInput;
    
        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = initialSpeed;
        }

        void FixedUpdate() {
            float moveHorizontal = joystic.Horizontal;
            float moveVertical = joystic.Vertical;

            moveInput = new Vector2(moveHorizontal, moveVertical);

            float headingAngle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
            if (headingAngle < 0) headingAngle += 360f;
            Quaternion newHeading = Quaternion.Euler(0f, 0f, headingAngle);
            float angleDiff = Quaternion.Angle(transform.rotation, newHeading);        
    
            if ((angleDiff > 1.0f) && (moveHorizontal != 0f || moveVertical != 0f)) // Turning
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newHeading, turnSpeed * Time.deltaTime);
                //transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);  
                rb.position += moveInput * moveSpeed;       
            }
            else if ((angleDiff < 1.0f) && (moveHorizontal != 0f || moveVertical != 0f)) // Moving
            {
                //transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);  
                rb.position += moveInput * moveSpeed;        
            }
            else // Stationary
            {
                rb.velocity = Vector2.zero; 
            }

        }


        public void RunDown(){
            moveSpeed = runSpeed;
        }
        public void RunUp(){
            moveSpeed = initialSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            
            if(collision.CompareTag("wall")){
                Debug.Log("testi");
                rb.position = Vector2.zero; 
            } 
        }


    } 