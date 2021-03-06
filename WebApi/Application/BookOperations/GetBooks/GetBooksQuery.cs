using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;

namespace WebApi.Application.BookOperations.GetBooks
{
  public class GetBooksQuery
  {

    private readonly BookStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookStoreDBContext dBContext, IMapper mapper)
    {
      _dbContext = dBContext;
      _mapper = mapper;
    }

    public List<BooksViewModel> Handle()
    {
      var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
      List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
      //new List<BooksViewModel>();
      // foreach(var book in bookList)
      // {
      //   vm.Add(new BooksViewModel(){
      //     Title = book.Title,
      //     Genre = ((GenreEnum)book.GenreId).ToString(),
      //     PageCount = book.PageCount,
      //     PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
      //   });
      // }
      return vm;
    }
  }

  public class BooksViewModel
  {
    public string Title { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
    public string Genre { get; set; }
  }
}