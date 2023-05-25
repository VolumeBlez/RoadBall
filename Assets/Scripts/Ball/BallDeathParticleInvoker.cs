using UnityEngine;

public class BallDeathParticleInvoker : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private Ball _ball;

    public void Init(Ball ball) 
    {
        _ball = ball;
        ball.DeathCollisionCheck.PlayerDie += PlayParticle;
    }

    private void PlayParticle()
    {
        _particle.gameObject.SetActive(true);
        _particle.transform.position = _ball.transform.position;
        _particle.Play();
    }
}
