using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract]
    public class Committer
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}
