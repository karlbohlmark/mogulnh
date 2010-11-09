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
        public static ISessionFactory BuildSessionFactory() {
            var cfg  = new Configuration().Configure();
            new SchemaExport(cfg).Create(false, true);
            return cfg.BuildSessionFactory();
        }
    }
}