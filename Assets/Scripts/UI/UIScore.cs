
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public void Init(Ball ball) 
    {
        ball.Logic.TurnCountChanged += ShowCurrentTurnCount;
    }

    private void ShowCurrentTurnCount(int turnCount) 
    {
        _scoreText.text = $"{turnCount}";
    }
}
