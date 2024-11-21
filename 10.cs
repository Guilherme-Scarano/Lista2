using System;

class Programa
{
    static void Main()
    {
        Random random = new Random();

        Console.Write("Digite o número de regiões (linhas): ");
        int R = int.Parse(Console.ReadLine());

        Console.Write("Digite o número de cidades (colunas): ");
        int C = int.Parse(Console.ReadLine());

        int[,] tropas = new int[R, C];

        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                tropas[i, j] = random.Next(0, 101);
            }
        }

        Console.WriteLine("Matriz das Tropas (Quantidade de Tropas por Cidade):");
        for (int i = 0; i < R; i++)
        {
            Console.Write($"Região {i + 1}: ");
            for (int j = 0; j < C; j++)
            {
                Console.Write(tropas[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nForça Total das Regiões:");
        for (int i = 0; i < R; i++)
        {
            int somaTropas = 0;
            for (int j = 0; j < C; j++)
            {
                somaTropas += tropas[i, j];
            }
            Console.WriteLine($"Região {i + 1}: {somaTropas} tropas");
        }
    }
}