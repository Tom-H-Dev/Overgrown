using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Button attackButton;
    public TextMeshProUGUI turnText;
    [Header("Player Battle UI")]
    [SerializeField] private GameObject _attackLevel1;
    [SerializeField] private GameObject _attackLevel2, _attackLevel4, _attackLevel6, _defense;

    [Header("Player")]
    [SerializeField] private GameObject _player;

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


    public void ChangeAttackListFromLevelUp()
    {
        //TODO: This function called when attack to check what attacks the player has unlocked
        PlayerClass l_player = _player.GetComponent<PlayerClass>();
        switch (l_player.playerLevel)
        {
            case 1:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(false);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 2:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 3:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 4:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 5:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 6:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(true);
                _defense.SetActive(true);
                break;
            case >= 7:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(true);
                _defense.SetActive(true);
                break;
        }
    }
}