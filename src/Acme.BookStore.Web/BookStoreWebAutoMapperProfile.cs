using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();

        CreateMap<Pages.Authors.EditModalModel.EditAuthorView, UpdateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorView>();

        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

    }
}
