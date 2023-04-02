using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bomb;
    [SerializeField] GameObject _explosion;

    Vector3 _bombInstantiatePosition;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Build")
        {
            _bombInstantiatePosition = this.transform.position;
            Instantiate(_explosion, _bombInstantiatePosition, transform.rotation);
            Instantiate(_bomb, _bombInstantiatePosition, transform.rotation);
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
