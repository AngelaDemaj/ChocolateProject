using Chocolate.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chocolate.Business.Repository
{
    public class Repository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _set;
        protected readonly ChocolateDbContext _context;

        public Repository(ChocolateDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        /// <summary>
        /// Creates an IQueryable that contains all the filters/includes/ordering
        /// </summary>
        /// <param name="filter">The Search Filter</param>
        /// <param name="includes">What to inner join</param>
        /// <param name="pageSize">How many items we want to retrieve</param>
        /// <param name="pageIndex">What is the current page of the user</param>
        /// <param name="ordering">How to order the data desc/asc</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllWithPagingAsync(
            Expression<Func<TEntity, bool>> filter = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int pageSize = 10,
            int pageIndex = 1,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordering = null)
        {
            //this is the DbSet of the entity.
            var query = (IQueryable<TEntity>)_set;

            //the following code adds the includes to the query.
            //include is equivalent to INNER JOIN in SQL
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            //we can filter the retrieved data
            //where is like WHERE in SQL
            if (filter != null)
                query = query.Where(filter);

            //we order by a column asc or desc
            //ordering is like ORDER BY in SQL
            if (ordering != null)
                query = ordering(query).AsQueryable();

            //THIS IS THE PAGING CODE!!
            //Take is like SELECT TOP(pagesize) in SQL
            /*
            SELECT * FROM Sales.SalesOrderHeader 
            ORDER BY OrderDate
            OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY
            */
            query = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            //The query executes when we write ToList();
            return await query.ToListAsync();
        }
    }
}
