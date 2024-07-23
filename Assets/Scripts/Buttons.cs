using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject CoffeeBeanPrefab;
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private List<GameObject> coffeeSpawners;
    [SerializeField] private List<GameObject> peopleSpawners;
    [SerializeField] private GameObject coffeeLake;
    public int coffeeAmount;
    public int spawnForce = 10;
    public TextMeshProUGUI coffeeProducedInfo;
    private List<int> scenes = new List<int>();

    // Database connection
    [SerializeField] private CoffeeDB coffeeDB;

    void Start()
    {
        //DontDestroyOnLoad(this);
        for(int i = 0; i < 3; i++)
        {
            scenes.Add(i);
        }

        //coffeeDB= GetComponent<CoffeeDB>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns amount of coffee beans selected
    public void SpawnCoffeeBeans()
    {
        GameObject NewBean;
        for (int j = 0; j < coffeeAmount; j++)
        {
            for (int i = 0; i < coffeeSpawners.Count; i++)
            {
                Debug.Log("New Beans instantiated at: " + coffeeSpawners[i].transform.position);
                NewBean = Instantiate(CoffeeBeanPrefab, coffeeSpawners[i].transform.position, Quaternion.identity);
                NewBean.GetComponent<Rigidbody>().AddForce(coffeeSpawners[i].transform.forward * spawnForce, ForceMode.Impulse);
            }
        }
        long amount = coffeeDB.GetCoffeeProductionData(2020);
        coffeeProducedInfo.text = amount.ToString("N0") + " tons of coffee produced worldwide";
    }

    // Spawns humans
    public void SpawnHumans()
    {
        GameObject NewBean;
        for (int j = 0; j < peopleSpawners.Count; j++)
        {
             Debug.Log("New people instantiated at: " + peopleSpawners[j].transform.position);
             NewBean = Instantiate(humanPrefab, peopleSpawners[j].transform.position, Quaternion.identity);
                //NewBean.GetComponent<Rigidbody>().AddForce(peopleSpawners[i].transform.forward * spawnForce, ForceMode.Impulse);
        }
        coffeeDB.GetCoffeeProductionData("Total");
    }

    // Raise the coffee liquid level
    public void RaiseCoffeeLevel()
    {
        StartCoroutine(IncreaseLevelHeight(10f));
    }
    private IEnumerator IncreaseLevelHeight(float raiseTime)
    {
        Vector3 initialPos = coffeeLake.transform.position;
        Vector3 targetPos = initialPos + new Vector3(0, 2, 0);
        float currentTime = 0;
        while(currentTime < raiseTime)
        {
            coffeeLake.transform.position = Vector3.Lerp(initialPos, targetPos, currentTime);
            currentTime += raiseTime * Time.deltaTime;
            yield return null;
        }
    }

}
