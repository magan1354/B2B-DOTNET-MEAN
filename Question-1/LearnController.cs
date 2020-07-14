using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;

namespace WebApplication2
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnController : Controller
    {
        public string GetLearnerName(string name)
        {
            Learner l = GetLearnerFromList(name);
            string Name = l.Name;
            return Name;
        }

        public int GetLearnerId(string name)
        {
            Learner l = GetLearnerFromList(name);
            int learnerId = l.Id;
            return learnerId;
        }

        public Learner GetLearnerFromList(string name)
        {
            Learner i = new Learner();
            List<Learner> learners = new List<Learner>()
            {
                new Learner()
                {
                    Id = 1,
                    Name = "xyz",
                    courseId = 100
                },
                new Learner()
                {
                    Id = 2,
                    Name = "abc",
                    courseId = 200
                }
            };

            foreach (Learner learner in learners)
            {
                if (learner.Name == name)
                {
                    i = learner;
                }
            }

            return i;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = CreateResponse(System.Net.HttpStatusCode.OK, "value");
            Learner i = GetLearnerFromList("abc");

            if (i == null)
            {
                return CreateResponse(System.Net.HttpStatusCode.NotFound, "value");
            }

            return CreateResponse(System.Net.HttpStatusCode.OK, "value");
        }

        private HttpResponseMessage CreateResponse(HttpStatusCode oK, object value)
        {
            throw new NotImplementedException();
        }
    }
}
