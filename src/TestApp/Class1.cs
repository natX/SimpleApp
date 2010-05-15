using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace TestApp
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x =>
                {
                    x.Scan(s =>
                        {
                            s.TheCallingAssembly();
                            s.AssemblyContainingType<IValidator>();
                        });
                    x.For<IRepository>().Use<Repository>().Ctor<string>("label").Is("my label");
                    
                    
                });
        }
    }

    public class ValidatorRegistry
        : Registry
    {
        public ValidatorRegistry()
        {
            For<IValidator>().Use<Validator>();
        }
    }

    public class Repository : IRepository
    {
        readonly string _label;

        public Repository(string label)
        {
            _label = label;
        }
    
        public string Label
        {
            get
            {
                return _label;
            }
        }
    }

    public interface IRepository {}

    public interface IValidator
    {
        string Name { get; set; }
    }

    public class Validator
        : IValidator
    {
        public string Name {get; set;}
    }
}
