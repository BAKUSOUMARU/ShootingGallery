using UnityEngine;


public class Bullet : MonoBehaviour
{
    Vector3 _bombInstantiatePosition;//爆発エフェクトを使用する場合のVector3

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Goods ai))
        {
            _bombInstantiatePosition = this.transform.position;
            ScoreModel.Instance.AddScore(10);
        }
    }

    #region Public Methods
    public void Shoot(float Power)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Power;
    }
    #endregion
}
