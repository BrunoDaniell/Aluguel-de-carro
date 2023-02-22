using System;
using System.Globalization;
using SolucaoSemInterface.Entites;
using SolucaoSemInterface.Service;

class SolucaoSemInt
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter rendal data");
        Console.Write("Model car: ");
        string model = Console.ReadLine();
        Console.Write("Pickup (dd/MM/yyyy): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.Write("Return (dd/MM/yyyy): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        CarRental carRental = new CarRental(start, finish, new Vehicle(model));
        
        Console.Write("Enter price per hour: ");
        double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter price per day: ");
        double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        RetalService retalService = new RetalService(pricePerHour, pricePerDay, new BrazilTaxService());
        retalService.ProcessInvoice(carRental);

        Console.WriteLine("INVOICE");

        Console.WriteLine(carRental.Invoice);





    }

}
