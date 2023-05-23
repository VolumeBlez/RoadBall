using UnityEngine;

public class ReloadButtonActivator : MonoBehaviour
{
    [SerializeField] private GameObject _reloadButton;

    private Ball _ball;

    public void Init(Ball ball) 
    {
        _ball = ball;
        ball.DeathCollisionCheck.PlayerDie += SetActiveReloadButton;
    }


    private void OnDisable()
    {
        _ball.DeathCollisionCheck.PlayerDie -= SetActiveReloadButton;
    }

    private void SetActiveReloadButton()
    {
        _reloadButton.SetActive(true);
    }
}
