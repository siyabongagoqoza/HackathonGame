using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("disappearCol")){
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
