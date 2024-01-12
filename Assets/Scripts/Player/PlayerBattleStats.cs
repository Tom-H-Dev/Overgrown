using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBattleStats : MonoBehaviour
{
    #region Singleton
    public static PlayerBattleStats instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private float _baseMP = 10;

    public float curHP;
    public float curMP;
    public float curSPD;

    [SerializeField] private Image _healthbar;
    private int _healthbarPixelMultiplier = 30;

    public PlayerClassStats playerStats;

    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _combatMenu;

    private void Start()
    {
        curHP = playerStats.health;
        curMP = _baseMP;
        curSPD = playerStats.speed;
    }

    /// <summary>
    /// Change the health of the player
    /// </summary>
    /// <param name="l_hpDifference"></The difference that changes the health>
    public void ChangeHpFromOther(float l_hpDifference)
    {
        float l_checkIfHealing = curHP - l_hpDifference;
        float l_defenseRemove = playerStats.defense;
        for (int i = 0; i < l_defenseRemove; i++)
        {
            l_hpDifference *= 0.9f;
        }

        if (l_hpDifference >= curHP) //dead
        {
            curHP = 0;
            StartCoroutine(DeathMessage());
        }
        else if (l_hpDifference == 0 || l_checkIfHealing >= playerStats.health)
        {
            curHP = playerStats.health;
            _healthbar.rectTransform.sizeDelta = new Vector2((curHP / playerStats.health) * 300, 50);
        }
        else
        {
            curHP -= l_hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2((curHP / playerStats.health) * 300, 50);
        }
    }

    /// <summary>
    /// Sends the death message and sets back to main menu
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeathMessage()
    {
        _combatMenu.SetActive(false);
        _deathMenu.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }
}
