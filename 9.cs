using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Retangulo> retangulos = new List<Retangulo>();

        for (int i = 0; i < n; i++)
        {
            var coordenadas = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int xi = coordenadas[0], xf = coordenadas[1], yi = coordenadas[2], yf = coordenadas[3];
            retangulos.Add(new Retangulo(xi, xf, yi, yf));
        }

        Console.WriteLine(CalcularAreaTotal(retangulos));
    }

    static int CalcularAreaTotal(List<Retangulo> retangulos)
    {
        List<Evento> eventos = new List<Evento>();

        foreach (var ret in retangulos)
        {
            eventos.Add(new Evento(ret.Xi, ret.Yi, ret.Yf, true));  // Evento de início
            eventos.Add(new Evento(ret.Xf, ret.Yi, ret.Yf, false)); // Evento de fim
        }

        eventos.Sort((e1, e2) => e1.X.CompareTo(e2.X)); // Ordena os eventos pelo eixo X

        int areaTotal = 0;
        int ultimoX = eventos[0].X;
        List<Intervalo> intervalosAtivos = new List<Intervalo>();

        foreach (var evt in eventos)
        {
            areaTotal += CalcularComprimentoCoberto(intervalosAtivos) * (evt.X - ultimoX);
            ultimoX = evt.X;

            if (evt.EhInicio)
            {
                intervalosAtivos.Add(new Intervalo(evt.Y1, evt.Y2));
            }
            else
            {
                intervalosAtivos.RemoveAll(i => i.Inicio == evt.Y1 && i.Fim == evt.Y2);
            }
        }

        return areaTotal;
    }

    static int CalcularComprimentoCoberto(List<Intervalo> intervalos)
    {
        if (intervalos.Count == 0) return 0;

        intervalos.Sort((i1, i2) => i1.Inicio.CompareTo(i2.Inicio));

        int comprimentoTotal = 0;
        int inicioAtual = intervalos[0].Inicio;
        int fimAtual = intervalos[0].Fim;

        foreach (var intervalo in intervalos)
        {
            if (intervalo.Inicio > fimAtual)
            {
                comprimentoTotal += fimAtual - inicioAtual;
                inicioAtual = intervalo.Inicio;
                fimAtual = intervalo.Fim;
            }
            else
            {
                fimAtual = Math.Max(fimAtual, intervalo.Fim);
            }
        }

        comprimentoTotal += fimAtual - inicioAtual; // Adiciona o último intervalo
        return comprimentoTotal;
    }
}

class Retangulo
{
    public int Xi { get; }
    public int Xf { get; }
    public int Yi { get; }
    public int Yf { get; }

    public Retangulo(int xi, int xf, int yi, int yf)
    {
        Xi = xi;
        Xf = xf;
        Yi = yi;
        Yf = yf;
    }
}

class Evento
{
    public int X { get; }
    public int Y1 { get; }
    public int Y2 { get; }
    public bool EhInicio { get; }

    public Evento(int x, int y1, int y2, bool ehInicio)
    {
        X = x;
        Y1 = y1;
        Y2 = y2;
        EhInicio = ehInicio;
    }
}

class Intervalo
{
    public int Inicio { get; }
    public int Fim { get; }

    public Intervalo(int inicio, int fim)
    {
        Inicio = inicio;
        Fim = fim;
    }
}