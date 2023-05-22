
using UnityEngine;

public class BallTurnDirectionChanger : MonoBehaviour
{
    [SerializeField] private CorridorGenerator _generator;
    private Ball _ball;

    public void Init(Ball ball)
    {
        _ball = ball;
        _generator.CurrentCorridorChanged += ChangeBallDirection;
    }

    private void ChangeBallDirection(Corridor cor) 
    {
        Debug.Log($"Change Turn direction to {cor.DirectionToTurn}");
        _ball.ChangeDirectionToTurn(cor.DirectionToTurn);
    }
}
