using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPageItem : MonoBehaviour
{
    #region singleton
    public static InfoPageItem instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion


    [Header("UI Components")]
    public TextMeshProUGUI itemTitle;
    public TextMeshProUGUI itemDescription;
    public Image itemImage;
    public TextMeshProUGUI statIncreaseText;
    public Potion potionScript;
    public string potionType;

    public void ItemUseButton()
    {
        string l_potionType = potionType;
        Debug.Log(potionScript);
        potionScript.OnPotionUse();
    }
}
