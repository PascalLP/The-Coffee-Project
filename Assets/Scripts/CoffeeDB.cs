using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class CoffeeDB : MonoBehaviour
{
    // Name of DB
    private string dbName;

    // Amount of coffee
    private int amountOfCoffee;


    void Start()
    {
        Debug.Log("Connected to database");
        /*dbName = "URI=File:" + Application.dataPath + "/StreamingAssets/TheCoffeeDB.db";
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);
        */
        //GetCoffeeData("Coffee_production");
        //Debug.Log("Coffee Beans Spawned: " + GetCoffeeConsumptionData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns a connection object to Coffee database
    private IDbConnection CreateAndOpenDatabase()
    {
        // Open connection to DB
        string dbUri = "URI=file:"+ Application.dataPath + "/StreamingAssets/TheCoffeeDB.db";
        dbName = dbUri;
        Debug.Log(dbUri);
        IDbConnection connection = new SqliteConnection(dbUri);
        connection.Open();

        return connection;
    }

        // LOOK INTO IDbConnection

    // Retrieving all Data
    public void GetCoffeeData(string tableName)
    {
        using (IDbConnection dbConnection = CreateAndOpenDatabase())
        {
            Debug.Log("Found database: " + dbConnection.Database);
            // Using an object to allow db control
            using (IDbCommand dbCommandReadValues = dbConnection.CreateCommand())
            {
                // The SQL query
                dbCommandReadValues.CommandText = "SELECT * FROM " + tableName + ";";

                // Iterating over the returned record set
                using (IDataReader reader = dbCommandReadValues.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.Log("I'm reading from table: " + tableName);
                        Debug.Log("Country: " + reader["Country"] + "\tTotal production: " + reader["Total_production"]);
                    }
                    reader.Close();
                }
            }
            dbConnection.Close();
        }
        
    }

    // Retrieving all coffee production data per year
    public long GetCoffeeProductionData(int year)
    {
        using (IDbConnection dbConnection = CreateAndOpenDatabase())
        {
            Debug.Log("Found database: " + dbConnection.Database);
            long sum = 0;

            // Using an object to allow db control
            using (IDbCommand dbCommandReadValues = dbConnection.CreateCommand())
            {
                // The SQL query
                dbCommandReadValues.CommandText = "SELECT SUM(\""+year+"\") FROM Coffee_production;";
                

                // Iterating over the returned record set
                using (IDataReader reader = dbCommandReadValues.ExecuteReader())
                {
                    /*if (reader.Read())
                    {
                        totalCoffee = reader.GetInt32(reader.GetOrdinal("Total_domestic_consumption"));
                        //totalCoffee = reader["Total_domestic_consumption"];
                        Debug.Log("Total consumed coffee: " + totalCoffee);
                    }*/
                    int fieldCount = reader.FieldCount;
                    //Debug.Log(fieldCount);
                    while (reader.Read())
                    {
                        sum += Convert.ToInt64(reader[0]);
                    }
                    reader.Close();
                    //Debug.Log("Total consumed coffee: " + sum);
                }
            }
            dbConnection.Close();
            Debug.Log("Returning the sum: " + sum);
            return sum;
            //Debug.Log("COFFEE PRODUCED IN 2020: " + AmountToScale(sum));
            //return AmountToScale(sum);
        }
    }

    // Retrieving coffee production data per country
    public long GetCoffeeProductionData(string country)
    {
        using (IDbConnection dbConnection = CreateAndOpenDatabase())
        {
            Debug.Log("Found database: " + dbConnection.Database);
            long sum = 0;

            // Using an object to allow db control
            using (IDbCommand dbCommandReadValues = dbConnection.CreateCommand())
            {
                // The SQL query
                if(country == "Total")
                {
                    dbCommandReadValues.CommandText = "SELECT SUM(Total_production) FROM Coffee_production;";                
                } else
                {
                    dbCommandReadValues.CommandText = "SELECT Total_production FROM Coffee_production WHERE Country= \"" + country + "\";";
                }

                // Iterating over the returned record set
                using (IDataReader reader = dbCommandReadValues.ExecuteReader())
                {
                    /*if (reader.Read())
                    {
                        totalCoffee = reader.GetInt32(reader.GetOrdinal("Total_domestic_consumption"));
                        //totalCoffee = reader["Total_domestic_consumption"];
                        Debug.Log("Total consumed coffee: " + totalCoffee);
                    }*/
                    int fieldCount = reader.FieldCount;
                    //Debug.Log(fieldCount);
                    while (reader.Read())
                    {
                        sum += Convert.ToInt64(reader[0]);
                    }
                    reader.Close();
                    //Debug.Log("Total consumed coffee: " + sum);
                }
            }
            dbConnection.Close();
            Debug.Log("Returning the sum: " + sum);
            return sum;
            //Debug.Log("COFFEE PRODUCED IN 2020: " + AmountToScale(sum));
            //return AmountToScale(sum);
        }
    }

    // Retrieving all coffee consumption data // HARDCODE THE NAME OF TABLE
    public long GetCoffeeConsumptionData(int year)
    {
        
        using (IDbConnection dbConnection = CreateAndOpenDatabase())
        {
            Debug.Log("Found database: " + dbConnection.Database);
            long sum = 0;

            // Using an object to allow db control
            using (IDbCommand dbCommandReadValues = dbConnection.CreateCommand())
            {
                // The SQL query
                dbCommandReadValues.CommandText = "SELECT SUM(\"" + year + "\") FROM Coffee_importers_consumption;";

                // Iterating over the returned record set
                using (IDataReader reader = dbCommandReadValues.ExecuteReader())
                {
                    int fieldCount = reader.FieldCount;
                    //Debug.Log(fieldCount);
                    while (reader.Read())
                    {
                        sum += Convert.ToInt64(reader[0]);
                    }
                    reader.Close();
                    //Debug.Log("Total consumed coffee: " + sum);
                }
            }
            dbConnection.Close();
            Debug.Log("Returning " + sum + " liters of coffee consumed");
            return sum;
        }
    }



    public long AmountToScale(long amount)
    {
        return (amount / 100000000);
    }

}
