using System;

[Serializable]
public class ScoreData
{
    public event Action Changed;
    public int Score;

    public ScoreData() { }

    public ScoreData(int value) => 
        Score = value;

    public void AddScore(int value)
    {
        Score += value;
        Changed?.Invoke();
    }
}