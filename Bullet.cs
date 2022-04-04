using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public string target;
    public GameObject deadBody;  
    public AudioManager audioManager; 
    AudioSource audioSource; 
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip dead;
    // Update is called once per frame
    void Update()
    {
  
    }

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
 
        if(collision.CompareTag("Enemy")){ 
            //audioManager.GetComponent<AudioManager>();
            AudioSource.PlayClipAtPoint(dead, Camera.main.transform.position); 
            Instantiate(deadBody, collision.transform.position, collision.transform.rotation);
           
            Destroy (collision.gameObject);
           
        }
        else if(!collision.CompareTag("Player") && collision != null){ 
            //audioManager.hitWall();
             AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position, 0.2f); 
            Destroy (gameObject);
        } 
    } 


}
