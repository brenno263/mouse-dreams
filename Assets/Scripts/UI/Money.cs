using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Money : MonoBehaviour
{

    public GameObject MoneyObject;
    public float CurrentMoney = 0f;

    void Start()
    {
        //MoneyObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + CurrentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + CurrentMoney.ToString();
    }
}
