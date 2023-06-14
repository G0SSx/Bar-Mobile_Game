using System;

namespace _Code.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public BalanceData Balance;

        public PlayerProgress() => 
            Balance = new();
    }
}