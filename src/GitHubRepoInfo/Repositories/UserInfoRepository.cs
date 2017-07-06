using System;
using GitHubRepoInfo.Entities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using System.Linq;

namespace GitHubRepoInfo.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly HttpClient _client = new HttpClient();

        public UserInfoRepository()
        {
            _client.BaseAddress = new Uri(Startup.Configuration["githubApiSettings:baseAddress"]);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GitHubRepoInfo", "v1.0"));

        }
        public IEnumerable<Repository> GetRepositories(string searchQuery, bool includeCommits = true, int limit = 5)
        {
            IEnumerable<Repository> result = new List<Repository>();

            HttpResponseMessage response = _client.GetAsync($"{Startup.Configuration["githubApiSettings:searchRepositoryUrl"]}{searchQuery}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                var userRepositoryList = JsonConvert.DeserializeObject<RepositoryList>(data);

                result = userRepositoryList.UserRepositories.Take(limit).ToList();

                if (includeCommits)
                {
                    foreach (var repo in result)
                    {
                        repo.Commits = GetCommits(repo.Owner.Name, repo.Name);
                    }
                }
            }

            return result;
        }

        public IEnumerable<Commit> GetCommits(string ownerName, string repository, int limit = 5)
        {
            if (string.IsNullOrEmpty(repository))
            {
                throw new ArgumentException("Null or empty repository");
            }

            if (string.IsNullOrEmpty(ownerName))
            {
                throw new ArgumentException("Null or empty repository owner name");
            }

            IEnumerable<CommitRoot> commits = new List<CommitRoot>();

            HttpResponseMessage response = _client.GetAsync(string.Format(Startup.Configuration["githubApiSettings:searchCommits"], ownerName, repository)).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                commits = JsonConvert.DeserializeObject<IEnumerable<CommitRoot>>(data);
            }

            return commits.Select(root => root.Commit).OrderByDescending(commit => commit.Committer.Date).Take(limit).ToList();
        }
    }
}
