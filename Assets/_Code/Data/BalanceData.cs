﻿using System;

namespace _Code.Data
{
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
}