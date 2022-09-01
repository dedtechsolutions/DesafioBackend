using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioBack.Application.DTOs
{
    public class TaskToolDTOInput
    {
        [DisplayName("Titulo")]
        public int Id { get; set; }

        [DisplayName("Titulo")]
        [Required(ErrorMessage = "The Titulo is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "The Descricao is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
