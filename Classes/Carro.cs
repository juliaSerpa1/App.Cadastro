using System;

namespace Cadastro.Officina
{
    public class Carro : EntidadeBase
    {
        private Marca Marca { get; set; }
		private string Modelo { get; set; }
		private string Descricao { get; set; }
		private int Placa { get; set; }
        private bool Excluido {get; set;}


        public Carro(int id, Marca marca, string modelo, string descricao, int placa)
		{
			this.Id = id;
			this.Marca = marca;
			this.Modelo = modelo;
			this.Descricao = descricao;
			this.Placa = placa;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Placa: " + this.Placa + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			    return retorno;
		}
        public string retornaModelo()
		{
			return this.Modelo;
		}

		public int retornaId()
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