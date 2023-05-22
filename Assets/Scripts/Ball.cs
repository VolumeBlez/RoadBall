
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private AnimationCurve _speedMultiply;
    private CameraRotate _rotateCamera;

    private Rigidbody2D _rb;
    private Vector2 _directionToTurn;
    private Vector2 _currentDirection;

    public Action OnPlayerCollidedWithWall;

    public void Init(CameraRotate rotateCamera) 
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentDirection = Vector2.up;
        _rotateCamera = rotateCamera;
    }

    private void FixedUpdate() 
    {
        _rb.MovePosition(_rb.position + _currentDirection * _defaultSpeed * Time.fixedDeltaTime);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChangeCurrentDirection();
        }
    }

    public void ChangeDirectionToTurn(Vector2 newDirection)
    {
        _directionToTurn = newDirection;
    }

    private void ChangeCurrentDirection()
    {
        _rotateCamera.RandomRotate();
        _currentDirection = _directionToTurn;
        Debug.Log($"Current {_currentDirection}");
        Debug.Log($"To Turn {_directionToTurn}");
    }

    private void Rotate() 
    {
        Debug.Log("Rotate");
        float rotZ = Mathf.Atan2(_directionToTurn.y, _directionToTurn.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(rotZ - 90f);
    } 


    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    
}
