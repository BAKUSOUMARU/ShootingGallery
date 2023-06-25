using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    #region Properties
    // プロパティを入れる。
    #endregion

    #region Inspector Variables
    [Header("配置する景品")]
    [SerializeField]
    Goods[] _goodsList = default;

    [Header("配置位置のリスト")]
    [Tooltip("一段目に景品を配置する位置")]    
    [SerializeField]
    private Transform[] _deploymentTransforms_First = default;

    [Tooltip("二段目に景品を配置する位置")]
    [SerializeField]
    private Transform[] _deploymentTransforms_Second = default;

    [Tooltip("三段目に景品を配置する位置")]
    [SerializeField]
    private Transform[] _deploymentTransforms_Third = default;

    [Space(10)]

    [Tooltip("景品オブジェクトをまとめる親オブジェクト")]
    [SerializeField]
    Transform _goodsParent = default;
    #endregion

    #region Member Variables
    private List<Goods> _firstGoodsList = new List<Goods>();
    private List<Goods> _secondGoodsList = new List<Goods>();
    private List<Goods> _thirdGoodsList = new List<Goods>();
    #endregion

    #region Constant
    // 定数をいれる。
    #endregion

    #region Events
    //  System.Action, System.Func などのデリゲートやコールバック関数をいれるところ。
    #endregion

    #region Enums
    // 列挙型を入れる。
    #endregion

    #region Unity Methods
    //  Start, UpdateなどのUnityのイベント関数。
    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        
    }
    #endregion
    
    #region Public Methods
    //　自身で作成したPublicな関数を入れる。
    #endregion
    
    #region Private Methods
    // 自身で作成したPrivateな関数を入れる。
    void Generate()
    {
        for (int i = 0; i < _deploymentTransforms_First.Length; i++)
        {
            int randomIndex = Random.Range(0, _goodsList.Length);

            Goods goods = Instantiate(_goodsList[randomIndex], _goodsParent);
            goods.transform.position = _deploymentTransforms_First[i].position;
            _firstGoodsList.Add(goods);
        }

        for (int i = 0; i < _deploymentTransforms_First.Length; i++)
        {
            int randomIndex = Random.Range(0, _goodsList.Length);

            Goods goods = Instantiate(_goodsList[randomIndex], _goodsParent);
            goods.transform.position = _deploymentTransforms_Second[i].position;
            _secondGoodsList.Add(goods);
        }

        for (int i = 0; i < _deploymentTransforms_First.Length; i++)
        {
            int randomIndex = Random.Range(0, _goodsList.Length);

            Goods goods = Instantiate(_goodsList[randomIndex], _goodsParent);
            goods.transform.position = _deploymentTransforms_Third[i].position;
            _thirdGoodsList.Add(goods);
        }
    }
    #endregion
}
