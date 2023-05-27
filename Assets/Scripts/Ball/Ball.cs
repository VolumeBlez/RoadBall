
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallData _data;
    [SerializeField] private BallMainLogic _logic;
    [SerializeField] private BallCheckCollision _checkCollision;

    private BallStateData _stateData;
    private BallBestScoreChanger _bestScoreChanger;

    public BallBestScoreChanger BestScoreChanger => _bestScoreChanger;
    public BallMainLogic Logic => _logic;
    public BallCheckCollision DeathCollisionCheck => _checkCollision;

    public void Init(CameraRotate rot) 
    {
        _stateData = new();
        _bestScoreChanger = new(this, _stateData);

        _logic.Init(rot, _stateData, _data);
    }
}
