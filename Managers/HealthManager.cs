using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthFill;
    public FloatValue playerHealth;
    public BoolValue tru;

    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        // This sets the players max health, and his current health value on game start.
        slider.maxValue = playerHealth.RuntimeValue;
        slider.value = playerHealth.initialValue;
        healthFill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void UpdateHealth()
    {
        // This is responsible for updating the players health.
        slider.value = playerHealth.initialValue;
        healthFill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Heal()
    {
        //slider.value = playerHealth.initialValue += 2;
        Debug.Log("You fool");
    }
}
