using System.Collections.Generic;
using AutoMapper;
using Books.Data;
using Books.Dtos;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controller
{   
    [Route("api/books")]
    [ApiController]
    public class BooksController:ControllerBase
    {
        private readonly IBookRepo _repository;

        private readonly IMapper _mapper ;

        public BooksController (IBookRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult <IEnumerable<BookReadDto>> GetAllBooks()
        {
            var books=_repository.GetAllBooks();

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }
         //Get api/book/{id}
        [HttpGet("{id}",Name="GetBookById")]
        public ActionResult <BookReadDto> GetBookById(int id)
        {
            var book=_repository.GetBookById(id);

            if(book!=null)
            {
            return Ok(_mapper.Map<BookReadDto>(book));
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult <BookReadDto> CreateCommand(BookCreateDto bookCreateDto)
        {
            var bookModal=_mapper.Map<Book>(bookCreateDto);
             _repository.AddBook(bookModal);
             _repository.SaveChanges(); // dont forget

            var bookReadDto = _mapper.Map<BookReadDto>(bookModal);

            return CreatedAtRoute(nameof(GetBookById), new {Id=bookReadDto.Id},bookReadDto );
        }

         [HttpPut("{id}")]
        public ActionResult <BookReadDto> UpdateCommand(int id ,BookUpdateDto bookUpdateDto)
        {
            var bookModalFromRepo=_repository.GetBookById(id);
            if(bookModalFromRepo==null)
            {
                return NotFound();
            }
        
            _mapper.Map(bookUpdateDto,bookModalFromRepo);

            _repository.UpdateBook(bookModalFromRepo);     

            _repository.SaveChanges();

            return NoContent();   
        }

         //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var bookModalFromRepo=_repository.GetBookById(id);
            if(bookModalFromRepo==null)
            {
                return NotFound();
            }
            _repository.DeleteBook(bookModalFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}