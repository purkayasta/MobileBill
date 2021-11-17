namespace MobileBill
{
    public class RulesFactory
    {
        public static (TimeSpan, TimeSpan) GetPeakHour()
        {
            TimeSpan start = new(9, 0, 0);
            TimeSpan end = new(23, 59, 59);
            return (start, end);
        }

        //public (DateTime, DateTime) GetOffPeakHour()
        //{
        //    DateTime start = new DateTime(0, 0, 0, 0, 0, 0);
        //    DateTime end = new DateTime(0, 0, 0, 8, 59, 59);
        //    return (start, end);
        //}


        public static double GetMoneyRules(bool isPeak)
        {
            if (isPeak)
                return 0.30;
            return 0.20;
        }


    }
}
