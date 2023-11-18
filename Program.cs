using System;
using System.Globalization;
using System.IO.Compression;
class Program
{
    static char[,] PreencherTabuleiroVazio(char[,] tabuleiro)
    { 
        for(int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for(int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                tabuleiro[i,j] = 'A';
            }
        }
        return tabuleiro;
    }
    static void ImprimirTabuleiro(char[,] tabuleiro)
    {   Console.Write("   0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine();
        for(int i = 0; i < tabuleiro.GetLength(0); i++)

        {   Console.Write(i + " ");
            for(int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                Console.Write("|"+tabuleiro[i,j]);
            }
            Console.WriteLine("|");
        }
    }

    static char[,] PreenchePosicao(char[,] tabuleiro, int coordX, int coordY, int tipoNavio, char posicaoNavio)
    {
        char[,] tabuleiroPreenchido = tabuleiro;
        char[] sigla = {'S','H','C','E','P'};
        if(posicaoNavio == 'V')
        {
            for(int i = 0; i < tipoNavio; i++)
            {
                tabuleiroPreenchido[coordX, coordY+i] = sigla[tipoNavio-1];
            }
        }
        else if(posicaoNavio == 'H')
        {
            for(int i = 0; i < tipoNavio; i++)
            {
                tabuleiroPreenchido[coordX+i,coordY] = sigla[tipoNavio-1];
            }
        }
        return tabuleiroPreenchido;

    }
    static bool VerificaPosicao(char[,] tabuleiro, int coordX, int coordY, int tipoNavio, char posicaoNavio)
    {
        if((posicaoNavio == 'V' && (tipoNavio+coordY) > 10) || (posicaoNavio == 'H' && (tipoNavio+coordX) > 10))
        {
            Console.WriteLine("Navio fora do tabuleiro.");
            return false;
        }
        else if(posicaoNavio == 'V')
        {
            for (int i = 0; i < tipoNavio; i++)
            {
                if(tabuleiro[coordX,coordY+i] != 'A')
                {
                    Console.WriteLine("Já existe um navio nessa coordenada.");
                    return false;
                }
            }
        }
        else if(posicaoNavio == 'H')
        {
            for(int i = 0; i < tipoNavio; i++)
            {
                if(tabuleiro[coordX+i,coordY] != 'A')
                {
                    Console.WriteLine("Já existe um navio nessa coordenada.");
                    return false;
                }
            }
        }

        return true;
    }

    static void Main()
    {
        char[,] teste = new char[10,10];
        teste = PreencherTabuleiroVazio(teste);
        ImprimirTabuleiro(teste);
        PreenchePosicao(teste,5,5,3,'V');
        ImprimirTabuleiro(teste);
        PreenchePosicao(teste,0,0,5,'V');
        ImprimirTabuleiro(teste);
        PreenchePosicao(teste,2,0,4,'H');
        ImprimirTabuleiro(teste);
    }
}

