using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest1.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PopupsCollectionName { get; set; }
        public string EventsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string PopupsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string EventsCollectionName { get; set; }
    }
}
