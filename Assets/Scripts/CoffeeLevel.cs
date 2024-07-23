using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeLevel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private int currentYear;

    void Start()
    {
        currentYear = (int)_slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        int newYear = (int)_slider.value;
        if(newYear != currentYear)
        {
            ChangeLevel(newYear);
        }
        currentYear = newYear;

    }

    public void ChangeLevel(int year)
    {
        //Debug.Log("THE NEW CURRENT YEAR IS : " + year + "\nAND THE PREVIOUS WAS " + currentYear);
        if (year > currentYear)
            transform.position += new Vector3(0, 0.5f, 0);
        if (year < currentYear)
            transform.position -= new Vector3(0, 0.5f, 0);
    }
}
