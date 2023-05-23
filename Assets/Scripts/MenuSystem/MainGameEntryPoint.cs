using UnityEngine;

public class MainGameEntryPoint : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private ReloadButtonActivator _reloadButtonActivator;
    [SerializeField] private CorridorGenerator _gen;
    [SerializeField] private BallTurnDirectionChanger _changer;

    [Header("Player and Camera")]
    [SerializeField] private Ball _ballPref;
    [SerializeField] private CameraRotate _rotateCamera;
    [SerializeField] private CameraMove _camera;

    private void Start() 
    {
        var ball = Instantiate(_ballPref, new Vector2(1.5f, -3.5f), Quaternion.identity);
        ball.GetComponent<Ball>().Init(_rotateCamera);
        _camera.Init(ball.transform);

        _changer.Init(ball, _gen);
        _gen.Init();
        _reloadButtonActivator.Init(ball);
    }
}
