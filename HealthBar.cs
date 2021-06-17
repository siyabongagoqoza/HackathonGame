using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Imports the UI feature

// [!!] This scirpt handles the animation of the health bar.

public class HealthBar : MonoBehaviour
{
    /* 
        Slider allows the import of the health bar slider image (Health indicator). [**] Import slider component.
        Gradient allows the option of colors that will be applied to the fill (Health indicator) this is to display health state.
        Image imports the image that will be used as the fill (Health indicator). [**] Import Fill Image (Health indicator).
    */
    /*
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // This method is responsible for setting the max health the bar will have.
    public void SetMaxHealth(int health)
    {
        // Returns the value passed into the slider component applied to the in game health bar.
        slider.maxValue = health;
        slider.value = health;

        // By default the gradient will have a float value of 1 be passed to it.
        gradient.Evaluate(1f);
    }

    // This method is used to set the fill (Health indicator) to their respective color depending on the value of health present.
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
    */
}
