using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Chest : MonoBehaviour
{
    [Header("UI Stuff")]
    [SerializeField] private Animator _animator;
    private bool _chestHasOpened = false;
    private PlayerClass _player; 

    private void Update()
    {
        if (GameManager.instance.inInteractionArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Opened Chest");
                _chestHasOpened = true;
                DropInteractText();

                _player.ChangePlayerExp(10);

                AddInventoryItemManager.instance.potions = PlayerInventory.instance.healthPotion;
                AddInventoryItemManager.instance.ChangePotionAmount(2);
                AddInventoryItemManager.instance.potions = PlayerInventory.instance.speedPotion;
                AddInventoryItemManager.instance.ChangePotionAmount(2);
                AddInventoryItemManager.instance.potions = PlayerInventory.instance.strengthPotion;
                AddInventoryItemManager.instance.ChangePotionAmount(2);
                AddInventoryItemManager.instance.potions = PlayerInventory.instance.defensePotion;
                AddInventoryItemManager.instance.ChangePotionAmount(2);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_chestHasOpened && other.TryGetComponent(out PlayerClass l_player))
        {
            _player = l_player;
            _animator.SetTrigger("InteractUp");
            GameManager.instance.inInteractionArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!_chestHasOpened && other.TryGetComponent(out PlayerClass l_player))
        {
            _animator.SetTrigger("InteractDown");
            GameManager.instance.inInteractionArea = false;
        }
    }

    private void DropInteractText()
    {
        _animator.SetTrigger("InteractDown");
        GameManager.instance.inInteractionArea = false;
    }
}
