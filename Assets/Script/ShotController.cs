using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShotController : MonoBehaviour
{
    #region Properties

        [SerializeField, Header("バーチャルカメラ")] CinemachineVirtualCamera[] _cVCamera;
        [SerializeField,Header("撃つ弾")] GameObject _bullet;
        [SerializeField,Header("バズーカー")] GameObject _bazooka;
        [SerializeField,Header("弾の強さ")] int _power = 700;
        [SerializeField] GameObject _scope;
        [SerializeField] GameObject _camera;
        
        float _cameraChangeTime = 0.6f;
        int _fireCount = 0;
        bool IsFire = false;
        bool IsCameraChuck = true;

        #endregion

        #region Unity Methods
        void Update()
        {
            Fire();
        }
        #endregion

        #region Private Methods
        void Fire()
        {
            if (Input.GetMouseButton(0))
            {
                _cVCamera[1].Priority = 10;
                _cameraChangeTime -= Time.deltaTime;

                if (IsCameraChuck)
                {
                    _cVCamera[1].GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = 0;
                    _cVCamera[1].GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = 0;
                    IsCameraChuck = false;
                }
            }

            else if (Input.GetMouseButtonUp(0) && _cameraChangeTime >= 0)
            {
                _cVCamera[0].Priority = 10;
                _cVCamera[1].Priority = 0;
                _cameraChangeTime = 0.6f;
            }

            if (_cameraChangeTime <= 0)
            {
                IsFire = true;
            }

            if (Input.GetMouseButton(0) && IsFire)
            {
                _bazooka.SetActive(false);
                _scope.SetActive(true);
            }

            else if (Input.GetMouseButtonUp(0) && IsFire)
            {
                _bazooka.SetActive(true);
                _fireCount++;
                GameObject bullet = Instantiate(_bullet, new Vector3(0, 0.25f, 1), _camera.transform.rotation);
                bullet.GetComponent<Bullet>().Shoot(_power);
                _scope.SetActive(false);
                IsFire = false;
                _cVCamera[1].Priority = 0;
                IsCameraChuck = true;
                _cameraChangeTime = 0.6f;
            }

        }
}
        #endregion
