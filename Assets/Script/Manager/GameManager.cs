using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameClear;

    public event Action OnGameOver;

    private bool IsGameFinish;

    public void GameClear()
    {
        if (IsGameFinish)
        {
            Debug.Log("すでにゲームがクリア又はゲームオーバーしているのGameClear()は呼び出せません");
            return;
        }
        IsGameFinish = true;
        OnGameClear?.Invoke();
    }

    public void GaneOver()
    {
        if (IsGameFinish)
        {
            Debug.Log("すでにゲームがクリア又はゲームオーバーしているのGaneOver()は呼び出せません");
            return;
        }
        IsGameFinish = true;
        OnGameOver?.Invoke();
    }
}
