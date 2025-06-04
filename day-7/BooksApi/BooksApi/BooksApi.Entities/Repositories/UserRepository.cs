using BooksApi.Data.Models;
using BooksApi.Entities.Context;
using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entities.Repositories
{
    public class UserRepository(BookDbContext bookDbContext) : IUserRepository
    {
        private readonly BookDbContext _dbContext = bookDbContext;

        //Task<IList<User>>
        public async Task<IList<User>> GetAllUser(FilterVM filterRequest)
        {
            var query = _dbContext.Users.AsQueryable();

           
            if (!string.IsNullOrWhiteSpace(filterRequest.SearchFilter))
            {
                query = query.Where(u => u.Name.ToLower().Contains(filterRequest.SearchFilter.ToLower()));
            }

            
            if (filterRequest.SortBy.ToLower() == "name")
            {
                if (filterRequest.SortDirection == "asc")
                    query = query.OrderBy(u => u.Name);
                else
                    query = query.OrderByDescending(u => u.Name);
            }

            if (filterRequest.SortBy.ToLower() == "email")
            {
                if (filterRequest.SortDirection == "asc")
                    query = query.OrderBy(u => u.Email);
                else
                    query = query.OrderByDescending(u => u.Email);
            }

            
            query = query.Skip((filterRequest.PageNumber - 1) * filterRequest.PageSize).Take(filterRequest.PageSize);

         
            return await query.Select(u => new User()
            {
                Id = u.Id,
                Email = u.Email,
                Password = u.Password,
                Name = u.Name,
                Role = u.Role,
                BookDetails = u.BookDetails.ToList()
            }).ToListAsync();
        }

    }
}
