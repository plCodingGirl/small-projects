// See https://aka.ms/new-console-template for more information
Bunny amelia = new Bunny();
amelia.Name = "helena";
var weightReadings = new List<Weight>();
while (true)
{
    Console.WriteLine("Podaj aktualną wagę królika");
    var value = Console.ReadLine();
    weightReadings.Add(new Weight() {Date = DateTime.Now, Value = decimal.Parse(value)});
    foreach (var weightReading in weightReadings)
    {
        Console.WriteLine($"{weightReading.Date.ToString("dd-MM-yyyy")} {amelia.Name} {weightReading.Value} kg");
    }
}