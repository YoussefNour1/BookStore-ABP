using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateModelModel(IBookAppService bookAppService) : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }
        private readonly IBookAppService _bookAppService = bookAppService;

        public void OnGet()
        {
            Book = new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}
