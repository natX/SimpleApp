using Fluent.Entities;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Machine.Specifications;
using NHibernate;

namespace TestApp.Specs
{
    [Subject("Database Schema Generation")]
    public class Sqlite_Repository_Generation
    {
        Establish context = () =>
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
                                                            .Where(x => x.Namespace == "Fluent.Entities"));
                                                });

                                    _sessionSource = new SessionSource(config);
                                    _session = _sessionSource.CreateSession();
                                };
        Because of = () =>  
                     _sessionSource.BuildSchema(_session);

        It has_created_the_schema = () => 
                                    true.ShouldBeTrue();
        
        Cleanup the_session = () =>
                                  {
                                      _session.Close();
                                      _session.Dispose();
                                  };
        
        static SessionSource _sessionSource;
        static ISession _session;
    }
}