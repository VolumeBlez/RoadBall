using System;
using UnityEngine;

public class CorridorTurnTrigger : MonoBehaviour
{
    public Action<Corridor> PlayerCheckTheTurn;

    private Corridor _corridorParent;

    public void Init(Corridor cor) 
    {
        _corridorParent = cor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCheckTheTurn?.Invoke(_corridorParent);
    }
}
