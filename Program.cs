// Filen ligger i prosjektet og blir automatisk kopiert til output slik at den kan brukes bare på filnavn!
using System;
using System.IO;
using System.Linq;

string fileName = "cars.csv";

List<Car> listOfCars=CarService.GetCarsFromCsv(fileName);

Console.WriteLine("1) Skriv ut alle biler fra og med årsmodell 2020 og nyere.");
List<Car> newerCars=listOfCars.Where(car => car.Year>=2020).ToList();
foreach (Car car in newerCars){
Console.WriteLine(car);}
Console.WriteLine("2) Skriv ut alle biler som har en kilometer stand mindre enn 30000.") ;
List<Car> shortestMilageCars=listOfCars.Where(car => car.Milage<30000).ToList();
foreach (Car car in shortestMilageCars){
Console.WriteLine(car);}
Console.WriteLine("3) Skriv ut alle biler har gått mindre enn 30000 km og koster mindre enn 100000 kroner");
List<Car> affordableCars=shortestMilageCars.Where(car => car.Price<100000).ToList();
foreach (Car car in affordableCars){
Console.WriteLine(car.ToString());}
/************************************************/
var carService = new CarService();
int line=carService.SearchLine("Nissan Leaf",listOfCars);
Console.WriteLine($"Nissan Leaf found on line: {line}");

carService.AddCar(new Car("Peugeout", 2014, "grey",65012, 99000), listOfCars, fileName);
carService.RemoveCar("Peugeout", 2014, 65012, listOfCars,fileName);

