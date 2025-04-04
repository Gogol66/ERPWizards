using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERPWizards.Models.Networking
{

    public class NetworkModule
    {
        [Key]
        public int NetworkModuleId { get; set; } // Primary Key

        public string ModuleName { get; set; } // Name of the network module
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
        public string Gateway { get; set; }
        public List<string> DnsServers { get; set; }

        public NetworkModule()
        {
            DnsServers = new List<string>();
        }

        public void AddDnsServer(string dnsServer)
        {
            if (!DnsServers.Contains(dnsServer))
            {
                DnsServers.Add(dnsServer);
            }
        }

        public void RemoveDnsServer(string dnsServer)
        {
            if (DnsServers.Contains(dnsServer))
            {
                DnsServers.Remove(dnsServer);
            }
        }
    }

}
