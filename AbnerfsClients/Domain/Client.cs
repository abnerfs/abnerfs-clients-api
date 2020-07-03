using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbnerfsClients.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DiscordID { get; set; }
        public string GitLabID { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual IEnumerable<Purchases> Purchases { get; set; }
    }
}
