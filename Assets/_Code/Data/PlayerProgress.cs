using System;

[Serializable]
public class PlayerProgress
{
    public BalanceData Balance;

    public PlayerProgress() => 
        Balance = new();
}