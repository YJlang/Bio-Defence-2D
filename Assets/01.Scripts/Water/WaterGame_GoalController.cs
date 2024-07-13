using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGame_GoalController : MonoBehaviour
{
    public Slider goalSlider;

    public void IncreaseGoal(float increment)
    {
        goalSlider.value += increment;
    }
}
