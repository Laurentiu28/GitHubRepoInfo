using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubRepoInfo.DTO
{
    public class UserRepositoryDto
    {
        public string OwnerName { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastPushDate { get; set; }

        public IEnumerable<CommitDto> Commits { get; set; }
    }
}
