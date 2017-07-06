using GitHubRepoInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubRepoInfo.Repositories
{
    public interface IUserInfoRepository
    {
        IEnumerable<Repository> GetRepositories(string searchQuery, bool includeCommits = true, int limit = 5);
        IEnumerable<Commit> GetCommits(string ownerName, string repository, int limit = 5);
    }
}
