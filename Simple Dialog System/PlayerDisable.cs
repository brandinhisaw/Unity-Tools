using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    static PlayerDisable _instance;

    public static PlayerDisable Instance { get { return _instance; } }

    PlayerController playerController;
    PlayerAttack playerAttack;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void DisablePlayer()
    {
        playerController.enabled = false;
        playerAttack.enabled = false;
    }

    public void EnablePlayer()
    {
        playerController.enabled = true;
        playerAttack.enabled = true;
    }
}
