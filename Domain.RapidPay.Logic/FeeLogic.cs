using System;

namespace Domain.RapidPay.Logic
{
    public class FeeLogic : IFeeLogic
    {
        private static Random _random;
        private DateTime _lastDate;
        private readonly decimal _lastFee;

        public FeeLogic()
        {
            _random = new Random();
            _lastDate = DateTime.UtcNow;
            _lastFee = GenerateDecimal();
        }

        public decimal GetFee()
        {
            var totalMinutesDifference = (DateTime.UtcNow - _lastDate).TotalMinutes;

            if (totalMinutesDifference < 60)
                return _lastFee;

            _lastDate = DateTime.UtcNow;

            return _lastFee * GenerateDecimal();
        }

        public decimal GenerateDecimal()
        {
            var fromZeroToTwoDoubleNumber = _random.NextDouble() + _random.NextDouble();

            var randomDecimal = Convert.ToDecimal(fromZeroToTwoDoubleNumber);

            return Math.Round(randomDecimal, 2);
        }
    }
}