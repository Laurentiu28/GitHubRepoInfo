using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract]
    public class CommitRoot
    {
        [DataMember(Name = "commit")]
        public Commit Commit { get; set; }
    }
}
