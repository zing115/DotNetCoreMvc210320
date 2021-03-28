using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc1Autofac.Shared
{
  [AttributeUsage(AttributeTargets.Class, Inherited = false)] public class Inject : Attribute { }

  [AttributeUsage(AttributeTargets.Class, Inherited = false)] public class InjectSingleton : Attribute { }
}
