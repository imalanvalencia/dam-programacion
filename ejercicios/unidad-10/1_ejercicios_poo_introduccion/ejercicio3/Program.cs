using System;

namespace Ejercicio3
{
    public class Program
    {
        public static Uri[] CreaUris(int cantidad)
        {
            Uri[] uris = new Uri[cantidad];



            for (int i = 0; i < uris.Length; i++)
            {
                
                Console.WriteLine($"Introduce URI {i + 1}: ");
                string entrada = Console.ReadLine() ?? "";

                if (Uri.TryCreate(entrada, UriKind.Absolute, out Uri? resultado))
                {
                    uris[i] = resultado;
                    Console.WriteLine("¿Es una URI válida? True\n");

                    MuestraInformacion(uris[i]);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("¿Es una URI válida? False");
                    Console.WriteLine("URI inválida detectada, se creará URI por defecto.\n");
                    uris[i] = new Uri("http://localhost"); 
                }
            }

            return uris;
        }

        public static void MuestraInformacion(Uri uri)
        {
            Console.WriteLine($"URI completa: {uri.AbsoluteUri}");
            Console.WriteLine($"Esquema: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Puerto: {uri.Port}");
            Console.WriteLine($"Ruta: {uri.AbsolutePath}");
            Console.WriteLine($"Query: {uri.Query}");
            Console.WriteLine($"¿Es archivo?: {uri.IsFile}");
            Console.WriteLine($"¿Es UNC?: {uri.IsUnc}");
            Console.WriteLine($"¿Es absoluta?: {uri.IsAbsoluteUri}\n");
        }

        public static bool ComparaUris(Uri uri1, Uri uri2)
        {
            Console.WriteLine($"¿{uri1.AbsoluteUri} y {uri2.AbsoluteUri} tienen el mismo host? {uri1.Host == uri2.Host}");
            Console.WriteLine($"¿{uri1.AbsoluteUri} y {uri2.AbsoluteUri} tienen el mismo esquema? {uri1.Scheme == uri2.Scheme}");
            Console.WriteLine($"¿{uri1.AbsoluteUri} y {uri2.AbsoluteUri} son iguales? {uri1.Equals(uri2)}\n");

            return uri1.Host == uri2.Host && uri1.Scheme == uri2.Scheme && uri1.Equals(uri2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 3: Sistema de gestión de URIs (TAD de la BCL)");
            Console.WriteLine("Usando la clase Uri de System");
            Console.WriteLine();
            Console.WriteLine("=== CREACIÓN DE URIs Y ANÁLISIS ===");

            Uri[] uris = CreaUris(4);

            Console.WriteLine("=== COMPARACIONES ===");

            if (uris[0] != null && uris[1] != null)
            {
                Console.Write($"Comparando {uris[0].OriginalString} y {uris[1].OriginalString} ");
                Console.WriteLine(ComparaUris(uris[0], uris[1]) ? "son iguales." : "Son diferentes.");
            }
            if (uris[2] != null && uris[2] != null)
            {
                Console.Write($"Comparando {uris[2].OriginalString} y {uris[2].OriginalString} ");
                Console.WriteLine(ComparaUris(uris[2], uris[2]) ? "son iguales." : "Son diferentes.");
            }
            Console.ReadLine();
        }
    }
}

