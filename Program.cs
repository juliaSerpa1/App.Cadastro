using System;

namespace Cadastro.Officina
{
    class Program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
             string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCarros();
						break;
					case "2":
						InserirCarros();
						break;
					case "3":
						AtualizarCarro();
						break;
					case "4":
						ExcluirCarro();
						break;
					case "5":
						VisualizarCarro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

		    Console.WriteLine("Obrigado por utilizar nossos serviços.");
		    Console.ReadLine();
    }

        private static void ExcluirCarro()
		{
                Console.Write("Digite o id do carro: ");
                int indiceCarro = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceCarro);
		}
        
        private static void VisualizarCarro()
		{
                Console.Write("Digite o id do carro: ");
                int indiceCarro = int.Parse(Console.ReadLine());

                var carro = repositorio.RetornaPorId(indiceCarro);

                Console.WriteLine(carro);
		}

        private static void AtualizarCarro()
		{
                Console.Write("Digite o id do carro: ");
                int indiceCarro = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Marca)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
                }
                Console.Write("Digite a Marca entre as opções acima: ");
                int entradaMarca = int.Parse(Console.ReadLine());

                Console.Write("Digite o Modelo do carro: ");
                string entradaModelo = Console.ReadLine();

                Console.Write("Digite a Placa do carro: ");
                int entradaPlaca = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição do problema: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaCarro = new Carro(id: indiceCarro,
                                            marca: (Marca)entradaMarca,
                                            modelo: entradaModelo,
                                            placa: entradaPlaca,
                                            descricao: entradaDescricao);

                repositorio.Atualiza(indiceCarro, atualizaCarro);
            }

        private static void ListarCarros()
		{
                Console.WriteLine("Listar carros");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                        Console.WriteLine("Nenhum carro cadastrado.");
                        return;
                }

                foreach (var carro in lista)
                {
            var excluido = carro.retornaExcluido();
                    
                        Console.WriteLine("#ID {0}: - {1} {2}", carro.retornaId(), carro.retornaModelo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirCarro()
		{
                Console.WriteLine("Inserir novo carro");


                foreach (int i in Enum.GetValues(typeof(Marca)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
                }
                Console.Write("Digite a Marca entre as opções acima: ");
                int entradaMarca = int.Parse(Console.ReadLine());

                Console.Write("Digite o Modelo do carro: ");
                string entradaModelo = Console.ReadLine();

                Console.Write("Digite a Placa do carro: ");
                int entradaPlaca = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição do problema: ");
                string entradaDescricao = Console.ReadLine();

                Carro novoCarro = new Carro(id: repositorio.ProximoId(),
                                            marca: (Marca)entradaMarca,
                                            modelo: entradaModelo,
                                            placa: entradaPlaca,
                                            descricao: entradaDescricao);

                repositorio.Insere(novoCarro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Avanade a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar carros");
			Console.WriteLine("2- Inserir novo carro");
			Console.WriteLine("3- Atualizar carro");
			Console.WriteLine("4- Excluir carro");
			Console.WriteLine("5- Visualizar carro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
