using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o número de linhas das matrizes: ");
        int linhas = int.Parse(Console.ReadLine());
        Console.Write("Digite o número de colunas das matrizes: ");
        int colunas = int.Parse(Console.ReadLine());

        int[,] matriz1 = GerarMatrizAleatoria(linhas, colunas);
        int[,] matriz2 = GerarMatrizAleatoria(linhas, colunas);

        Console.WriteLine("\nMatriz 1:");
        ExibirMatriz(matriz1);

        Console.WriteLine("\nMatriz 2:");
        ExibirMatriz(matriz2);

        if (linhas == matriz1.GetLength(0) && colunas == matriz1.GetLength(1) &&
            linhas == matriz2.GetLength(0) && colunas == matriz2.GetLength(1))
        {
            int[,] matrizSoma = SomarMatrizes(matriz1, matriz2);
            Console.WriteLine("\nMatriz Soma:");
            ExibirMatriz(matrizSoma);
        }
        else
        {
            Console.WriteLine("As matrizes não são da mesma ordem e não podem ser somadas.");
        }
    }

    static int[,] GerarMatrizAleatoria(int linhas, int colunas)
    {
        int[,] matriz = new int[linhas, colunas];
        Random random = new Random();

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matriz[i, j] = random.Next(1, 10); // Gera valores entre 1 e 9
            }
        }

        return matriz;
    }

    static void ExibirMatriz(int[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int[,] SomarMatrizes(int[,] matriz1, int[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int colunas = matriz1.GetLength(1);
        int[,] matrizSoma = new int[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matrizSoma[i, j] = matriz1[i, j] + matriz2[i, j];
            }
        }

        return matrizSoma;
    }
}