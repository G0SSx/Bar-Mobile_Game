using System;

[Serializable]
public class BalanceData
{
    public event Action Changed;
    public int Money;

    public BalanceData() { }

    public void AddMoney(int value)
    {
        Money += value;
        Changed?.Invoke();
    }
}