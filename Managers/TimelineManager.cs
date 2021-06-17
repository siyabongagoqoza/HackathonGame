using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    
    public PlayableDirector timeline;
    public BoxCollider2D triggerBox;
 
    void OnTriggerEnter2D(Collider2D other){
       
        timeline = GetComponent<PlayableDirector>();
        triggerBox = GetComponent<BoxCollider2D>();

        if (other.gameObject.CompareTag("player"))
        {
            timeline.Play();
            triggerBox.enabled = false;
        }  
    }
    
    void Update(){
        
    }
    


}
