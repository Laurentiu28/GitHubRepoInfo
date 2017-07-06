using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Entities
{
    [DataContract(Name = "commit")]
    public class Commit
    {
        [DataMember(Name = "committer")]
        public Committer Committer { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "tree")]
        public CommitTree Tree { get; set; }
    }
}
