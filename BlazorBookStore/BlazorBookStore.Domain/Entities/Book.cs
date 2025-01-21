using BlazorBookStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBookStore.Domain.Entities
{
    public class Book
    {
        public int LivroId{ get; set; }
        
        [Required (ErrorMessage = "Informe o título do livro")]
        [StringLength (150)]
        public string? Titulo{ get; set; }

        [Required(ErrorMessage = "Informe o autor do livro")]
        [StringLength(200)]
        public string? Autor {  get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento")]
        public DateTime Lancamento{ get; set; }

        [Required(ErrorMessage = "Informe a capa do livro")]
        public string? Capa {  get; set; }

        [Required]
        [EnumDataType(typeof(Publisher), ErrorMessage =("Selecione a editora"))]
        public Publisher Editora {  get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = ("Selecione a categoria"))]
        public Category Categoria { get; set; }

        public Book(int livroId, string? titulo, string? autor, 
            DateTime lancamento, string? capa, Publisher editora,
            Category categoria)
        {
            LivroId = livroId;
            Titulo = titulo;
            Autor = autor;
            Lancamento = lancamento;
            Capa = capa;
            Editora = editora;
            Categoria = categoria;
        }
    }
}
