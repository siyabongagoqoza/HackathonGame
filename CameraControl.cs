using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    /*
        Target is the game object that the camera will follow.
        Smoothing is the time it take for the camera to move.
    */
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Start()
    {
        
    }

    /*
        Late update is used because it allows all other actions to be performed
        after all other actions have started. Example the player moves then late
        update maakes the camera follow.
    */
    void LateUpdate()
    {
        // Activates once the players position is not equalt to the cameras position.
        if(transform.position != target.position)
        {
            /*
                targetPosition creates a new vector containing the players x, y, and z 
                co-ords.
                The camera position is updated in transform.position
            */
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // These variables is used to set the max amd min co-ords the camer will display.
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        
            
        }
    }
}
