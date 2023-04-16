using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class ShotController : MonoBehaviour
{
    #region Properties

        [SerializeField] 
        GameObject _camera;
       
        [SerializeField, Header("バーチャルカメラ")] 
        CinemachineVirtualCamera[] _cVCamera;
        
        [SerializeField,Header("撃つ弾")] 
        GameObject _bullet;
        
        [SerializeField,Header("銃")] 
        GameObject _gun;
        
        [SerializeField,Header("弾の打てる数")] 
        private int _gameOverCount; 
        
        [SerializeField,Header("弾の強さ")] 
        int _power = 700;
        
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
            if (_fireCount >= _gameOverCount)
                return;
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
                float cashTime = _cameraChangeTime;
                _cVCamera[0].Priority = 10;
                _cVCamera[1].Priority = 0;
                _cameraChangeTime = cashTime;
            }

            if (_cameraChangeTime <= 0)
            {
                IsFire = true;
            }

            if (Input.GetMouseButton(0) && IsFire)
            {
                _gun.SetActive(false);
            }

            else if (Input.GetMouseButtonUp(0) && IsFire)
            {
                _gun.SetActive(true);
                _fireCount++;
                GameObject bullet = Instantiate(_bullet, new Vector3(0, 0.25f, 1), _camera.transform.rotation);
                bullet.GetComponent<Bullet>().Shoot(_power);
                IsFire = false;
                _cVCamera[1].Priority = 0;
                IsCameraChuck = true;
                _cameraChangeTime = 0.6f;
            }

        }
}
        #endregion
