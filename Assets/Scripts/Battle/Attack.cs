using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Button attackButton;
    public TextMeshProUGUI turnText;
    public void AttackButton()
    {
        StartCoroutine(AttackFunctionality());
    }

    public IEnumerator AttackFunctionality()
    {
        TurnManager.instance.turns = PlayerTurns.enemyturn;
        attackButton.interactable = false;
        turnText.text = "Enemy Turn!";
        yield return null;
    }
}
