// See https://aka.ms/new-console-template for more information
Bunny amelia = new Bunny();
amelia.Name = "helena";
var weightReadings = new List<Weight>();
while (true)
{
    Console.WriteLine("Podaj aktualną wagę królika");
    weightReadings.Add(new Weight() {Date = DateTime.Now, Value = decimal.Parse(Console.ReadLine())});
    for (var i = 0; i < weightReadings.Count; i++)
    {
        Console.Write($"{weightReadings[i].Date.ToString("dd-MM-yyyy")} {amelia.Name} {weightReadings[i].Value} kg ");
        if (i >= 1)
        {
            var howMuch = weightReadings[i].Value-weightReadings[i-1].Value;
            Console.Write($"zmiana o {howMuch} kg");
        }
        Console.WriteLine();
    }
}