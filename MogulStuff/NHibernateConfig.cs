using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using MogulStuff.Domain;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions;
using NHibernate.Cfg;
using System.IO;

namespace MogulStuff
{
    public class NHibernateConfig
    {
        private static string  DbFile = "fluent.db";

        public static ISessionFactory BuildSessionFactory() {
            var cfg  = new Configuration().Configure();
            BuildSchema(cfg);
            return cfg.BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}