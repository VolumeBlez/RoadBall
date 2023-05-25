using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMainLogic : MonoBehaviour
{
    private CameraRotate _rotateCamera;
    private BallStateData _stateData;
    private BallData _data;
    private Rigidbody2D _rb;

    public Action<int> TurnCountChanged;

    public void Init(CameraRotate rotateCamera, BallStateData stateData, BallData data) 
    {
        _stateData = stateData;
        _data = data;
        _rotateCamera = rotateCamera;

        _rb = GetComponent<Rigidbody2D>();

        _stateData.CurrentDirection = Vector2.up;
        _rotateCamera = rotateCamera;
        _stateData.CurrentSpeed = _data.DefaultSpeed;

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
        _rotateCamera.RandomRotateRelease();
        _stateData.CurrentDirection = _stateData.DirectionToTurn;

        _stateData.CountTurns++;
        TurnCountChanged?.Invoke(_stateData.CountTurns);

        _stateData.CurrentSpeed += _data.SpeedModifyFromTurns.Evaluate(_stateData.CountTurns * _data.ModifyMultiplier);
    }
}
