using System;
using System.Reflection;

public class Game
{
    public static int tentativas = 0;
    public static int winner;
    public static string[,] matriz = new string[3, 3];
    public static string turno = "X";

    public void ImpressMatriz()
    {
        Console.Clear();
        int index = 1;
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i,j]==null) 
                {
                    matriz[i, j] = index.ToString();
                    Console.Write($"[{matriz[i, j]}]");
                    index++;
                }

                else 
                {
                    if (matriz[i, j] == "X")
                    {
                        Console.Write($"[{matriz[i, j]}]");
                        index++;
                    }

                    else if (matriz[i, j] == "O")
                    {
                        Console.Write($"[{matriz[i, j]}]");
                        index++;
                    }

                    else
                    {
                        Console.Write($"[{matriz[i, j]}]");
                        matriz[i, j] = index.ToString();
                        index++;
                    }
                }
                
                
            }
            Console.WriteLine();
        }

    }

    public bool RealizarJogada(int posicao)
    {
        int linha = (posicao - 1) / 3;
        int coluna = (posicao - 1) % 3;

        if (matriz[linha, coluna] != "X" && matriz[linha, coluna] != "O")
        {
            matriz[linha, coluna] = turno;
            return true;
        }
        else
        {
            Console.WriteLine("Essa posição já está ocupada. Pressione Enter e tente novamente.");
            Console.ReadLine();
            return false;
        }
    }

    public void VerWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2])
            {
                winner = 1;
                turno = (turno == "X") ? "O" : "X";
                Console.WriteLine($"O jogador {turno} ganhou a partida!");
                break;
            }
        }

        if (winner == 0) 
        {
            for (int j = 0; j < 3; j++)
            {
                if (matriz[0, j] == matriz[1, j] && matriz[1, j] == matriz[2, j])
                {
                    winner = 1; 
                    turno = (turno == "X") ? "O" : "X"; 
                    Console.WriteLine($"O jogador {turno} ganhou a partida!");
                    break; 
                }
            }
        }

        if (winner == 0) 
        {
            if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2])
            {
                winner = 1;
                turno = (turno == "X") ? "O" : "X";
                Console.WriteLine($"O jogador {turno} ganhou a partida!"); 
            }
        }

        if (winner == 0) 
        {
            if (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
            {
                winner = 1;
                turno = (turno == "X") ? "O" : "X";
                Console.WriteLine($"O jogador {turno} ganhou a partida!"); 
            }
        }
    }

    public static void TrocarTurno()
    {
        turno = (turno == "X") ? "O" : "X";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game jogo = new Game();

        jogo.ImpressMatriz();

        do
        {
            Console.WriteLine($"Vez do jogador {Game.turno}. Escolha uma posição:");
            int jogada;
            if (int.TryParse(Console.ReadLine(), out jogada) && jogada >= 1 && jogada <= 9)
            {
                if (jogo.RealizarJogada(jogada))
                {
                    Game.TrocarTurno();
                    Game.tentativas++;
                }
                jogo.ImpressMatriz();
                jogo.VerWinner();
            }
            else if (Game.tentativas == 9)
            {
                Console.WriteLine("Nao ha mais jogadas possiveis");
                Game.winner = 1;
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Escolha um número entre 1 e 9.");
            };




        } while (Game.winner == 0);

        Console.WriteLine("Fim do jogo.");
        Console.ReadLine();
    }
}
