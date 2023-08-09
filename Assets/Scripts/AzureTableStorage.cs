using Azure.Data.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using Azure;
using UnityEngine.UI;


//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Table;

public class AzureTableStorage : MonoBehaviour
{
    private string connectionString = "DefaultEndpointsProtocol=https;AccountName=networkholo2;AccountKey=RvMoDS6B6GWSrWeFWuoXT6B5D7OUhR2v9gWSniA6T+xjM3PJPpo4fyn0ihwgxf6pZcj+9WReS9C3+ASt/L21xQ==;EndpointSuffix=core.windows.net";
    private TableServiceClient tableServiceClient;
    private string tableName = "WiFiTest";


    // Start is called before the first frame update
    void Start()
    {
        tableServiceClient = new TableServiceClient(connectionString);
    }

    public async Task AddWiFiEntityAsync()
    {
        var tableClient = tableServiceClient.GetTableClient(tableName);

        var wifiEntity = new WiFiEntity
        {
            PartitionKey = "wifi",
            RowKey = Guid.NewGuid().ToString(),
            SSID = "kklab",
            Password = "test0809"
        };

        await tableClient.AddEntityAsync(wifiEntity);
    }
    public void AddWiFiEntityAsyncVoid()
    {
        var tableClient = tableServiceClient.GetTableClient(tableName);

        var wifiEntity = new WiFiEntity
        {
            PartitionKey = "wifi",
            RowKey = Guid.NewGuid().ToString(),
            SSID = "kklab",
            Password = "test0809"
        };

        tableClient.AddEntityAsync(wifiEntity);
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
