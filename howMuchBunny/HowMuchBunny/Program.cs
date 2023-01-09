// See https://aka.ms/new-console-template for more information
var bunnies = new List<Bunny>();
while (true)
{
    Console.WriteLine("Wybierz id królika");
    Console.WriteLine("1: amelia");
    Console.WriteLine("2: helena");
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Podaj aktualną wagę królika amelia");
            var bunny = new Bunny() {Name = "amelia", Weight = new List<Weight>() };
            bunnies.Add(bunny);
            bunny.Weight.Add(new Weight(){Date = DateTime.Now, Value = decimal.Parse(Console.ReadLine())});
            break;
        case "2":
            Console.WriteLine("Podaj aktualną wagę królika helena");
            var helena = new Bunny() {Name = "helena", Weight = new List<Weight>() };
            bunnies.Add(helena);
            helena.Weight.Add(new Weight(){Date = DateTime.Now, Value = decimal.Parse(Console.ReadLine())});
            break;
    }
    for (var i = 0; i < bunnies.Count; i++)
    {
        Console.WriteLine($"{bunnies[i].ToString()}");
        //Console.WriteLine($"{bunnies[i].Weight[i].Date.ToString("dd-MM-yyyy")} {bunnies[i].Name} {bunnies[i].Weight[i].Value} kg ");
        //if (i >= 1)
        //{
        //    var howMuch = weightReadings[i].Value-weightReadings[i-1].Value;
        //    Console.Write($"zmiana o {howMuch} kg");
        //}
        //Console.WriteLine();
    }
}