
using UnityEngine;

public class ButtonActiveBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject[] _UIElementsToEnable;
    [SerializeField] private GameObject[] _UIElementsToDisable;

    private Ball _ball;

    public void Init(Ball ball) 
    {
        _ball = ball;
        ball.DeathCollisionCheck.PlayerDie += EnableUIElements;
        ball.DeathCollisionCheck.PlayerDie += DisableUIElements;
    }


    private void OnDisable()
    {
        _ball.DeathCollisionCheck.PlayerDie -= EnableUIElements;
        _ball.DeathCollisionCheck.PlayerDie -= DisableUIElements;
    }

    private void EnableUIElements()
    {
        foreach (var item in _UIElementsToEnable)
        {
            item.SetActive(true);
        }
    }

    private void DisableUIElements()
    {
        foreach (var item in _UIElementsToDisable)
        {
            item.SetActive(false);
        }
    }
}
