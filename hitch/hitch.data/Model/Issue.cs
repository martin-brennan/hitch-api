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

        public List<Issue> All()
        {
            List<Issue> issues;
            using (var connection = Database.GetConnection())
            {
                issues = connection.Query<Issue>("SELECT * FROM issues").ToList();
            }
            return issues;
        }
    }
}
