using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o número de linhas da matriz: ");
        int linhas = int.Parse(Console.ReadLine());

        Console.Write("Digite o número de colunas da matriz: ");
        int colunas = int.Parse(Console.ReadLine());

        int[,] matriz = new int[linhas, colunas];

        Console.WriteLine("Digite os valores da matriz:");
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int menorValor = EncontrarMenorValor(matriz);
        Console.WriteLine("O menor valor da matriz é: " + menorValor);
    }

    static int EncontrarMenorValor(int[,] matriz)
    {
        int menor = matriz[0, 0];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] < menor)
                {
                    menor = matriz[i, j];
                }
            }
        }
        return menor;
    }
}