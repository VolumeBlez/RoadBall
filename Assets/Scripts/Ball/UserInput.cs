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

    public void Init(BallMainLogic logic)
    {
        Input.Enable();
        Input.GamePlay.Turn.performed += ctx => logic.ChangeCurrentDirection();
    }

    private void OnDisable() 
    {
        Input.Disable();
    }
}
