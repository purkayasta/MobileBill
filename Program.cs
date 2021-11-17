

using MobileBill;

Console.WriteLine("Please input the caller start time and endtime in following format: ");
Console.WriteLine("Start Date: ");

if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
{
    Console.WriteLine("Invalid Start Date");
    return;
}

Console.WriteLine("End Date: ");

if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
{
    Console.WriteLine("Invalid End Date");
    return;
}

bool isPeak = false;

double peakRate = 0;
double offPeakRate = 0;
double totalMoney = 0;

var peakHour = RulesFactory.GetPeakHour();

if (startDate.TimeOfDay.Hours >= peakHour.Item1.Hours)
{
    isPeak = true;
}
else
{
    isPeak = false;
}
peakRate = RulesFactory.GetMoneyRules(true);
offPeakRate = RulesFactory.GetMoneyRules(false);

var pulseRate = 20;
var totalCallDifferenceInSeconds = (endDate - startDate).TotalSeconds;
var loop = totalCallDifferenceInSeconds / pulseRate;


if (isPeak)
{
    for (int i = 0; i <= loop; i++)
    {
        totalMoney += peakRate;
    }
}
else
{
    for (int i = 0; i <= loop; i++)
    {
        startDate = startDate.AddSeconds(pulseRate);
        if (startDate.TimeOfDay >= peakHour.Item1)
        {
            totalMoney += peakRate;
        }
        else
        {
            totalMoney += offPeakRate;
        }

        Console.WriteLine($"");
    }
}

Console.WriteLine($"Total Bill: {totalMoney} Taka");

