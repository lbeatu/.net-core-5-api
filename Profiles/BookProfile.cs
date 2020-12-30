using AutoMapper;
using Books.Dtos;
using Books.Models;

namespace Books.Profiles
{
    public class BooksProfiles:Profile
    {
        public BooksProfiles()
        {
             //Source -> Target
            CreateMap<Book,BookReadDto>();
            CreateMap<BookCreateDto,Book>();
            CreateMap<BookUpdateDto,Book>();
            CreateMap<Book,BookUpdateDto>();
        }
    }
}