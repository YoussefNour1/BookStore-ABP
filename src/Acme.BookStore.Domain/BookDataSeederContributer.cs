using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookDataSeederContributer(IRepository<Book, Guid> BookRepository) : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository = BookRepository;
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.AnyAsync())
            {
                return;
            }
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "To Kill a Mockingbird",
                    Type = BookType.Fantastic,
                    PublishDate = new DateTime(1960, 7, 11),
                    Price = 18.9f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Lord of the Rings",
                    Type = BookType.Fantastic,
                    PublishDate = new DateTime(1954, 7, 29),
                    Price = 30.0f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Pride and Prejudice",
                    Type = BookType.Poetry,
                    PublishDate = new DateTime(1813, 1, 28),
                    Price = 10.0f
                },
                autoSave: true
            );

        }
    }
}
