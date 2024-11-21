using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite a ordem da matriz (máximo 100): ");
        int n = int.Parse(Console.ReadLine());

        if (n > 100)
        {
            Console.WriteLine("O tamanho máximo da matriz é 100.");
            return;
        }

        int[,] matriz = new int[n, n];
        Random random = new Random();

        Console.WriteLine("Matriz gerada:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matriz[i, j] = random.Next(1, 101); // Gerando valores entre 1 e 100
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nDiagonal principal da matriz:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(matriz[i, i] + " ");
        }
    }
}