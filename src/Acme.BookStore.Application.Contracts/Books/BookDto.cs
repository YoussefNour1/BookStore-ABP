using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Acme.BookStore.Books
{
    // this dto is used to transfer the data between the application layer and the presentation layer
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
    }
}
