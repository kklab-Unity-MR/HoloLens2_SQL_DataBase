using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Data.SqlClient;

public class SaveDataToAzureSQL : MonoBehaviour
{
    private string connectionString = "";
    private string tableName = "Wi-Fi";

    public TMP_InputField ssidInputField;
    public TMP_InputField passwordInputField;

    public void InsertDatetoDatabase()
    {
        string ssid = ssidInputField.GetComponent<TMP_InputField>().text;
        string pass = passwordInputField.GetComponent<TMP_InputField>().text;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} (SSID, PassWord) VALUES (@SSID, @PassWord)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SSID", ssid);
                    command.Parameters.AddWithValue("@PassWord", pass);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            Debug.Log("データが正常に保存されました。");
        }

        catch(Exception e)
        {
            Debug.LogError("データの保存中にエラーが発生しました");
        }
    }
}