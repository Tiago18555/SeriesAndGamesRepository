using System;

namespace DIO.Series
{
    public class Jogo : EntidadeBase
    {
		private GeneroJogo Genero { get; set; }
        private Estilo Estilo  { get; set; }
		private string Titulo { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Jogo(int _id, GeneroJogo _genero, Estilo _estilo, string _titulo, int _ano)
		{
			this.Id = _id;
			this.Genero = _genero;
            this.Estilo = _estilo;
			this.Titulo = _titulo;
			this.Ano = _ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Estilo: " + this.Estilo + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaPorId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}