using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Button attackButton;
    public TextMeshProUGUI turnText;
    

    

    [Header("UI elements attack order")]
    [SerializeField] private GameObject _whatEnemy;
    public void AttackButton()
    {
        StartCoroutine(AttackFunctionality());
    }

    public IEnumerator AttackFunctionality()
    {
        _whatEnemy.SetActive(true);

        attackButton.interactable = false;
        yield return null;
    }


   
}