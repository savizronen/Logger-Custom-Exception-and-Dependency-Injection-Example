

using Logger_Custom_Exception_and_Dependency_Injection_Example;
using System.Collections;

ILogger consoleLogger = new ConsoleLogger();
CarsDB carsDB = new CarsDB(consoleLogger);

Car car1 = new Car("Toyota", "Camry", 2019, "ABC123", "John", "Doe", "123456789");
Car car2 = new Car("Honda", "Civic", 2018, "DEF456", "Jane", "Doe", "234567890");
Car car3 = new Car("Tesla", "Model S", 2021, "GHI789", "James", "Smith", "345678901");
Car car4 = new Car("Nissan", "Altima", 2020, "JKL012", "Emily", "Johnson", "456789012");
Car car5 = new Car("Chevrolet", "Impala", 2022, "MNO345", "Michael", "Brown", "567890123");
Car car6 = new Car("Jeep", "Wrangler", 2017, "PQR678", "James", "Davis", "678901234");
Car car7 = new Car("Dodge", "Charger", 2016, "STU901", "William", "Miller", "789012345");
Car car8 = new Car("BMW", "X5", 2015, "VWX234", "Christopher", "Wilson", "890123456");
Car car9 = new Car("Mercedes-Benz", "C-Class", 2014, "YZ123", "Joseph", "Anderson", "901234567");
Car car10 = new Car("Audi", "A6", 2013, "456ABC", "Thomas", "Jackson", "012345678");

try
{
    carsDB.AddCar(car1);
    carsDB.AddCar(car2);
    carsDB.AddCar(car3);
    carsDB.AddCar(car4);
    carsDB.AddCar(car5);
    carsDB.DeleteCar(car1.LicensePlate);
    carsDB.DeleteCar(car2.LicensePlate);
    carsDB.UpdateCar(car3.LicensePlate, car6);
    carsDB.UpdateCar(car4.LicensePlate, car7);
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch (ExistingPlateException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nDemonstrating the use of VerboseLogger:");
ILogger fileLogger = new FileLogger();
CarsDB carsDB2 = new CarsDB(fileLogger);

try
{
    carsDB2.AddCar(car1);
    carsDB2.AddCar(car2);
    carsDB2.AddCar(car3);
    carsDB2.AddCar(car4);
    carsDB2.AddCar(car5);
    carsDB2.DeleteCar(car1.LicensePlate);
    carsDB2.DeleteCar(car2.LicensePlate);
    carsDB2.UpdateCar(car3.LicensePlate, car6);
    carsDB2.UpdateCar(car4.LicensePlate, car7);
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch (ExistingPlateException ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();
        