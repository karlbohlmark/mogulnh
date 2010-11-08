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
    
    class CascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention {
        public void Apply(FluentNHibernate.Conventions.Instances.IManyToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }

        public void Apply(FluentNHibernate.Conventions.Instances.IManyToOneInstance instance)
        {
            instance.Cascade.All();
        }


        public void Apply(FluentNHibernate.Conventions.Instances.IOneToManyCollectionInstance instance)
        {
            instance.Cascade.AllDeleteOrphan();
            instance.Inverse();
        }
    }

    public class NHibernateConfig
    {
        private static string  DbFile = "fluent.db";

        public static ISessionFactory BuildSessionFactory() {
            var cfg  = new Configuration().Configure();
            BuildSchema(cfg);
            return cfg.BuildSessionFactory();
            /*
            var cfg= Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=fluent.db;Version=3;FailIfMissing=false"))
                .Mappings(m =>{
                    m.AutoMappings.Add(AutoMap.AssemblyOf<Project>());
                    var model = new AutoPersistenceModel();
                        model.Conventions.Add<CascadeConvention>();
                        model.Where(t=>t.Namespace == typeof(Project).Namespace);
                        m.AutoMappings.Add(model);
                        m.FluentMappings.ExportTo("c:\\temp\\mymappings.hbm.xml");
                    }
                ).Diagnostics(d=>d.OutputToConsole())
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration();

            var a = cfg.CollectionMappings;

            return cfg.BuildSessionFactory();
             * 
            */
            
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