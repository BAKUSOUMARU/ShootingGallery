using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Serialization;

public class RemainingBulletsPresenter : MonoBehaviour
{
    [SerializeField] private ShotController shotController;

    [SerializeField] private RemainingbulletsView remainingbulletsView;
    // Start is called before the first frame update
    void Start()
    {
        shotController.ObserveEveryValueChanged(x => shotController.FireCount)
            .Subscribe(x => remainingbulletsView.TextUpdate( shotController.GameOverCount- x)).AddTo(this);
    }
}
