using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using AppArch.Domain.Entities;
using AppArch.Domain.Interfaces;

namespace AppArch.Infrastructure.Data
{
    class SessionHelper
    {
        private ISessionFactory _sessionFactory;
        private string _connectionString;

        public SessionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(_connectionString)
                    .ShowSql()
                )

                // Use class mappings
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<CategoryMap>())

                // Will drop and re-create tables
                //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                //    .Create(true, true))

                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
