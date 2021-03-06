using System;
using static System.Console;

namespace NPVCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal investment; //How much initially invested
            decimal inflow; //How much earned in a period
            byte periods; //How many periods (whole number only, up to 255)
            decimal rate; //discount rate
            WriteLine("Enter your inital investment: ");
            investment = Math.Round(Convert.ToDecimal(ReadLine()), 2);
            WriteLine("Enter your expected inflow per period: ");
            inflow = Math.Round(Convert.ToDecimal(ReadLine()), 2);
            WriteLine("How many periods?: ");
            periods = Convert.ToByte(ReadLine());
            WriteLine("Enter the discount rate (in decimal format eg. 0.05 for 5%): ");
            rate = Math.Round(Convert.ToDecimal(ReadLine()), 2);
            calculateNPV(inflow, rate, periods, investment);
            
        }

        static decimal calculateNPV(decimal inflow, decimal rate, byte periods, decimal investment)
        {
            decimal total = 0; //final value, total amount gained over periods
            WriteLine(format: "| {0,-10} | {1,-15} | {2,-17} |", "Period No.", "Period Earnings", "Total Earnings");
            
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            for (int i = 1; i <= periods; i++)
            {
                double newRate = (double)rate + 1;
                double newDivisor = Math.Pow(newRate, i);
                decimal value = Math.Round(Decimal.Divide(inflow, (decimal)newDivisor), 2);

                total = total + value;
                
                WriteLine(format: "| {0,-10} | {1,-15} | {2,-17} |", $"Period: {i}", value, total);
                //WriteLine($"Earnings for period {i} is: {Math.Round(value, 2)}");
                //WriteLine($"Total for period {i} is: {Math.Round(total, 2)}");
                
            }

            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine($"Total Earnings are: {total}");
            WriteLine($"Initial Investment was: {investment}");
            var profit = total - investment;
            WriteLine($"Total profits are: {profit}");
            return profit;
        }
    }
}
