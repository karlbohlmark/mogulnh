using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using MogulStuff.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MogulStuff.RepositoryImpl
{
    public class Configuration
    {
        public static ISessionFactory BuildSessionFactory(){
            var cfg = Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("default")))
                .Mappings(m =>
                    m.AutoMappings.Add(
                        AutoMap.AssemblyOf<Project>()
                    )
                ).BuildConfiguration();
            SchemaExport export = new SchemaExport(cfg);
            export.Create(true, true);
            return cfg.BuildSessionFactory();
        }
    }
}
