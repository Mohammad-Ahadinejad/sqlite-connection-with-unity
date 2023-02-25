using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitializeInputFields : MonoBehaviour
{
    public GameObject tableInput;
    public GameObject rowInput;
    public GameObject columnInput;
    public GameObject dataInput;

    void Start()
    {
        tableInput.GetComponent<TMP_InputField>().text = "table_1";
        rowInput.GetComponent<TMP_InputField>().text = "1";
        columnInput.GetComponent<TMP_InputField>().text = "1";
        dataInput.GetComponent<TMP_InputField>().text = "test";
    }
}
