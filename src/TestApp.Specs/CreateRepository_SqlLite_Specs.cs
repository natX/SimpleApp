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
    public class CreateSqlLiteRepository_Specs
    {
        ISession _session;
        SessionSource _sessionSource;

        [SetUp]
        public void SetUp()
        {
            FluentConfiguration config = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(
                    m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<Vehicle>();
                            m.AutoMappings.Add(
                                AutoMap
                                    .AssemblyOf<Plant>()
                                    .Where(x => x.Namespace == "Fluent.Entities")); //&& x.Name != "Vehicle"));
                        });
            
            _sessionSource = new SessionSource(config);
            _session = _sessionSource.CreateSession();
            _sessionSource.BuildSchema(_session);
        }

        [TearDown]
        public void TearDown()
        {
            _session.Close();
            _session.Dispose();
        }

        [Test]
        public void Verify_Vehicle()
        {  
            new PersistenceSpecification<Vehicle>(_session)
                .CheckProperty(x => x.Id, 1)
                .CheckProperty(x => x.Vin, "123435")
                .CheckProperty(x => x.ModelYear, 2010)
                .VerifyTheMappings();
        }

        [Test]
        public void Verify_Plant()
        {
            new PersistenceSpecification<Plant>(_session)
                .CheckProperty(x => x.Name, "Test")
                .VerifyTheMappings();
        }


    }
}
