
using UnityEngine;

public class BallTurnDirectionChanger : MonoBehaviour
{
    private CorridorGenerator _generator;
    private Ball _ball;

    public void Init(Ball ball, CorridorGenerator generator)
    {
        _ball = ball;
        _generator = generator;
        _generator.CurrentCorridorChanged += ChangeBallDirection;
    }

    private void ChangeBallDirection(Corridor cor) 
    {
        Debug.Log($"Change Turn direction to {cor.DirectionToTurn}");
        _ball.Logic.ChangeDirectionToTurn(cor.DirectionToTurn);
    }


    private void OnDisable()
    {
        _generator.CurrentCorridorChanged -= ChangeBallDirection;
    }
}
