using UnityEngine;


public class Bullet : MonoBehaviour
{
    Vector3 _bombInstantiatePosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            _bombInstantiatePosition = this.transform.position; 
            ScoreModel.Instance.AddScore(10);
            Destroy(this.gameObject);
        }
    }

    #region Public Methods
    public void Shoot(float Power)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Power;
    }
    #endregion
}
