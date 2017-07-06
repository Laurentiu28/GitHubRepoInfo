using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubRepoInfo.DTO
{
    public class CommitDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string SHA { get; set; }
        public DateTime Date { get; set; }
    }
}
