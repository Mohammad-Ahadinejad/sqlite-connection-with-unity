using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BtnFunctions : MonoBehaviour
{
    public GameObject tableInput;
    public GameObject rowInput;
    public GameObject columnInput;
    public GameObject dataInput;
    public GameObject output;
    public GameObject message;
    SqlFunctions sql;

    void Start()
    {
        sql = GameObject.Find("Canvas"). GetComponent<SqlFunctions>();
    }

    public void BtnRead()
    {
        string tableName = tableInput.GetComponent<TMP_InputField>().text;
        int rowNum = int.Parse(rowInput.GetComponent<TMP_InputField>().text) ;
        int colNum = int.Parse(columnInput.GetComponent<TMP_InputField>().text) ;
        string result = sql.ReadData(tableName, rowNum, colNum);
        output.GetComponent<TMP_Text> ().text = "Output: " + result;
        message.GetComponent<TMP_Text>().text = "Message: ";
    }

    public void BtnAdd()
    {
        string tableName = tableInput.GetComponent<TMP_InputField>().text;
        int colNum = int.Parse(columnInput.GetComponent<TMP_InputField>().text);
        string newData = dataInput.GetComponent<TMP_InputField>().text;
        bool result = sql.AddData(tableName, colNum, newData);
        if (result) 
        {
            output.GetComponent<TMP_Text>().text = "Output: ";
            message.GetComponent<TMP_Text>().text = "Message: Done";
        }
    }

    public void BtnUpdate()
    {
        string tableName = tableInput.GetComponent<TMP_InputField>().text;
        int rowNum = int.Parse(rowInput.GetComponent<TMP_InputField>().text);
        int colNum = int.Parse(columnInput.GetComponent<TMP_InputField>().text);
        string newData = dataInput.GetComponent<TMP_InputField>().text;
        bool result = sql.UpdateData(tableName, rowNum, colNum, newData);
        if (result)
        {
            output.GetComponent<TMP_Text>().text = "Output: ";
            message.GetComponent<TMP_Text>().text = "Message: Done";
        }
    }

    public void BtnDelete()
    {
        string tableName = tableInput.GetComponent<TMP_InputField>().text;
        int rowNum = int.Parse(rowInput.GetComponent<TMP_InputField>().text);
        int colNum = int.Parse(columnInput.GetComponent<TMP_InputField>().text);
        string newData = dataInput.GetComponent<TMP_InputField>().text;
        bool result = sql.DeleteData(tableName, rowNum, colNum);
        if (result)
        {
            output.GetComponent<TMP_Text>().text = "Output: ";
            message.GetComponent<TMP_Text>().text = "Message: Done";
        }
    }

    public void BtnRemove()
    {
        string tableName = tableInput.GetComponent<TMP_InputField>().text;
        int rowNum = int.Parse(rowInput.GetComponent<TMP_InputField>().text);
        bool result = sql.RemoveRow(tableName, rowNum);
        if (result)
        {
            output.GetComponent<TMP_Text>().text = "Output: ";
            message.GetComponent<TMP_Text>().text = "Message: Done";
        }
    }
}
