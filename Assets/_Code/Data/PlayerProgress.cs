using System;

[Serializable]
public class PlayerProgress
{
    public BalanceData Money;

    public PlayerProgress() => 
        Money = new();
}