using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace hitch.data.Model
{
    public class Issue
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string description_output { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }

        public IEnumerable<Issue> All()
        {
            IEnumerable<Issue> issues = Database.SimpleGetAll<Issue>();
            return issues;
        }

        public Issue Get(int id)
        {
            Issue issue = Database.SimpleGet<Issue>(id);
            return issue;
        }

        public int Add(Issue issue)
        {
            int id = 0;
            using (var connection = Database.GetConnection())
            {
                DateTime now = DateTime.UtcNow;
                id = connection.Execute("INSERT INTO issues(title, description, description_output, created, modified) VALUES(@title, @description, @description_output, @created, @modified)",
                new
                {
                    title = issue.title,
                    description = issue.description,
                    description_output = issue.description_output,
                    created = now,
                    modified = now
                });
            }
            return id;
        }
    }
}
