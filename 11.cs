using System;

class DesafioTesouro
{
    static void Main()
    {
        Random random = new Random();

        Console.Write("Digite o tamanho da matriz quadrada (N x N): ");
        int N = int.Parse(Console.ReadLine());

        int[,] mapaTesouro = new int[N, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                mapaTesouro[i, j] = random.Next(1, 101);
            }
        }

        Console.WriteLine("Mapa do Tesouro (Quantidade de Moedas em Cada Região):");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(mapaTesouro[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int somaDiagonalPrincipal = 0;
        int somaDiagonalSecundaria = 0;

        for (int i = 0; i < N; i++)
        {
            somaDiagonalPrincipal += mapaTesouro[i, i];
            somaDiagonalSecundaria += mapaTesouro[i, N - 1 - i];
        }

        Console.WriteLine($"\nSoma da Diagonal Principal: {somaDiagonalPrincipal}");
        Console.WriteLine($"Soma da Diagonal Secundária: {somaDiagonalSecundaria}");

        if (somaDiagonalPrincipal > somaDiagonalSecundaria)
        {
            Console.WriteLine("O maior tesouro está na diagonal principal, vamos para lá!");
        }
        else if (somaDiagonalSecundaria > somaDiagonalPrincipal)
        {
            Console.WriteLine("O maior tesouro está na diagonal secundária, vamos para lá!");
        }
        else
        {
            Console.WriteLine("As duas diagonais têm a mesma quantidade de moedas!");
        }
    }
}