using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract]
    public class RepositoryOwner
    {
        [DataMember(Name = "login")]
        public string Name { get; set; }
    }
}
