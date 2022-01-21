using System;
using System.IO;


namespace DIO.Animes 
{
    class Program
    {
        static AnimeRepositorio repositorio = new AnimeRepositorio();
        static void Main (string[] args )
        {
            string opcionUsuario = ObtenerOpcionUsuario();
            
            while(opcionUsuario.ToUpper() != "x"){
                switch (opcionUsuario)
                {
                    case "1":
                        ListarAnime();
                        break;
                    case "2":
                        IngresarAnime();
                        break;
                    case "3":
                        ActualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcionUsuario = ObtenerOpcionUsuario();
            }
            Console.WriteLine("Gracias por usar nuestros servicios");
            Console.ReadLine();
        }

        private static void VisualizarAnime()
		{
			Console.Write("Digite el id del anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			var anime = repositorio.RetornaPorId(indiceAnime);

			Console.WriteLine(anime);
		}

        private static void ExcluirAnime()
		{
			Console.Write("Digite el id del anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAnime);
		}

        private static void ActualizarAnime()
		{
			Console.Write("Digite el id del anime: ");
			int indiceAnime = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite el género entre las opciones de arriba: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite el titulo del anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite el año de inicio del anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite la descrpción de la serie: ");
			string entradaDescricao = Console.ReadLine();

			Anime atualizaAnime = new Anime(id: indiceAnime,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descripcion: entradaDescricao);

			repositorio.Actualiza(indiceAnime, atualizaAnime);
		}

        private static void ListarAnime()
		{
			Console.WriteLine("Listar animes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Ningun anime registrado");
				return;
			}

			foreach (var anime in lista)
			{
                bool excluido = anime.retornaExcluido() ;
                
				Console.WriteLine("#ID {0}: - {1} {2}", anime.retornaId(), anime.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void IngresarAnime()
		{
			Console.WriteLine("Ingresar nuevo anime");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite el género entre las opciones de arriba: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite el titulo del anime: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite el año de inicio del anime: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite la descripción del anime: ");
			string entradaDescripcion = Console.ReadLine();

			Anime nuevoAnime = new Anime(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descripcion: entradaDescripcion);

			repositorio.Insere(nuevoAnime);
		}

        private static string ObtenerOpcionUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Anime a su disposición!!");
            Console.WriteLine("Informa la opción deseada");

            Console.WriteLine("1 - Listar Animes");
            Console.WriteLine("2 - Ingresar Nuevo Anime");
            Console.WriteLine("3 - Actualizar Anime");
            Console.WriteLine("4 - Excluir Anime");
            Console.WriteLine("5 - Visualizar Anime");
            Console.WriteLine("C - Limpiar Pantalla");
            Console.WriteLine("X - Salir");
            Console.WriteLine();

            string opcionUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcionUsuario;
        }
    }
}

