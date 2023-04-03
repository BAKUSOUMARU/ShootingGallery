using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private ScoreModel _model;

    [SerializeField]
    private ScoreView _view;
    
    private void Start()
    {
        _model.Score.Subscribe(x =>
        {
            _view.TextUpdate(x);
        }).AddTo(this);
    }
}
