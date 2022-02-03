using System;

namespace DIO.Series
{
    class Program
    {
		static JogoRepositorio repositorioJogo = new JogoRepositorio();
        static SerieRepositorio repositorio = new SerieRepositorio();

		public static void MenuSeries(string opcao)
		{
			opcao.ToUpper();
			switch (opcao)
			{
				case "1": ListarSeries(); break;
				case "2": InserirSerie(); break;
				case "3": AtualizarSerie(); break;
				case "4": ExcluirSerie(); break;
				case "5": VisualizarSerie(); break;
				case "X": MenuPrincipal(); break;
				case "C": Console.Clear(); break;
				default: throw new ArgumentOutOfRangeException();
			}
			
		}
		public static void MenuJogos(string opcao)
		{
			opcao.ToUpper();
			switch (opcao)
			{
				case "1": ListarJogos(); break;
				case "2": InserirJogo(); break;
				case "3": AtualizarJogo(); break;
				case "4": ExcluirJogo(); break;
				case "5": VisualizarJogo(); break;
				case "X": MenuPrincipal(); break;
				case "C": Console.Clear(); break;
				default: throw new ArgumentOutOfRangeException();
			}
		}

		public static void MenuPrincipal()
		{
			string modo = EscolherModo();

			while (modo.ToUpper() != "X")
			{
				switch (modo)
				{
					case "1":
						var resA = ObterOpcaoUsuario();
						MenuSeries(resA);
						break;
					case "2":
						var resB = ObterOpcaoDeJogoUsuario();
						MenuJogos(resB);
						break;
					case "C":	Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}


        static void Main(string[] args)
        {
			MenuPrincipal();
        }

		#region TVSHOWS
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaPorId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		#endregion
		#region GAME

		private static string ObterOpcaoDeJogoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Escolha o modo de operação:");

			Console.WriteLine("1- Listar jogos");
			Console.WriteLine("2- Inserir novo jogo");
			Console.WriteLine("3- Atualizar jogo");
			Console.WriteLine("4- Excluir jogo");
			Console.WriteLine("5- Visualizar jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void ExcluirJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			repositorioJogo.Exclui(indiceJogo);
		}

        private static void VisualizarJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			var jogo = repositorioJogo.RetornaPorId(indiceJogo);

			Console.WriteLine(jogo);
		}

        private static void AtualizarJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(GeneroJogo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroJogo), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}
			Console.Write("Digite o estilo entre as opções acima: ");
			int entradaEstilo = int.Parse(Console.ReadLine());

			Jogo atualizaJogo = new Jogo(_id: indiceJogo,
										_genero: (GeneroJogo)entradaGenero,
										_titulo: entradaTitulo,
										_ano: entradaAno,
										_estilo: (Estilo)entradaEstilo);

			repositorioJogo.Atualiza(indiceJogo, atualizaJogo);
		}
        private static void ListarJogos()
		{
			Console.WriteLine("Listar jogos");

			var lista = repositorioJogo.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo cadastrado.");
				return;
			}

			foreach (var jogo in lista)
			{
                var excluido = jogo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaPorId(), jogo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirJogo()
		{
			Console.WriteLine("Inserir novo jogo");

			foreach (int i in Enum.GetValues(typeof(GeneroJogo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroJogo), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}
			Console.Write("Digite o estilo entre as opções acima: ");

			int entradaEstilo = int.Parse(Console.ReadLine());

			Jogo novoJogo = new Jogo(_id: repositorioJogo.ProximoId(),
										_genero: (GeneroJogo)entradaGenero,
										_titulo: entradaTitulo,
										_ano: entradaAno,
										_estilo: (Estilo)entradaEstilo);

			repositorioJogo.Insere(novoJogo);
		}

		#endregion

		private static string EscolherModo()
		{
			Console.WriteLine();
			Console.WriteLine("Escolha o modo de operação:");

			Console.WriteLine("1- Séries");
			Console.WriteLine("2- Jogos");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
