using Azure.Data.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;
using Azure;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;


//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Table;

public class AzureTableStorage : MonoBehaviour
{
    private string connectionString = "";
    private TableServiceClient tableServiceClient;
    private string tableName = "WiFiTest";

    [SerializeField] private TextMeshPro ssidTMP;
    [SerializeField] private TextMeshPro passTMP;

    private bool isSaved = false;



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


        if(isSaved is false)
        {
            if (!string.IsNullOrWhiteSpace(ssid) && !string.IsNullOrWhiteSpace(pass))
            {
                if (IsOnlyAlphanumeric(ssid) && IsOnlyAlphanumeric(pass))
                {
                    var wifiEntity = new WiFiEntity
                    {
                        PartitionKey = "wifi",
                        RowKey = Guid.NewGuid().ToString(),
                        SSID = ssid,
                        Password = pass
                    };

                    try
                    {
                        await tableClient.AddEntityAsync(wifiEntity);
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                        gameObject.GetComponent<DialogController>().DataBaseSaveErrorDialog();
                    }

                    ssidTMP.GetComponent<InputEdit>().SetIsDataBaseSaved(true);
                    passTMP.GetComponent<InputEdit>().SetIsDataBaseSaved(true);
                    isSaved = true;

                }
                else
                {
                    Debug.Log("îºäpâpêîéöÇ∂Ç·Ç»Ç¢");
                    gameObject.GetComponent<DialogController>().NotAlphanumeric();

                }


            }
            else
            {
                Debug.Log("Null");
                gameObject.GetComponent<DialogController>().OpenNullEnputyDialog();
            }
        }
        else
        {
            Debug.Log("Alreday");
            gameObject.GetComponent<DialogController>().AlradySaved();
        }


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

    public void StartupShowWiFiEntityAsync()
    {
        ShowWiFiEntityAsync();
    }

    private  bool IsOnlyAlphanumeric(string text)
    {
        return (Regex.IsMatch(text, @"^[0-9a-zA-Z]+$"));
    }

    public async Task ShowWiFiEntityAsync()
    {
        var tableClient = tableServiceClient.GetTableClient(tableName);

        var singleRow = await tableClient.GetEntityAsync<WiFiEntity>(
            rowKey: "1",
            partitionKey: "wifi"
            );

        Debug.Log(singleRow.Value);
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
