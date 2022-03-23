using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    public class MoveByTouch : MonoBehaviour
    {
    
        public Joystick joystic;
        public GameObject bullet; 
        public float moveSpeed;
        public float turnSpeed;
        private Rigidbody2D rb;
        public Camera cam;
        Vector2 move;

        void Update() {
            float moveHorizontal = joystic.Horizontal;
            float moveVertical = joystic.Vertical;
            float headingAngle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
            if (headingAngle < 0) headingAngle += 360f;
            Quaternion newHeading = Quaternion.Euler(0f, 0f, headingAngle);
            float angleDiff = Quaternion.Angle(transform.rotation, newHeading);        
    
            if ((angleDiff > 1.0f) && (moveHorizontal != 0f || moveVertical != 0f)) // Turning
            {
                Debug.Log("Turning");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newHeading, turnSpeed * Time.deltaTime);
                transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);          
            }
            else if ((angleDiff < 1.0f) && (moveHorizontal != 0f || moveVertical != 0f)) // Moving
            {
                Debug.Log("Moving");
                transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);          
            }
            else // Stationary
            {
                Debug.Log("Stationary");
                // Do something here... idle animation, audio, etc.
            }

        }
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
       void FixedUpdate()
        {
            if(joystic.Horizontal != 0 || joystic.Vertical != 0  )
            {
                rb.velocity = new Vector2(joystic.Horizontal * moveSpeed, joystic.Vertical * moveSpeed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        } 

        public void Shoot() {
            
        }

    } 