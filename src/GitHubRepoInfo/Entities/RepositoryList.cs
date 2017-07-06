using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract]
    public class RepositoryList
    {
        [DataMember(Name = "items")]
        public IEnumerable<Repository> UserRepositories { get; set; }
    }
}
