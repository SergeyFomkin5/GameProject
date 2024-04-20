using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static float Currency;
    public TextMeshProUGUI CurrencyTXT;
    public Text CurrencyTXTtest;

    private void Start()
    {
        CurrencyTXT.text = "$: " + Currency.ToString();
        CurrencyTXTtest.text = "$: " + Currency.ToString();
    }

    //void Update()
    //{
    //    CurrencyTXT.text = "$:" + Currency.ToString();
    //}

    public void AddCredits()
    {

        Currency += 10;

        Debug.Log("+");

        CurrencyTXT.text = "$:" + Currency.ToString();

    }

    public void minusCredits()
    {

        Currency -= 10;

        Debug.Log("-");

        CurrencyTXT.text = "$:" + Currency.ToString();

    }
}
