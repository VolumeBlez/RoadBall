
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;
    public void RandomRotate()
    {
        Quaternion target = Quaternion.Euler(0, 0, Random.Range(-50f, 50f));
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _rotateSpeed);
    }
}
