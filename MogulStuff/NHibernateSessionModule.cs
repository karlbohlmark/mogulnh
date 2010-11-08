using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MogulStuff
{
    public class NHibernateSessionModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            StructureMap.ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}