using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    public string target;

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(!collision.CompareTag("Enemy")){
            Destroy (gameObject);
        } 
       
        
    }

}
