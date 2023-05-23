using UnityEngine;


public class Corridor : MonoBehaviour
{ 
    [SerializeField] private Vector2 _directionToTurn;
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;
    [SerializeField] private DirectionType _beginDirectionType;
    [SerializeField] private DirectionType _endDirectionType;
    [SerializeField] private CorridorTurnTrigger _trigger;

    public CorridorTurnTrigger TurnTrigger => _trigger;
    public Transform End => _end;
    public Transform Begin => _begin;
    public DirectionType BeginDirection => _beginDirectionType;
    public DirectionType EndDirection => _endDirectionType;
    public Vector2 DirectionToTurn => _directionToTurn;

    public void Init() 
    {
        _trigger.Init(this);
    }

}
