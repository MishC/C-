using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class CarService : IHandling<Car>
{
     static List<Car> cars = new List<Car>();

public static List<Car> GetCarsFromCsv(string filePath)
{
try
{ 
    string[] lines=File.ReadAllLines(filePath);
    
    for (int i=1; i<lines.Length;i++){
        try
        
        {
        var parts=lines[i].Split(',');
        if (parts.Length == 5 && parts.All(part =>!string.IsNullOrEmpty(part)))
        { 
        var newCar = new Car(parts[0].Trim(), Convert.ToUInt32(parts[1].Trim()), parts[2].Trim(),Convert.ToUInt32(parts[3].Trim()),
        Convert.ToDouble(parts[4].Trim()));

        cars.Add(newCar);}
        else {throw new  ArgumentException($"Cannot create an object from line {i}") ;} 
        
        }

        catch (FormatException ex)

        {
            Console.WriteLine($"Format exception on line {i}: {ex.Message}");
            
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"There is an error on line {i}: {ex.Message}");
            }
    }
    return cars;}

    
    catch (IOException ex)
    {
    Console.WriteLine($"There is an error reading the file: {ex.Message}");
    Console.WriteLine($"\nReturning empty list.");

            return new List<Car>();
     } 
    catch (Exception ex) 
    {
        Console.WriteLine($"Error reading the file: {ex.Message}");
        Console.WriteLine($"\nReturning empty list.");

        return new List<Car>();
    }

}
public void AddCar(Car car, List<Car> cars, string filePath){
    try{
cars.Add(car);
List<string> lines=[];
 foreach(var item in cars)
        {
        lines.Add(item.GetInfo());
        };

File.WriteAllLines(filePath,lines);
            Console.WriteLine($"Car {car} was sucesfully added to the file.");
}
catch (IOException ex)
    {
    Console.WriteLine($"There is an error writing to the file: {ex.Message}");}

catch (Exception ex){Console.WriteLine($"Error: {ex}");}
}
public void RemoveCar(string model, UInt32 year, UInt32 milage, List<Car> cars, string filePath)
    {
        try
        {   

var itemToRemove = cars.FirstOrDefault(car => car.Model == model && car.Year == year && car.Milage == milage)??null;
if (itemToRemove != null)
{
    cars.Remove(itemToRemove);
}
List<string> lines=[];

            foreach (var item in cars)
            {
                lines.Add(item.GetInfo());
            }

            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"Car {model}, {year} with {milage} was sucesfully removed.");
        }
        
catch (IOException ex)
    {
    Console.WriteLine($"There is an error writing to the file: {ex.Message}");}

catch (Exception ex){Console.WriteLine($"Error: {ex}");}
}
public int SearchLine( string model, List<Car> cars){
    
var car=cars.Where(car => car.Model==model).FirstOrDefault();
return car != null ? cars.IndexOf(car) : -1;

}
}