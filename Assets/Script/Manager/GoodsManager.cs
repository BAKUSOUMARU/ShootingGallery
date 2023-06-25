using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    #region Properties
    // �v���p�e�B������B
    #endregion

    #region Inspector Variables
    [Header("�z�u����i�i")]
    [SerializeField]
    Goods[] _goodsList = default;

    [Header("�z�u�ʒu�̃��X�g")]
    [Tooltip("��i�ڂɌi�i��z�u����ʒu")]    
    [SerializeField]
    private Transform[] _deploymentTransforms_First = default;

    [Tooltip("��i�ڂɌi�i��z�u����ʒu")]
    [SerializeField]
    private Transform[] _deploymentTransforms_Second = default;

    [Tooltip("�O�i�ڂɌi�i��z�u����ʒu")]
    [SerializeField]
    private Transform[] _deploymentTransforms_Third = default;

    [Space(10)]

    [Tooltip("�i�i�I�u�W�F�N�g���܂Ƃ߂�e�I�u�W�F�N�g")]
    [SerializeField]
    Transform _goodsParent = default;
    #endregion

    #region Member Variables
    private List<Goods> _firstGoodsList = new List<Goods>();
    private List<Goods> _secondGoodsList = new List<Goods>();
    private List<Goods> _thirdGoodsList = new List<Goods>();
    #endregion

    #region Constant
    // �萔�������B
    #endregion

    #region Events
    //  System.Action, System.Func �Ȃǂ̃f���Q�[�g��R�[���o�b�N�֐��������Ƃ���B
    #endregion

    #region Enums
    // �񋓌^������B
    #endregion

    #region Unity Methods
    //  Start, Update�Ȃǂ�Unity�̃C�x���g�֐��B
    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        
    }
    #endregion
    
    #region Public Methods
    //�@���g�ō쐬����Public�Ȋ֐�������B
    #endregion
    
    #region Private Methods
    // ���g�ō쐬����Private�Ȋ֐�������B
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
