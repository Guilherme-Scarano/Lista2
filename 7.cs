using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o número de linhas das matrizes: ");
        int linhas = int.Parse(Console.ReadLine());
        Console.Write("Digite o número de colunas das matrizes: ");
        int colunas = int.Parse(Console.ReadLine());

        double[,] matriz1 = LerMatriz(linhas, colunas, "Matriz 1");
        double[,] matriz2 = LerMatriz(linhas, colunas, "Matriz 2");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenu de Opções:");
            Console.WriteLine("a) Somar as duas matrizes");
            Console.WriteLine("b) Subtrair a primeira matriz da segunda");
            Console.WriteLine("c) Adicionar uma constante às duas matrizes");
            Console.WriteLine("d) Imprimir as matrizes");
            Console.WriteLine("e) Sair");
            Console.Write("Escolha uma opção: ");
            char opcao = char.ToLower(Console.ReadLine()[0]);

            switch (opcao)
            {
                case 'a':
                    double[,] matrizSoma = SomarMatrizes(matriz1, matriz2);
                    Console.WriteLine("\nMatriz Soma:");
                    ExibirMatriz(matrizSoma);
                    break;

                case 'b':
                    double[,] matrizSubtracao = SubtrairMatrizes(matriz2, matriz1);
                    Console.WriteLine("\nMatriz Subtração (Matriz2 - Matriz1):");
                    ExibirMatriz(matrizSubtracao);
                    break;

                case 'c':
                    Console.Write("Digite o valor da constante a ser adicionada: ");
                    double constante = double.Parse(Console.ReadLine());
                    AdicionarConstante(matriz1, constante);
                    AdicionarConstante(matriz2, constante);
                    Console.WriteLine("\nConstante adicionada com sucesso.");
                    break;

                case 'd':
                    Console.WriteLine("\nMatriz 1:");
                    ExibirMatriz(matriz1);
                    Console.WriteLine("\nMatriz 2:");
                    ExibirMatriz(matriz2);
                    break;

                case 'e':
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static double[,] LerMatriz(int linhas, int colunas, string nomeMatriz)
    {
        double[,] matriz = new double[linhas, colunas];
        Console.WriteLine($"\nDigite os valores para a {nomeMatriz}:");

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                matriz[i, j] = double.Parse(Console.ReadLine());
            }
        }
        return matriz;
    }

    static double[,] SomarMatrizes(double[,] matriz1, double[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int colunas = matriz1.GetLength(1);
        double[,] matrizSoma = new double[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matrizSoma[i, j] = matriz1[i, j] + matriz2[i, j];
            }
        }
        return matrizSoma;
    }

    static double[,] SubtrairMatrizes(double[,] matriz1, double[,] matriz2)
    {
        int linhas = matriz1.GetLength(0);
        int colunas = matriz1.GetLength(1);
        double[,] matrizSubtracao = new double[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matrizSubtracao[i, j] = matriz1[i, j] - matriz2[i, j];
            }
        }
        return matrizSubtracao;
    }

    static void AdicionarConstante(double[,] matriz, double constante)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matriz[i, j] += constante;
            }
        }
    }

    static void ExibirMatriz(double[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j].ToString("F2") + "\t");
            }
            Console.WriteLine();
        }
    }
}