using System;

[Serializable]
public class PlayerProgress
{
    public float Score;

    public PlayerProgress(float score)
    {
        Score = score;
    }
}