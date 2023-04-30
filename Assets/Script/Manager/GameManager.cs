using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // [SerializeField] 
    // private GameObject _gameClearUI;
    //
    // [SerializeField] 
    // private GameObject _gameOverUI;
    
    public event Action OnGameClear;

    public event Action OnGameOver;

    private bool IsGameFinish;

    public void GameClear()
    {
        if (IsGameFinish)
        {
            Debug.Log(IsGameFinish);
            Debug.Log("すでにゲームがクリア又はゲームオーバーしているのGameClear()は呼び出せません");
            return;
        }
        Debug.Log("Unity");
        //_gameClearUI?.SetActive(true);
        IsGameFinish = true;
        OnGameClear?.Invoke();
    }

    public void GameOver()
    {
        if (IsGameFinish)
        {
            Debug.Log("すでにゲームがクリア又はゲームオーバーしているのGaneOver()は呼び出せません");
            return;
        }
        //_gameOverUI.SetActive(true);
        IsGameFinish = true;
        OnGameOver?.Invoke();
    }

    public void FlagReset()
    {
        IsGameFinish = false;
        Debug.Log("Resetしたよ");
    }
}
