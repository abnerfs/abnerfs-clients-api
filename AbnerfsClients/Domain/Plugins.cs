using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbnerfsClients.Domain
{
    public class Plugins
    {
        public int Id { get; set; }
        public string GitLabID { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Purchases> Purchases { get; set; }
    }
}
