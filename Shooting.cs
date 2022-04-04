using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(AudioSource))]


public class Shooting : MonoBehaviour
{
    CinemachineImpulseSource impulseSource;
    public AudioClip impact; 
    public AudioSource audioSource;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void Shoot() {
        impulseSource.GenerateImpulse();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(impact, 0.7F);
        Destroy(bullet, 5); // Destroy bullet instance after 5 seconds
    }
}
