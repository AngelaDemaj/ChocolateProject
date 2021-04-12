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
    [Route("api/candidates")]
    public class CandidateDataController : BaseApiController<Candidate>
    {
        public CandidateDataController(ChocolateDbContext context) : base(context)
        {

        }

        [NonAction]
        public override Expression<Func<Candidate, bool>> GetFilter(string term)
        {
            if (term == "")
            {
                return null;
            }
            else
            {
                return s => s.FirstName.Contains(term) ||
                    s.LastName.Contains(term);
            }
        }

        [NonAction]
        public override List<Expression<Func<Candidate, object>>> GetIncludes()
        {
            return null;
        }
    }
}
