using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingbulletsView : MonoBehaviour
{
    [SerializeField]
    [Header("残段数を表示させる")]
    private Text _text;

    public void TextUpdate(int Shotcount)
    {
        _text.text = "残り打てる残弾" + Shotcount;
    }
}
