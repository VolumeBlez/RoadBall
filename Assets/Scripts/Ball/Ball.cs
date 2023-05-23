using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallData _data;
    [SerializeField] private BallMainLogic _logic;
    [SerializeField] private BallCheckCollision _checkCollision;
    [SerializeField] private UserInput _input;

    private BallStateData _stateData;

    public BallMainLogic Logic => _logic;
    public BallCheckCollision DeathCollisionCheck => _checkCollision;

    public void Init(CameraRotate rot) 
    {
        _stateData = new();

        _logic.Init(rot, _stateData, _data);
        _input.Init(_logic);
    }
}
