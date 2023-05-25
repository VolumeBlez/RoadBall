
using UnityEngine;

public class ButtonActiveBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _reloadButton;
    [SerializeField] private GameObject _screenTapButton;

    private Ball _ball;

    public void Init(Ball ball) 
    {
        _ball = ball;
        ball.DeathCollisionCheck.PlayerDie += EnableReloadButton;
        ball.DeathCollisionCheck.PlayerDie += DisableScreenTapButton;
    }


    private void OnDisable()
    {
        _ball.DeathCollisionCheck.PlayerDie -= EnableReloadButton;
        _ball.DeathCollisionCheck.PlayerDie -= DisableScreenTapButton;
    }

    private void EnableReloadButton()
    {
        _reloadButton.SetActive(true);
    }

    private void DisableScreenTapButton()
    {
        _screenTapButton.SetActive(false);
    }
}
