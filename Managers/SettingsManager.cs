using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Joystick rightControls;
    public Joystick leftControls;

    public GameObject rightControlStatus;
    public GameObject leftControlStatus;
    private GameObject playerControl;

    public void ToggleControls()
    {
        playerControl = GameObject.FindWithTag("player");

        if (rightControlStatus.activeInHierarchy == true)
        {
            rightControlStatus.SetActive(false);
            leftControlStatus.SetActive(true);
            playerControl.GetComponent<PlayerMovement>().joystick = leftControls;
        }
        else
        {
            rightControlStatus.SetActive(true);
            leftControlStatus.SetActive(false);
            playerControl.GetComponent<PlayerMovement>().joystick = rightControls;
        }
    }
}
