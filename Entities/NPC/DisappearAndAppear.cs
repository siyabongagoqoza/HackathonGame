using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAndAppear : MonoBehaviour
{

    public Transform spawnPointSewer;
    public Transform spawnPointCity;
    public Transform spawnPointWare;
    public Transform spawnPointAlley;


    void OnTriggerEnter2D(Collider2D other){


        // Spawns Bruce in the sewer
        if (other.gameObject.CompareTag("sewerSpawn")){
            transform.position = spawnPointSewer.position;
            Debug.Log("Entity Position Was Changed");
           
        }
        // Spawns Player in the City
        if (other.gameObject.CompareTag("citySpawn")){
            transform.position = spawnPointCity.position;
            Debug.Log("Player Position was Changed");
          
        }

        // Spawns Player in the warehouse
        if (other.gameObject.CompareTag("wareSpawn"))
        {
            transform.position = spawnPointWare.position;
            Debug.Log("Player Position was Changed");

        }

        // Spawns Player in the alley
        if (other.gameObject.CompareTag("citySpawn2"))
        {
            transform.position = spawnPointAlley.position;
            Debug.Log("Player Position was Changed");

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
