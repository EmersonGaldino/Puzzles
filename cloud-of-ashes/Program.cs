using System;
using System.Text;

namespace cloud_of_ashes
{
    class Program
    {
        private static char[,] initial { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("DOJO");



            Console.WriteLine("*** Primeiro Aeroporto ***");
            Console.WriteLine(FirstDay());
            Console.WriteLine("*** FIM ***");


            for (var i = 0; i < DaysAllAirports(); i++)
            {
                Console.WriteLine($"***  DIA {i}***");
                Console.WriteLine(AllAirPorts());
                Console.WriteLine("*** FIM ***");
            }

            Console.WriteLine();
        }

        private static void Map()
        {
            initial = new char[,]
            {
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', '*', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', '*'},
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', 'A', ' ',' ', ' ', 'A', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', 'A',' ', ' ', ' ', ' ', '*'},
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', ' ', '*', ' ', ' ',' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' '}
            };
        }

        private static string CharToString(char[,] quad)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    sb.Append(quad[i, j].ToString());
                    sb.Append("|");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public static string FirstDay()
        {
            Map();
            return CharToString(initial);       
        }

        public static string FirstAirPort()
        {
            Map();
            while (true)
            {
                initial = Expand(initial);
                var airport = CountAirPort(initial);
                if (airport <= 0)
                    break;
            }
            return CharToString(initial);
        }

        public static string AllAirPorts()
        {
            Map();
            while (true)
            {
                initial = Expand(initial);
                var airports = CountAirPort(initial);
                if (airports <= 0)
                    break;
            }
            return CharToString(initial);
        }

        private static int CountAirPort(char[,] Map)
        {
            var cont = 0;

            for (var i = 0; i < Map.GetLength(0); i++)
            {
                for (var j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == 'A')
                    {
                        cont += 1;
                    }
                }
            }

            return cont;
        }

        private static char[,] Expand(char[,] Map)
        {
            char[,] matriz = new char[10, 10];
            for (var i = 0; i < Map.GetLength(0); i++)
            {
                for (var j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == ' ')
                    {
                        matriz[i, j] = ' ';
                    }
                    if (Map[i, j] == 'A')
                    {
                        matriz[i, j] = 'A';
                    }

                    if (Map[i, j] != '*') continue;
                    matriz[i, j] = '*';
                    if (j > 0)
                        matriz[i, j - 1] = '*';
                    if (j < 9)
                        matriz[i, j + 1] = '*';
                    if (i > 0)
                        matriz[i - 1, j] = '*';
                    if (i < 9)
                        matriz[i + 1, j] = '*';
                }
            }

            return matriz;
        }

        public static int DaysAllAirports()
        {
            var count = 0;
            Map();
            while (true)
            {
                count++;
                initial = Expand(initial);
                var aeroportos = CountAirPort(initial);
                if (aeroportos <= 0)
                    break;
            }

            return count;
        }

        public static int DaysFirstAirport()
        {
            var count = 0;
            Map();
            while (true)
            {
                count++;
                initial = Expand(initial);
                var airports = CountAirPort(initial);
                if (airports <= 2)
                    break;
            }

            return count;
        }
    }
}
