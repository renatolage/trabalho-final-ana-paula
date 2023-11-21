using System;

class Program
{
    static void PreencherTabuleiroVazio(char[,] tabuleiro)
    { 
        for(int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for(int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                tabuleiro[i,j] = 'A';
            }
        }
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

    static void PreenchePosicao(char[,] tabuleiro, int coordX, int coordY, int tipoNavio, char posicaoNavio)
    {
        char[] sigla = {'S','H','C','E','P'};
        if(posicaoNavio == 'V')
        {
            for(int i = 0; i < tipoNavio; i++)
            {
                tabuleiro[coordX, coordY+i] = sigla[tipoNavio-1];
            }
        }
        else if(posicaoNavio == 'H')
        {
            for(int i = 0; i < tipoNavio; i++)
            {
                tabuleiro[coordX+i,coordY] = sigla[tipoNavio-1];
            }
        }
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
    static string GerarNickname(string nomeCompleto)
    {
        string[] nickSplit = nomeCompleto.Split(" ");
        string iniciais = "";
        for(int i = 1; i < nickSplit.Length; i++)
        {
            iniciais += nickSplit[i][0];
        }
        
        return nickSplit[0]+iniciais;
    }

    static bool ValidarJogada(char[,] tabuleiro, int coordX, int coordY)
    {
        char[] embarcacoes = {'S','H','C','E','P'};
        for(int i = 0; i < embarcacoes.Length; i++)
        {
            if(tabuleiro[coordX,coordY] == embarcacoes[i])
            {
                Console.WriteLine("Belo tiro! Acertou em cheio em uma embarcação!");
                tabuleiro[coordX,coordY] = 'T';
                return true;
            }
            
        }
        if(tabuleiro[coordX,coordY] == 'T')
        {
            Console.WriteLine("Essa embarcação já foi atingida.");
            return false;
        }
        else if(tabuleiro[coordX,coordY] == 'X')
        {
            Console.WriteLine("Tentativa inválida. Local já foi atingido.");
            return false;
        }
        else
        {
            Console.WriteLine("Boa tentativa, mas esse tiro acertou na água!");
            tabuleiro[coordX,coordY] = 'X';
            return false;
        }
    }

    static void Main()
    {
        
    }
}

