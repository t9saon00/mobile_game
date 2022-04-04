using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    public string target;
    AudioSource audioSource; 
    [SerializeField] private AudioClip hitPlayer;
    // Update is called once per frame 
    void Start()
    {

    } 

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(!collision.CompareTag("Enemy")){
            Destroy (gameObject);
        } 
        if(collision.CompareTag("Player")){
            AudioSource.PlayClipAtPoint(hitPlayer, Camera.main.transform.position); 
            HealthBar.health -= 5f;
        } 
       
        
    }

}
