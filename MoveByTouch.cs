using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MoveByTouch : MonoBehaviour
    {
    
        public Joystick joystic;
        public float playerSpeed;
        private Rigidbody2D rb;
    
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
                rb.velocity = new Vector2(joystic.Horizontal * playerSpeed, joystic.Vertical * playerSpeed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    } 