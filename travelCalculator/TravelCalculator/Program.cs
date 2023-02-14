// See https://aka.ms/new-console-template for more information
using CurrencyConverterApp;

Console.WriteLine("Ile pieniędzy wziąć na kolejną podróż");
//CurrencyConverter.GetExchangeRate("pln", "eur");

Console.WriteLine("Ile dni będzie trwała Twoja podróż?");
int days = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ile dziennie plannujesz wydać na jedzenie?");
decimal food = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Ile dziennie plannujesz wydać na atrrakcje?");
decimal attractions = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Na Revolut warto przelać:");
Console.WriteLine($"PLN: {(food+attractions)*days}");
///CurrencyConverter.GetExchangeRate("pln", "eur", 100);
Console.WriteLine($"EUR: {CurrencyConverter.GetExchangeRate("pln", "eur",(float)((food+attractions)*days))}");

