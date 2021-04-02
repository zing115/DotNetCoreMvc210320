using Mvc1Autofac.Shared;

namespace Mvc1Autofac.Services
{
  [InjectSingleton]
  public class Secret
  {
    public string Name { get; set; } = "Morgan";
  }

  public interface IFighter_Autofac
  {
    public string GetName();
  }
  public class Fighter_Autofac : IFighter_Autofac
  {
    string Name { get; set; } = "Euro Fighter";
    public string GetName() => this.Name;
  }

  public class MyCars_Table
  {
    public string Brand { get; set; } = "Toyota";
    public string Name { get; set; } = "GT-86";
  }

  public interface ICars
  {
    public string Brand { get; set; }
    public string Name { get; set; }
    public string GetBrand();
    public string GetName();
  }
  [Inject]
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
