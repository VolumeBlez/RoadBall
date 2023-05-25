using UnityEngine;

public class MainGameEntryPoint : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private ButtonActiveBehaviour _buttonActiveBehaviour;
    [SerializeField] private CorridorGenerator _gen;
    [SerializeField] private BallTurnDirectionChanger _changer;
    [SerializeField] private MusicPlayer _playerMusic;
    [SerializeField] private BallDeathParticleInvoker _particleInvoker;
    [SerializeField] private UserInput _input;

    [Header("Player and Camera")]
    [SerializeField] private Ball _ballPref;
    [SerializeField] private Vector2 _ballStartPos = new Vector2(1.5f, -3.5f);
    [SerializeField] private CameraRotate _rotateCamera;
    [SerializeField] private CameraMove _camera;

    [Header("UI")]
    [SerializeField] private UIScore _score;

    private void Start() 
    {
        
        var ball = Instantiate(_ballPref, _ballStartPos, Quaternion.identity);
        ball.GetComponent<Ball>().Init(_rotateCamera);
        _input.Init(ball, _playerMusic);
        _camera.Init(ball.transform);

        _changer.Init(ball, _gen);
        _gen.Init();
        _buttonActiveBehaviour.Init(ball);

        _particleInvoker.Init(ball);
        _score.Init(ball);
    }
}
