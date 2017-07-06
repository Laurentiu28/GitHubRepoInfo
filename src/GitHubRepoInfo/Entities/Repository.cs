using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract]
    public class Repository
    {
        [DataMember(Name = "owner")]
        public RepositoryOwner Owner { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedDate { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime LastPushDate { get; set; }
        [IgnoreDataMember]
        public IEnumerable<Commit> Commits { get; set; }
    }
}
