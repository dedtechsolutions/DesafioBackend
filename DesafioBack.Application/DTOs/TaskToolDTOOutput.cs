using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioBack.Application.DTOs
{
    public class TaskToolDTOOutput
    {
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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "The Data Criacao is Required")]
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data de Atualização")]
        public DateTime? DataAtualizacao { get; set; }
    }
}
