using UnityEngine;

public class MainGameEntryPoint : MonoBehaviour
{
    [SerializeField] private Ball _ballPref;
    [SerializeField] private CameraMove _camera;
    [SerializeField] private CorridorGenerator _gen;
    [SerializeField] private BallTurnDirectionChanger _changer;
    [SerializeField] private CameraRotate _rotateCamera;

    private void Start() 
    {
        var ball = Instantiate(_ballPref, new Vector2(1.5f, -2f), Quaternion.identity);
        ball.GetComponent<Ball>().Init(_rotateCamera);

        _camera.Init(ball.transform);
        _changer.Init(ball);
        _gen.Init();
    }
}
