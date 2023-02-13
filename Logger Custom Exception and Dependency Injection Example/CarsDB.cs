using System;
using System.Collections;
using System.Collections.Generic;

namespace Logger_Custom_Exception_and_Dependency_Injection_Example
{
    class CarsDB
    {
        private ArrayList cars;
        private ILogger logger;

        public CarsDB(ILogger logger)
        {
            this.logger = logger;
            cars = new ArrayList();
        }

        public void AddCar(Car car)
        {
            if (car.OwnerId.Length != 9)
            {
                throw new FormatException("Owner's ID must be exactly 9 characters long.");
            }

            Car ifHaveCar = GetCar(car.LicensePlate);
            if (ifHaveCar != null)
            {
                throw new ExistingPlateException($"A car with license plate '{ifHaveCar.LicensePlate}' already exists.");
            }

            cars.Add(car);
            logger.Log($"New car with plate='{car.LicensePlate}' was added.");
        }

        public Car GetCar(string licensePlate)
        {
            return cars.OfType<Car>().FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public void UpdateCar(string licensePlate, Car updatedCar)
        {
            Car car = GetCar(licensePlate);
            if (car == null)
            {
                Console.WriteLine("The car with license plate '{0}' does not exist.", licensePlate);
                return;
            }

            int index = cars.IndexOf(car);
            cars[index] = updatedCar;
            logger.Log($"Car with plate='{updatedCar.LicensePlate}' was updated.");
        }

        public void DeleteCar(string licensePlate)
        {
            Car car = GetCar(licensePlate);
            if (car == null)
            {
                Console.WriteLine("The car with license plate '{0}' does not exist.", licensePlate);
                return;
            }

            cars.Remove(car);
            logger.Log($"Removed car with plate='{car.LicensePlate}'.");
        }
    }
}
