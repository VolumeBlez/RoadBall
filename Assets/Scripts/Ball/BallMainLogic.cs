using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMainLogic : MonoBehaviour
{
    private CameraRotate _rotateCamera;
    private BallStateData _stateData;
    private BallData _data;
    private Rigidbody2D _rb;

    public void Init(CameraRotate rotateCamera, BallStateData stateData, BallData data) 
    {
        _stateData = stateData;
        _data = data;
        _rotateCamera = rotateCamera;

        _stateData.CurrentDirection = Vector2.up;
        _rotateCamera = rotateCamera;
        _stateData.CurrentSpeed = _data.DefaultSpeed;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        _rb.MovePosition(_rb.position + _stateData.CurrentDirection * _stateData.CurrentSpeed * Time.fixedDeltaTime);
    }


    public void ChangeDirectionToTurn(Vector2 newDirection)
    {
        _stateData.DirectionToTurn = newDirection;
    }

    public void ChangeCurrentDirection()
    {
        _rotateCamera.RandomRotate();
        _stateData.CurrentDirection = _stateData.DirectionToTurn;
        _stateData.CountTurns++;

        _stateData.CurrentSpeed += _data.SpeedModifyFromTurns.Evaluate(_stateData.CountTurns++ * _data.ModifyMultiplier);
        Debug.Log(_stateData.CurrentSpeed);
    }

    private void Rotate() 
    {
        Debug.Log("Rotate");
        float rotZ = Mathf.Atan2(_stateData.DirectionToTurn.y, _stateData.DirectionToTurn.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(rotZ - 90f);
    } 


}
