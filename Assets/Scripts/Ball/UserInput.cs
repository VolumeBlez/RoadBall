using UnityEngine;

public class UserInput : MonoBehaviour
{
    private Input _input;

    public Input Input
    {
        get
        {
            if(_input != null) return _input;
            _input = new Input();
            return _input;
        }
    }

    public void Init(Ball ball, MusicPlayer musicPlayer)
    {
        Input.Enable();
        Input.GamePlay.Turn.performed += ctx =>ball.Logic.ChangeCurrentDirection();
        Input.GamePlay.ChangeMusic.performed += ctx =>  musicPlayer.ChangeCurrentMusic();

        ball.DeathCollisionCheck.PlayerDie += DisableInput;
    }

    private void OnDisable() 
    {
        DisableInput();
    }

    private void DisableInput()
    {
        Input.Disable();
    }
}
