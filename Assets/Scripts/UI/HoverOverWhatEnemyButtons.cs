using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverWhatEnemyButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    [SerializeField] private GameObject arrowEnemy;


    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        if (!GameManager.instance.hasBeenSelectedEnemy)
        {
            arrowEnemy.SetActive(true);
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (!GameManager.instance.hasBeenSelectedEnemy)
        {
            arrowEnemy.SetActive(false);
        }
    }

    public void SelectButtonOption(int enemyNumber)
    {
        GameManager.instance.hasBeenSelectedEnemy = true;
        arrowEnemy.SetActive(true);
        GameManager.instance.selectedEnemy = enemyNumber;
    }
}
