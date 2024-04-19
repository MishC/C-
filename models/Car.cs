public class Car 
{
   public string Model { get; set; }
   public uint Year { get; set; }
   public string Color  { get; set; }   
   public uint Milage { get; set; }
   public double Price {get; set;}

public Car(string model, uint yr, string color, uint milage, double price) 
{
    Model = model;
    Year = yr;       
    Color = color;
    Milage = milage;
    Price = price;
}
public override string ToString()
    {
        return $"Model: {Model}, Year: {Year}, Color: {Color}, Milage: {Milage}, Price: {Price}";
    }
public string GetInfo(){
    return $"{Model}, {Year}, {Color}, {Milage}, {Price}";
}    

}
