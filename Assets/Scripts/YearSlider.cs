using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YearSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _yearText;
    [SerializeField] private TextMeshProUGUI _litersText;
    public CoffeeDB coffeeDB;
    private long amountOfCoffee;

    // Start is called before the first frame update
    void Start()
    {
        
        _slider.onValueChanged.AddListener((v) =>
        {
            _yearText.text = v.ToString("0000");
            UpdateInfoText();
        });
        
    }

    void UpdateInfoText()
    {
        amountOfCoffee = coffeeDB.GetCoffeeConsumptionData((int)_slider.value);
        _litersText.text = amountOfCoffee.ToString("N0") + " liters of coffee consumed worldwide";
    }
}
