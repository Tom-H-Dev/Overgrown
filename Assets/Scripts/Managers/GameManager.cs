using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        //if (instance != null)
        //    Destroy(instance);
        //else instance = this;
        instance = this;
    }
    #endregion

    public bool canMovePlayer = true;
    public bool hasBeenSelectedEnemy= false;
    public int selectedEnemy = 0;
    [SerializeField] public GameObject combatCanvas;
}
