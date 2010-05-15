using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Fluent;
using Fluent.Entities;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace TestApp.Specs
{
    [TestFixture]
    public class CreateRepository_Specs
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            GenerateDatabase();
        }

        [Test]
        public void Connection_is_initialized()
        {
            using(var s = CreateSessionFactory())
            {
                 s.OpenSession();            
            }
        }

        [Test]
        public void Verify_Vehicle()
        {
            var sf = CreateSessionFactory();
            new PersistenceSpecification<Vehicle>(sf.OpenSession())
                .CheckProperty(x => x.Id, 1)
                .CheckProperty(x => x.Vin, "123435")
                .CheckProperty(x => x.ModelYear, 2010)
                .VerifyTheMappings();



        }

        public ISessionFactory CreateSessionFactory()
        {
            return CreateConfiguration()
                .BuildSessionFactory();
        }

        public void GenerateDatabase()
        {
            CreateConfiguration()
                .ExposeConfiguration(ExportSchema)
                .BuildSessionFactory();
        }

        public void ExportSchema(Configuration configuration)
        {
            SchemaExport se = new SchemaExport(configuration);
            se.Drop(true, true);
            se.Create(true, true);
        }

        public FluentConfiguration CreateConfiguration()
        {
            return Fluently
                .Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2008
                        .ConnectionString(cs =>
                                          cs
                                              .Server("localhost\\sqlexpress")
                                              .Database("FluentDb")
                                              .Username("SMR_COPY_USER")
                                              .Password("user1!")))
                .Mappings(
                    m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<Software>();
                            m.AutoMappings.Add(
                                AutoMap
                                    .AssemblyOf<Plant>()
                                    .Where(x => x.Namespace == "Fluent.Entities" )); //&& x.Name != "Vehicle"));
                        });
        }
    }
}
