using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class ShotController : MonoBehaviour
{
    public int GameOverCount => _gameOverCount;
    public int FireCount => _fireCount;
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

        [FormerlySerializedAs("firePoint")] [SerializeField] 
        private GameObject _firePoint;
        
        float _cameraChangeTime = 0.6f;
        int _fireCount = 0;
        bool _isFire = false;
        bool _isCameraChuck = true;
        bool gameClear = false;

        private float _gameClearWaitTime = 1f;
        
        #endregion

        #region Unity Methods

        void Update()
        {
            Fire();
        }
        #endregion

        #region Private Methods

        // ReSharper disable Unity.PerformanceAnalysis
        void Fire()
        {
            if (_fireCount >= _gameOverCount)
            {
                _cVCamera[0].Priority = 10;
                _cVCamera[1].Priority = 0;
                _gun.SetActive(true);
                _firePoint.SetActive(false);
                _gameClearWaitTime -= Time.deltaTime;
                if (_gameClearWaitTime <= 0)
                {
                    if (gameClear)
                    {
                        return;
                    }

                    gameClear = true;
                    GameManager.Instance.GameClear();
                }
                return;
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    _cVCamera[1].Priority = 10;
                    _cameraChangeTime -= Time.deltaTime;

                    if (_isCameraChuck)
                    {
                        _cVCamera[1].GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = 0;
                        _cVCamera[1].GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = 0;
                        _isCameraChuck = false;
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
                    _isFire = true;
                }
                if (Input.GetMouseButton(0) && _isFire)
                {
                    _gun.SetActive(false);
                    _firePoint.SetActive(true);
                }
                else if (Input.GetMouseButtonUp(0) && _isFire)
                {
                    Vector3 firepoint = new Vector3(_cVCamera[1].transform.position.x,
                        _cVCamera[1].transform.position.y, _cVCamera[1].transform.position.z + 0.2f);
                    GameObject bullet = Instantiate(_bullet, firepoint, _camera.transform.rotation);
                    _firePoint.SetActive(false);
                    _fireCount++;
                    bullet.GetComponent<Bullet>().Shoot(_power);
                    _isFire = false;
                    _cVCamera[1].Priority = 0;
                    _isCameraChuck = true;
                    _cameraChangeTime = 0.6f;
                    _gun.SetActive(true);
                }
            }
        }
}
        #endregion
