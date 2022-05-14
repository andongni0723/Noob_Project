using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI coinNumText;

    public int coinNum;

    private void Awake()
    {
        instance = this;
    }
    
    private void Update()
    {
        showCoinNumTOUI();
    }

    private void showCoinNumTOUI()
    {
        coinNumText.text = coinNum.ToString();
    }

    public void GetCoin()
    {
        coinNum++;
    }
}
