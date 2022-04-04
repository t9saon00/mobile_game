using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{

    GameObject[] enemies; 
    public GameObject button; 
    public Text enemyCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = "Enemies left: " + enemies.Length.ToString();
        if(enemyCountText.text == "Enemies left: 0"){
            button.SetActive(true);
        }
    } 
}
 