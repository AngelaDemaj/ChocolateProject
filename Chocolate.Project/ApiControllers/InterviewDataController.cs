using Chocolate.Business.ApiControllers;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChocolateProject.ApiControllers
{
    [ApiController]
    [Route("api/interviews")]
    public class InterviewDataController : BaseApiController<Interview>
    {
        public InterviewDataController(ChocolateDbContext context) : base(context)
        {
        }

        [NonAction]
        public override Expression<Func<Interview, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }

            return s => s.Candidate.LastName.Contains(term) ||
                        s.Employee.LastName.Contains(term);
        }

        [NonAction]
        public override List<Expression<Func<Interview, object>>> GetIncludes()
        {
            return new List<Expression<Func<Interview, object>>>
            {
                i=>i.Candidate,
                i=>i.Employee
            };
        }
    }
}