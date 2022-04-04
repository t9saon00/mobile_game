using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip collect; 
    public AudioClip hit; 
    public AudioClip dead; 
    public AudioSource gameMusic;
    
    
    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>(); 

         
    } 

    // Update is called once per frame
    void Update()
    {
         if(!gameMusic.isPlaying) {
            gameMusic.Play();
         }
    }

    public void collectHealth(){ 
        audioSource.PlayOneShot(collect, 0.7f);
    }
    public void hitWall(){
        audioSource.PlayOneShot(hit, 0.7f);
    }
    public void enemyDeath(){
        Debug.Log("auts");
        //audioSource.PlayOneShot(dead, 0.7F); 
    } 
}
