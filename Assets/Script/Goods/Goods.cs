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
    // �v���C�x�[�g�ȃ����o�[�ϐ��B
    #endregion
    
    #region Constant
    // �萔�������B
    #endregion
    
    #region Events
    //  System.Action, System.Func �Ȃǂ̃f���Q�[�g��R�[���o�b�N�֐��������Ƃ���B
    #endregion
    
    #region Enums
    /// <summary>
    /// �O�b�Y�̎��
    /// </summary>
    public enum Type
    {
        //�����Ŗ��O��t���Ă��邾���Ȃ̂ŁA����̓��X�g�̏C���͂��ł���

        /// <summary>�ʂ������</summary>
        StuffedToy,
        /// <summary>���َq</summary>
        Sweets,
        /// <summary>Toy</summary>
        Toy
    }
    #endregion

    #region Unity Methods
    //  Start, Update�Ȃǂ�Unity�̃C�x���g�֐��B

    private void Start()
    {
        ChangeMaterial(_goodsType);
    }
    #endregion

    #region Public Methods
    //�@���g�ō쐬����Public�Ȋ֐�������B
    #endregion

    #region Private Methods
    // ���g�ō쐬����Private�Ȋ֐�������B

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
