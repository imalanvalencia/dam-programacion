using Ejercicio1;

namespace Ejercicio1
{

    public record Libro(string Titulo, string Autor, string Editorial, int NumPaginas, string ISBN, string Reseña)
    {
        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Editorial: {Editorial}, ISBN: {ISBN}, Nº Páginas: {NumPaginas}, Reseña: {Reseña}";
        }
    }


    /// TODO: Completar la clase Biblioteca con los métodos indicados en el enunciado


    class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>
            {
                new Libro
                (
                    "Don Quijote de la Mancha",
                    "Miguel de Cervantes",
                    "Editorial EDAF, S.A",
                     765,
                    "9788441405298",
                    "El libro, sinopsis… Nos presentan a este personaje como un loco trastornado a causa de las novelas de caballerías, pero, ¿Quién dice que el señor Quijana era sólo eso? ¿Por algún motivo será la cumbre de la literatura española verdad? Y aquí se plantea la duda héroe o simplemente viejo loco."
                ),
                new Libro
                (
                    Titulo : "El camino",
                    Autor : "Miguel Delibes",
                    Editorial : "Espasa",
                    NumPaginas : 187,
                    ISBN : "9788467023664",
                    Reseña : "Una de las más importantes obras de Miguel Delibes cuenta la historia de un niño , Daniel el Mochuelo, que tiene que trasladarse a la ciudad para cursar bachillerato. Una noche antes de partir Daniel recordará todo lo que le ha ocurrido en este lugar, sus amigos, sus peripecias, y descubrirá que su camino está en esa aldea, unido a lo que ha sido hasta ese momento su vida. Nostálgica novela realista a través de la cual podemos aprender que nunca sabemos lo que tenemos hasta que se nos ha escapado."
                ),
                new Libro
                (
                    Titulo : "Cien años de soledad",
                    Autor : "Gabriel García Márquez",
                    Editorial : "Alfaguara",
                    NumPaginas : 562,
                    ISBN : "9788420471839",
                    Reseña : "Muchos años después, frente al pelotón de fusilamiento, el coronel Aureliano Buendía había de recordar aquella tarde remota en que su padre lo llevó a conocer el hielo.» Con estas palabras empieza una novela ya legendaria en los anales de la literatura universal, una de las aventuras literarias más fascinantes de nuestro s iglo.Millones de ejemplares de Cien años de soledad leídos en todas las lenguas y el premio Nobel de Literatura coronando una obra que se había abierto paso «boca a boca» -como gusta decir el escritor-son la más palpable demostración de que la aventura fabulosa de la familia Buendía - Iguarán, con sus milagros, fantasías, obsesiones, tragedias, incestos, adulterios, rebeldías, descubrimientos y condenas, representaba al mismo tiempo el mito y la historia, la tragedia y el amor del mundo entero."
                ),
                new Libro
                (
                    Titulo : "La Regenta",
                    Autor : "Leopoldo Alas Clarín",
                    Editorial : "Crítica",
                    NumPaginas : 182,
                    ISBN : "9788484326977",
                    Reseña : "En La Regenta, sin lugar a dudas una de las cumbres de la novela realista, Leopoldo Alas alcanzó a cifrar de forma inolvidable uno de los motivos que obsesionaron a la narrativa europea de la segunda mitad del siglo XIX: el retrato de un carácter femenino que se debate entre el deseo y su represión , y que sufre, en este caso, las asechanzas de un galán y de un cura.La peripecia tiene como trasfondo la magistraly despiadada descripción del entorno de Ana Ozores, esa Vetusta murmuradora y provinciana en la que toda vanidad e hipocresía tiene su asiento. José Luis Gómez, tras un minucioso análisis de las primeras ediciones de la obra, sigue el texto de la tercera(1901), revisada por Clarín y publicada poco antes de su muerte. El prólogo de S. Beser al autor y su novela en el contexto de la creación europea y española de la época, mientras que la anotación facilita la comprensión de cada uno de los pormenores del rico universo clariniano."
                ),
                new Libro
                (
                   Titulo : "Los mejores cuentos de Clarín",
                   Autor : "Leopoldo Alas Clarín",
                   Editorial : "De Vecchi",
                   NumPaginas : 145,
                   ISBN : "9788431533441",
                   Reseña : "Una cuidadosa selección que nos muestra la riqueza de los recursos estilísticos de este gran escritor del s. XIX.En el volumen se incluyen: Doña Berta, Benedictino, Manín de Pepa José, Zurita, Cambio de luz, y la Conversión de Chiripa."
                )
            };

            Console.WriteLine("Ejercicio 1. Gestión en Biblioteca\n");
            Biblioteca biblioteca = new Biblioteca("EL RINCÓN DE LEER", libros);
            biblioteca.Presta("22111333", "9788420471839");
            biblioteca.Presta("22111333", "9788431533441");

            Console.WriteLine(biblioteca.EstaPrestado("9788420471839"));
            Console.WriteLine(biblioteca.EstaPrestado("22111444"));

            Console.WriteLine(biblioteca.BuscaPorISBN("9788431533441"));
            Console.WriteLine(biblioteca.BuscaPorISBN("97884551533441"));
            Console.WriteLine(biblioteca.CuentaLibrosConNumeroDePaginasMenorA(400));

            Console.WriteLine(biblioteca.BuscaPorISBN("9788467023664"));
            biblioteca.EliminaPorAutor("Miguel Delibes");
            Console.WriteLine(biblioteca.BuscaPorISBN("9788467023664"));

            Console.WriteLine(biblioteca.AutorTitulo("9788431533441"));

            Console.WriteLine("Pulsa una tecla para finalizar...");
            Console.ReadLine();
        }
    }


}