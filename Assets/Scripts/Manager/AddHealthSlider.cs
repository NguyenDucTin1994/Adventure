using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddHealthSlider : MonoBehaviour
{
    public Slider Slider;
    public TMP_Text countfruitText;

    // Start is called before the first frame update
    void Start()
    {
        PickupCollection.countFruitToAddHealth = 0;
        Slider = GetComponent<Slider>();
        Slider.value = 0;
        countfruitText.text = ""+0;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = PickupCollection.countFruitToAddHealth;
        countfruitText.text= ""+Slider.value;
    }
}
