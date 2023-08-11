using Azure.Data.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using Azure;
using UnityEngine.UI;
using TMPro;


//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Table;

public class AzureTableStorage : MonoBehaviour
{
    private string connectionString = "DefaultEndpointsProtocol=https;AccountName=networkholo2;AccountKey=4bD4Q6vZbra4zT7IEqZ5ed7wzWFXmsI4avQ4f6DeNSOHwLsZGYmK9ZBnuEjP5otWInmsqAGPSTs5+AStHxLwyA==;EndpointSuffix=core.windows.net";
    private TableServiceClient tableServiceClient;
    private string tableName = "WiFiTest";

    [SerializeField] private TextMeshPro ssidTMP;
    [SerializeField] private TextMeshPro passTMP;



    // Start is called before the first frame update
    void Start()
    {
        tableServiceClient = new TableServiceClient(connectionString);
    }

    public async Task AddWiFiEntityAsync()
    {
        var tableClient = tableServiceClient.GetTableClient(tableName);

        string ssid = ssidTMP.GetComponent<InputEdit>().GetInputText();
        Debug.Log(ssid);
        string pass = passTMP.GetComponent<InputEdit>().GetInputText();
        Debug.Log(pass);

        var wifiEntity = new WiFiEntity
        {
            PartitionKey = "wifi",
            RowKey = Guid.NewGuid().ToString(),
            SSID = ssid,
            Password = pass
        };

        //await tableClient.AddEntityAsync(wifiEntity);
    }
    public void AddWiFiEntityAsyncVoid()
    {
        var tableClient = tableServiceClient.GetTableClient(tableName);

        var wifiEntity = new WiFiEntity
        {
            PartitionKey = "wifi2",
            RowKey = Guid.NewGuid().ToString(),
            SSID = "kklab",
            Password = "test20230809"
        };

        tableClient.AddEntityAsync(wifiEntity);
    }
    public void StartupAddWiFiEntityAsync()
    {
        AddWiFiEntityAsync();
    }

}





public class WiFiEntity : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }

    public string SSID { get; set; }
    public string Password { get; set; }


}
