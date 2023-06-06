using System;

[Serializable]
public class PlayerProgress
{
    public ScoreData HighScore;
    public ScoreData CurrentScore;

    public PlayerProgress()
    {
        HighScore = new();
        CurrentScore = new();
    }
}