using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountryInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countryName;
    [SerializeField] private TextMeshProUGUI countryInfo;
    [SerializeField] private GameObject CoffeeBeanPrefab;

    // Audio
    private AudioSource soundFX;

    //public int coffeeAmount = 20;
    public int spawnForce = 60;
    public CoffeeDB coffeeDB;

    void Start()
    {
        soundFX = GetComponent<AudioSource>();
        /*countryName = GetComponent<TextMeshProUGUI>();
        countryInfo = GetComponent<TextMeshProUGUI>();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        long amountOfCoffee = coffeeDB.GetCoffeeProductionData(gameObject.name);
        soundFX.Play();
        if(gameObject.name == "Viet Nam")
        {
            countryName.text = "Vietnam";
            countryInfo.text = "Vietnam has produced \n" + amountOfCoffee.ToString("N0") + " \ntons of coffee since 1990";
        }
        else
        {
            countryName.text = gameObject.name;
            countryInfo.text = gameObject.name + " has produced \n" + amountOfCoffee.ToString("N0") + " \ntons of coffee since 1990";
        }
        ExplodeCoffee(amountOfCoffee);
    }

    private void ExplodeCoffee(long coffeeAmount)
    {
        /*Vector3 direction = transform.position - GetComponentInParent<Transform>().position; 
        direction = direction.normalized;*/
        coffeeAmount = coffeeAmount / 1000000000;
        Debug.Log("Spawning " + coffeeAmount + " beans from " + gameObject.name);
        GameObject NewBean;
        for (int i = 0; i < coffeeAmount; i++)
        {
            NewBean = Instantiate(CoffeeBeanPrefab, transform.position, Quaternion.identity);
            NewBean.GetComponent<Rigidbody>().AddForce(transform.up * spawnForce, ForceMode.Force);
            Destroy(NewBean, 1.5f);
        }
    }
}
