using System.ComponentModel.DataAnnotations;

namespace Books.Dtos
{
    public class BookUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title {get; set;}
       
        [Required]
        [MaxLength(150)]
        public string Authors {get; set;}
        
        [Required]
        public string Type {get; set;}
        
    }
}