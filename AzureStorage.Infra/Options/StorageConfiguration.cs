using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorage.Infra.Options
{
    public class StorageConfiguration
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string ContainerName { get; set; }
    }
}
