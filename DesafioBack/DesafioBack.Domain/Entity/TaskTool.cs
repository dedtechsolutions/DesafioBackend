using DesafioBack.Domain.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBack.Domain.Entity
{
    [Table("Tarefas")]
    public class TaskTool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("data_atualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        public TaskTool(int id, string titulo, string descricao, DateTime dataCriacao)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidationDomain(titulo, descricao, dataCriacao);
        }

        private void ValidationDomain(string titulo, string descricao, DateTime dataCriacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "Invalid titulo. titulo is required");
            DomainExceptionValidation.When(titulo.Length < 5, "Invalid titulo, too short, minimun 5 charecters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Invalid Descricao, is required");
            DomainExceptionValidation.When(descricao.Length < 5, "Invalid descricao, too short, minimun 5 charecters");

            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
        }
    }
}
