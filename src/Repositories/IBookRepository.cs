﻿using BookAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();

        Task<Book> GetById(int id);

        Task<Book> Create(Book book);

        Task Update(Book book);

        Task Delete(int id);
    }
}
