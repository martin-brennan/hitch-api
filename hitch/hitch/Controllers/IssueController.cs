using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hitch.Controllers
{
    public class IssueController : ApiController
    {
        [Route("issues")]
        public IEnumerable<hitch.data.Model.Issue> GetAllIssues()
        {
            return new hitch.data.Model.Issue().All();
        }

        [Route("issues/{id}")]
        public hitch.data.Model.Issue Get(int id)
        {
            return new hitch.data.Model.Issue().Get(id);
        }
    }
}
