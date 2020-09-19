using System;
using System.Collections.Generic;
using System.Text;

namespace web
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Livro 1", 13.22m));
            livros.Add(new Livro("002", "Livro 2", 22.22m));
            livros.Add(new Livro("003", "Livro 3", 99.21m));
            return livros;
        }
    }
}
