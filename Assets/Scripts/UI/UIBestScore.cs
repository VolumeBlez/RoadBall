
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    [SerializeField] private Text _bestScoreUIText;

    public void Init(BallBestScoreChanger ballBestScore) 
    {
        ballBestScore.CurrentBestScoreChanged += UIChangeBestScore;
    }

    private void UIChangeBestScore(int value) 
    {
        _bestScoreUIText.text = $"Best Score: {value}";
    }

}
