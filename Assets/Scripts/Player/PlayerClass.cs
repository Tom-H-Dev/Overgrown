using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerClass : MonoBehaviour
{
    [Header("Player Level Stats")]
    public int playerLevel = 1;
    public float expAmountNeededForLevelUp = 100;
    public int playerExp = 0;
    private const int expOrbAmount = 1;
    public PlayerClassStats playerStats;

    [Header("Player Level UI")]
    public Image expProgress;
    private UIManager uiManager;

    [Header("Attack System")]
    public bool attack2OnCooldown = false;
    public bool attack4OnCooldown = false;
    public bool attack6OnCooldown = false;

    public int rechargeTime2 = 2;
    public int rechargeTime4 = 2;
    public int rechargeTime6 = 2;

    public int turnsLeftToRecharge2;
    public int turnsLeftToRecharge4;
    public int turnsLeftToRecharge6;

    private void Start()
    {
        uiManager = UIManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangePlayerExp(6);
        }
    }

    public virtual void ChangePlayerExp(int l_orbAmount)
    {
        int l_expIncrease = l_orbAmount * expOrbAmount;
        float l_currentExpNeededForLevelUp = Mathf.RoundToInt(expAmountNeededForLevelUp - playerExp);

        if (l_expIncrease >= l_currentExpNeededForLevelUp)
        {
            if (l_expIncrease > l_currentExpNeededForLevelUp)
            {
                //StartCoroutine(XpBarStateChange("xpbarup"));
                Debug.Log("increase level");
                int l_expOvershot = l_expIncrease - (int)l_currentExpNeededForLevelUp;
                StartCoroutine(ExpProgressBarLerp(1));

                StartCoroutine(LevelUpClass(l_expOvershot));
                //StartCoroutine(XpBarStateChange("xpbardown"));
            }
            else
            {
                //StartCoroutine(XpBarStateChange("xpbarup"));
                Debug.Log("increase level");
                StartCoroutine(ExpProgressBarLerp(1));
                StartCoroutine(LevelUpClass(0));
                //StartCoroutine(XpBarStateChange("xpbardown"));
            }
        }
        else
        {
            //StartCoroutine(XpBarStateChange("xpbarup"));
            playerExp += l_expIncrease;
            float l_currentExpProgress = playerExp / expAmountNeededForLevelUp;
            StartCoroutine(ExpProgressBarLerp(l_currentExpProgress));
            //StartCoroutine(XpBarStateChange("xpbardown"));
        }

    }

    private IEnumerator ExpProgressBarLerp(float l_currentExpProgress)
    {
        float l_t = 0;
        float l_maxTime = 0.5f;
        while (l_t < l_maxTime)
        {
            l_t += Time.deltaTime;
            if (l_t > l_maxTime) l_t = l_maxTime;

            expProgress.rectTransform.localScale = Vector3.Lerp(expProgress.rectTransform.localScale, new Vector3(l_currentExpProgress, 1, 1), l_t);
            yield return null;

        }
    }

    public virtual IEnumerator LevelUpClass(int l_expOvershot)
    {
        playerLevel++;

        #region Stat Increase
        uiManager.healthOld.text = "Health " + playerStats.health;
        uiManager.speedOld.text = "Speed " + playerStats.speed;
        uiManager.strengthOld.text = "Strength " + playerStats.strength;
        uiManager.defenseOld.text = "Defense " + playerStats.defense;

        FieldInfo[] fields = typeof(PlayerClassStats).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(float))
            {
                float originalValue = (float)field.GetValue(playerStats);

                originalValue += 5;
                field.SetValue(playerStats, originalValue);
            }
        }

        uiManager.healthNew.text = playerStats.health.ToString();
        uiManager.strengthNew.text = playerStats.strength.ToString();
        uiManager.speedNew.text = playerStats.speed.ToString();
        uiManager.defenseNew.text = playerStats.defense.ToString();
        #endregion

        uiManager.levelReachText.text = "Level " + playerLevel + " Reached!";

        uiManager.OnOpenLevelUpMenu();

        yield return new WaitForSeconds(0.5f);
        #region playerxp overshot
        expAmountNeededForLevelUp = Mathf.RoundToInt(expAmountNeededForLevelUp * 1.5f);
        playerExp = 0;
        expProgress.rectTransform.localScale = new Vector3(0, 1, 1);
        playerExp += l_expOvershot;
        float l_currentExpProgress = playerExp / expAmountNeededForLevelUp;
        StartCoroutine(ExpProgressBarLerp(l_currentExpProgress));
        #endregion
    }

    public IEnumerator XpBarStateChange(string l_type)
    {
        PlayerClassChoice.instance.animator.SetTrigger(l_type);
        yield return new WaitForSeconds(0.5f);
    }
}
