namespace Mvc1.Services
{
  public class Cars
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public string GetName()
    {
      return string.IsNullOrEmpty(this.Name) ? "N/A" : this.Name;
    }
  }

  public class JediForce
  {
    public int ForcePower() => 9999;
  }

  public class Vehicle
  {
    public string GetName(string _name)
    {
      return _name;
    }
  }
}
