namespace Mvc1Autofac.Services
{
  public class UseTheForce
  {
    public Jedi Jedi { get; set; }
    public ICars Cars { get; set; }
  }
    public class Jedi
    {
        public string Name { get; set; }
        public string GetName() => this.Name;
    }
}