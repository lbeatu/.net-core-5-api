using System.ComponentModel.DataAnnotations;

namespace Books.Dtos
{
    public class BookReadDto
    {
        
        public int Id { get; set; }
            
        public string Title {get; set;}
       
        public string Authors {get; set;}
                
        public string Type {get; set;}
        
    }
}