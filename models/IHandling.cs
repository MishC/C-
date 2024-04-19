using System.ComponentModel.DataAnnotations;

public interface IHandling<T> {
    void AddCar(T Car, List<T> cars, string filepath);
    void RemoveCar(string model, UInt32 year, UInt32 milage, List<T> cars, string filepath);

    int SearchLine( string model, List<T> cars );
    
}