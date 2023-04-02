using UnityEngine;


public class Bullet : MonoBehaviour
{
    Vector3 _bombInstantiatePosition;
    //private void OnCollisionEnter(Collision collision)
    //{
      //  if (collision.gameObject.tag == "")
        //{
          //  _bombInstantiatePosition = this.transform.position;
            //Destroy(this.gameObject);
        //}
   // }

    #region Public Methods
    public void Shoot(float Power)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Power;
    }
    #endregion
}
