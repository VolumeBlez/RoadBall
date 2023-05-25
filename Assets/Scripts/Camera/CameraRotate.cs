
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;
    private bool _isRotateActive = false;
    private Quaternion _targetRotate = Quaternion.identity;

    public void RandomRotateRelease()
    {
        _isRotateActive = true;
    }

    private void SetRandomRotate()
    {
        _targetRotate = Quaternion.Euler(0, 0, Random.Range(-50, 50));
    }

    private void ResetRotateTarget()
    {
        _targetRotate = Quaternion.identity;
        _isRotateActive = false;
    }

    private void Update() 
    {
        if(_isRotateActive)
        {
            if(_targetRotate == Quaternion.identity)
                SetRandomRotate();
            
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotate, Time.deltaTime * _rotateSpeed);
            if(transform.rotation == _targetRotate)
                ResetRotateTarget();

        }
    }
}
