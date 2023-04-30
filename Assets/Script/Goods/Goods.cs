using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Goods : MonoBehaviour
{
    #region Properties
    public Type GoodsType => _goodsType;
    #endregion

    #region Inspector Variables
    [SerializeField]
    private Type _goodsType = default;
    #endregion
    
    #region Member Variables
    // プライベートなメンバー変数。

    #endregion
    
    #region Constant
    // 定数をいれる。
    #endregion
    
    #region Events
    //  System.Action, System.Func などのデリゲートやコールバック関数をいれるところ。
    #endregion
    
    #region Enums
    /// <summary>
    /// グッズの種類
    /// </summary>
    public enum Type
    {
        //※仮で名前を付けているだけなので、現状はリストの修正はいつでも可

        /// <summary>ぬいぐるみ</summary>
        StuffedToy,
        /// <summary>お菓子</summary>
        Sweets,
        /// <summary>Toy</summary>
        Toy
    }
    #endregion

    #region Unity Methods
    //  Start, UpdateなどのUnityのイベント関数。

    private void Start()
    {
        ChangeMaterial(_goodsType); 
    }
    #endregion

    #region Public Methods
    //　自身で作成したPublicな関数を入れる。
    #endregion

    #region Private Methods
    // 自身で作成したPrivateな関数を入れる。

    void ChangeMaterial(Type type)
    {
        var renderer = GetComponent<Renderer>();

        switch (type)
        {
            case Type.StuffedToy:
                renderer.material.color = Color.blue;
                break;
            case Type.Sweets:
                renderer.material.color = Color.green;
                break;
            case Type.Toy:
                renderer.material.color = Color.yellow;
                break;
            default:
                break;
        }
    }
    #endregion
}
