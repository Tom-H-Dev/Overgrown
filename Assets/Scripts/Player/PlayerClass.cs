using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerClass : MonoBehaviour
{
    [Header("Player Level Stats")]
    public int playerLevel = 1;
    public float expAmountNeededForLevelUp = 100;
    public int playerExp = 0;
    private const int expOrbAmount = 5;

    [Header("Player Level UI")]
    public Image expProgress;


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
                Debug.Log("increase level");
                int l_expOvershot = l_expIncrease - (int)l_currentExpNeededForLevelUp;
                StartCoroutine(ExpProgressBarLerp(1));

                StartCoroutine(LevelUpClass(l_expOvershot));
            }
        }
        else
        {
            playerExp += l_expIncrease;
            float l_currentExpProgress = playerExp / expAmountNeededForLevelUp;
            StartCoroutine(ExpProgressBarLerp(l_currentExpProgress));
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
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Level Up!");
        playerLevel++;
        expAmountNeededForLevelUp = Mathf.RoundToInt(expAmountNeededForLevelUp * 1.5f);
        playerExp = 0;
        expProgress.rectTransform.localScale = new Vector3(0, 1, 1);
        playerExp += l_expOvershot;
        float l_currentExpProgress = playerExp / expAmountNeededForLevelUp;
        StartCoroutine(ExpProgressBarLerp(l_currentExpProgress));
    }
}
