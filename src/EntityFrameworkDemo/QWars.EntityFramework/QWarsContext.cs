using System;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using QWars.Entities;
using System.Data;

namespace QWars.EntityFramework
{
    public partial class QWarsContext : ObjectContext
    {
        public const string ConnectionString = "name=QWarsContext";
        public const string ContainerName = "QWarsContext";

        #region Constructors

        public QWarsContext()
            : base(ConnectionString, ContainerName)
        {
            ContextOptions.LazyLoadingEnabled = true;
            ContextOptions.ProxyCreationEnabled = true;
        }

        public QWarsContext(string connectionString)
            : base(connectionString, ContainerName)
        {
            ContextOptions.LazyLoadingEnabled = true;
            ContextOptions.ProxyCreationEnabled = true;
        }

        public QWarsContext(EntityConnection connection)
            : base(connection, ContainerName)
        {
            ContextOptions.LazyLoadingEnabled = true;
            ContextOptions.ProxyCreationEnabled = true;
        }

        #endregion

        #region ObjectSet Properties

        public ObjectSet<Gang> Gangs
        {
            get { return _gangs ?? (_gangs = CreateObjectSet<Gang>("Gangs")); }
        }
        private ObjectSet<Gang> _gangs;

        public ObjectSet<Player> Players
        {
            get { return _players ?? (_players = CreateObjectSet<Player>("Players")); }
        }
        private ObjectSet<Player> _players;

        public ObjectSet<Task> Tasks
        {
            get { return _tasks ?? (_tasks = CreateObjectSet<Task>("Tasks")); }
        }
        private ObjectSet<Task> _tasks;

        public ObjectSet<Weapon> Weapons
        {
            get { return _weapons ?? (_weapons = CreateObjectSet<Weapon>("Weapons")); }
        }
        private ObjectSet<Weapon> _weapons;

        #endregion
    }
}
