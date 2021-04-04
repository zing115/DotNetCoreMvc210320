using Mvc1Autofac.Shared;
namespace Mvc1Autofac.Services
{
  [Inject]
  public class UseTheForce
  {
    public Jedi Jedi { get; set; }
    public ICars Cars { get; set; }
  }

  [Inject]
  public class Jedi
  {
      public string Name { get; set; }
      public string GetName() => this.Name;
  }
}