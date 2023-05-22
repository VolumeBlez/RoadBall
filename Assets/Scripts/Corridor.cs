using UnityEngine;
using System;

public class Corridor : MonoBehaviour
{ 
    [SerializeField] private Vector2 _directionToTurn;
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _end;
    [SerializeField] private DirectionType _beginDirectionType;
    [SerializeField] private DirectionType _endDirectionType;

    public Action<Corridor> PlayerCheckTheTurn;

    public Transform End => _end;
    public Transform Begin => _begin;
    public DirectionType BeginDirection => _beginDirectionType;
    public DirectionType EndDirection => _endDirectionType;
    public Vector2 DirectionToTurn => _directionToTurn;



    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCheckTheTurn?.Invoke(this);
    }
}
