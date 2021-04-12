using Chocolate.DataAccess;
using Chocolate.Business.Repository;
using ChocolateProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chocolate.Business.Helpers;

namespace Chocolate.Business.ApiControllers
{
    //Generic controller. For example the T will be supplier for SupplierDataController
    public abstract class BaseApiController<T> : ControllerBase where T : class
    {
        //we need the same context for both web applications because they both use the same database.
        protected readonly ChocolateDbContext _context;

        public BaseApiController(ChocolateDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is the Api method that all index views use
        /// </summary>
        /// <param name="model">The JSON that is sent from datatables library</param>
        /// <returns></returns>
        [Route("query")]
        [HttpPost]
        public async Task<IActionResult> Query(DatatablesPostModel model)
        {
            return Ok(await GetData(model));
        }

        /// <summary>
        /// This method Retrieves data and applies filters/ordering/paging from our database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected async Task<DatatableResponse<T>> GetData(DatatablesPostModel model)
        {
            //counts the number of rows in the db.
            var total = await _context.Set<T>()
                .CountAsync();

            //how many items per page. Example 10
            var pageSize = model.Length;

            //calculates the page we want
            var pageIndex = (int)Math.Ceiling(
                (decimal)(model.Start / model.Length) + 1);

            //Column and how to sort. This is how datatables sends us the information
            var columnName = model.Columns[model.Order[0].Column].Data;
            //descending sort or asc
            var isDescending = model.Order[0].Dir == "desc";

            //initializes the repository
            var repository = new Repository<T>(_context);

            //Here we get the search value from datatable
            var filter = GetFilter(model.Search.Value);
            //this method gets the includes for the entity
            var includes = GetIncludes();

            var gridItems = await repository
                .GetAllWithPagingAsync(filter, includes,
                    pageSize, pageIndex, t => t.OrderingHelper(columnName, isDescending));

            //we map the data to the response we want to send
            var response = new DatatableResponse<T>
            {
                data = gridItems,
                draw = model.Draw,
                recordsFiltered = total,
                recordsTotal = total
            };

            return response;
        }

        //these must be implemented by the children of this class
        public abstract Expression<Func<T, bool>> GetFilter(string term);
        public abstract List<Expression<Func<T, object>>> GetIncludes();
    }
}
