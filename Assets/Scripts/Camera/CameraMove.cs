
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _movingSpeed;

    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }


    void FixedUpdate()
    {
        if(_playerTransform)
        {
            //Debug.Log("CAMERA MOVE");
            Vector3 target = new Vector3()
            {
                x = _playerTransform.position.x,
                y = _playerTransform.position.y, // focus on center scene
                z = _playerTransform.position.z - 10f,
            };

            //Vector3 pos = Vector3.Lerp(this.transform.position, target, _movingSpeed * Time.deltaTime);
            this.transform.position = target;
        }
    }
}
