using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:
            //Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
            //Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
            //Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.

            Console.WriteLine("Puzzle numeros divisiveis.");


            for (var i = 100 - 1; i >= 1; i--)
            {
                

                if(i % 3 == 0)
                    Console.WriteLine( $"Fizz -- {i}");

                if(i % 5 == 0)
                    Console.WriteLine( $"Buzz -- {i}");


                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine($"FizzBuzz -- {i}");
               
            }
        }
    }
}
