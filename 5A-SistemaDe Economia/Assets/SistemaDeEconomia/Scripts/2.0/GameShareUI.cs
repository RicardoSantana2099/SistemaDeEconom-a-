using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameShareUI : MonoBehaviour
{
    #region Singleton class: GameSharedUI

    public static GameShareUI Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] TMP_Text[] coinsUIText;

    private void Start()
    {
        UpdateCoinsUIText();
    }

    public void UpdateCoinsUIText()
    {
        for (int i = 0; i < coinsUIText.Length; i++)
        {
            SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
        }
    }

    void SetCoinsText(TMP_Text textMesh, int value)
    {
        if (value >= 1000)
            textMesh.text = string.Format("{0}K.{1}", (value / 1000), GetFirstDigitFromNumber(value % 1000));
        else
            textMesh.text = value.ToString();
  
    }

    int GetFirstDigitFromNumber(int num)
    {
        return int.Parse(num.ToString()[0].ToString());
    }
}
