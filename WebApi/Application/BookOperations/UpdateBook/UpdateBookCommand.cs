using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Application.BookOperations.UpdateBook
{
  public class UpdateBookCommand
  {
    public UpdateBookModel Model { get; set; }
    public int BookId { get; set; }
    private readonly BookStoreDBContext _dbContext;

    public UpdateBookCommand(BookStoreDBContext dbContext){
      _dbContext = dbContext;
    }

    public void Handle()
    {
      var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
      if (book is null)
        throw new InvalidOperationException("Book couldn't found");
      
      book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
      book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
      book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
      book.Title = Model.Title != default ? Model.Title : book.Title;
      _dbContext.SaveChanges();
    }
    
  }

  public class UpdateBookModel
  {
    public string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }

    }
}