using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSet : MonoBehaviour
{
    [SerializeField] 
    private GameObject _gameclearUi;
    
    void Start()
    {
        GameManager.Instance.OnGameClear += GameClearUiActive;
    }

    void GameClearUiActive()
    {
        _gameclearUi.SetActive(true);
        Debug.Log(" 動いた");
    }

    void GameClearUIInactive()
    {
        _gameclearUi.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameClear -= GameClearUiActive;
    }
}
