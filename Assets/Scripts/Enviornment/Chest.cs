using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Chest : MonoBehaviour
{
    [Header("UI Stuff")]
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _chestHasOpened = false;
    [SerializeField] private PlayerClass _player;
    [SerializeField] private bool _inInteractionArea = false;

    private void Update()
    {
        if (_inInteractionArea && !_chestHasOpened)
        {
            if (InputManager.instance.KeyPressed("interact"))
            {
                Debug.Log("Opened Chest");
                _chestHasOpened = true;
                DropInteractText();

                _player.ChangePlayerExp(10);

                for (int i = 0; i < PlayerInventory.instance.inventoryPotions.Count; i++)
                {
                    Potion l_type = PlayerInventory.instance.inventoryPotions[i].GetComponent<Potion>();
                    l_type.AddPotionToInv(2, l_type);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_chestHasOpened && other.TryGetComponent(out PlayerClass l_player))
        {
            _player = l_player;
            _animator.SetTrigger("InteractUp");
            _inInteractionArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!_chestHasOpened && other.TryGetComponent(out PlayerClass l_player))
        {
            _animator.SetTrigger("InteractDown");
            _inInteractionArea = false;
        }
    }

    private void DropInteractText()
    {
        _animator.SetTrigger("InteractDown");
        _inInteractionArea = false;
    }
}
