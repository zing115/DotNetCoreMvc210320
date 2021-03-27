namespace Mvc1Autofac.Services
{
  public interface ICars
  {
    public string Brand { get; set; }
    public string Name { get; set; }
    public string GetBrand();
    public string GetName();
  }
  public class Cars : ICars
  {
    public string Brand { get; set; }
    public string Name { get; set; }

    string ICars.GetBrand()
    {
      return this.Brand;
    }

    string ICars.GetName()
    {
      return this.Name;
    }
  }
}
