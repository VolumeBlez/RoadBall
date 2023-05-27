using System;

public class BallBestScoreChanger
{
    private const string BEST_SCORE_KEY = "BEST_SCORE_KEY";
    private int _currentBestScore = 0;
    private BallStateData _stateData;

    public Action<int> CurrentBestScoreChanged;
    public BallBestScoreChanger(Ball ball, BallStateData stateData) 
    {
        ball.DeathCollisionCheck.PlayerDie += CheckBestScore;
        _stateData = stateData;
    }

    private void CheckBestScore()
    {
        try
        {
            _currentBestScore = SaveLoadMemorySystem.Instance.GetInt(BEST_SCORE_KEY);
        }
        catch (System.Exception)
        {
            CurrentBestScoreChanged?.Invoke(_stateData.CountTurns);
            SaveLoadMemorySystem.Instance.SaveInt(_stateData.CountTurns, BEST_SCORE_KEY);
            return;
        }

        if(_stateData.CountTurns > _currentBestScore)
        {
            _currentBestScore = _stateData.CountTurns;
        }

        CurrentBestScoreChanged?.Invoke(_currentBestScore);
        SaveLoadMemorySystem.Instance.SaveInt(_currentBestScore, BEST_SCORE_KEY);
    }
}
