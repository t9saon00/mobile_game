using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class HealthBox : MonoBehaviour
{   
    AudioSource audioSource;
    public GameObject AudioManager;
    [SerializeField] private AudioClip collect;
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Player")){
            //audioSource.PlayClipAtPoint(collect, transform.position);  
            AudioSource.PlayClipAtPoint(collect, Camera.main.transform.position); 
            HealthBar.health = 100f;
            Destroy(gameObject);
        } 
       
        
    }
}
