using System;
using UnityEngine;

public class BallCheckCollision : MonoBehaviour
{
    public Action PlayerDie;

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerDie?.Invoke();
        Destroy(gameObject);
    }
}
