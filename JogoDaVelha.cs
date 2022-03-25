using System;
using System.Threading;

namespace JogoDaVelha
{
    class JogoDaVelha{
        static char[,] tabuleiro = new char[3,3];
        static String[] players = {"Jogador 1", "Jogador 2"};
        static int linhaJogada = 0;
        static int colunaJogada = 0;
        static int identificadorJogador;
        static int number1 = 0;
        static int number2 = 0;
        static int turnoJogada = 0;
        static String virgula = "";
        private static void renderizarTabuleiro(){
            Console.WriteLine("_________________________");
            for(int i = 0; i < 3; i++){
                Console.WriteLine("|   {0}   |   {1}   |   {2}   |", tabuleiro[i,0], tabuleiro[i,1], tabuleiro[i,2]);


            }
            Console.WriteLine("|_______|_______|_______|");
        }

        private static void inicializarTabuleiro(){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    tabuleiro[i,j] = ' ';
                }
            }
        }

        private static Boolean checarVitoria(){
            // Primeira linha
            if((tabuleiro[0,0] == tabuleiro[0,1] && tabuleiro[0,1] == tabuleiro[0,2]) && (tabuleiro[0,0] != ' ' && tabuleiro[0,1] != ' ' && tabuleiro[0,2] != ' ')){
                return true;
            }
            // Segunda linha
            if((tabuleiro[1,0] == tabuleiro[1,1] && tabuleiro[1,1] == tabuleiro[1,2]) && (tabuleiro[1,0] != ' ' && tabuleiro[1,1] != ' ' && tabuleiro[1,2] != ' ')){
                return true;
            }
            // Terceira linha
            if((tabuleiro[2,0] == tabuleiro[2,1] && tabuleiro[2,1] == tabuleiro[2,2]) && (tabuleiro[2,0] != ' ' && tabuleiro[2,1] != ' ' && tabuleiro[2,2] != ' ')){
                return true;
            }
            // Primeira coluna
            if((tabuleiro[0,0] == tabuleiro [1,0] && tabuleiro[1,0] == tabuleiro[2,0]) && (tabuleiro[0,0] != ' ' && tabuleiro[1,0] != ' ' && tabuleiro[2,0] != ' ')){
                return true;
            }
            // Segunda coluna
            if((tabuleiro[0,1] == tabuleiro [1,1] && tabuleiro[1,1] == tabuleiro[2,1]) && (tabuleiro[0,1] != ' ' && tabuleiro[1,1] != ' ' && tabuleiro[2,1] != ' ')){
                return true;
            }
            // Terceira coluna
            if((tabuleiro[0,2] == tabuleiro [1,2] && tabuleiro[1,2] == tabuleiro[2,2]) && (tabuleiro[0,2] != ' ' && tabuleiro[1,2] != ' ' && tabuleiro[2,2] != ' ')){
                return true;
            }
            //Diagonal ascendente
            if((tabuleiro[2,0] == tabuleiro[1,1] && tabuleiro[1,1] == tabuleiro[0,2]) && (tabuleiro[2,0] != ' ' && tabuleiro[1,1] != ' ' && tabuleiro[0,2] != ' ')){
                return true;
            }
            //Diagonal descendente
            if((tabuleiro[0,0] == tabuleiro[1,1] && tabuleiro[1,1] == tabuleiro[2,2]) && (tabuleiro[0,0] != ' ' && tabuleiro[1,1] != ' ' && tabuleiro[2,2] != ' ')){
                return true;
            }
            return false;
        }

        private static Boolean checarEmpate(){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    if(tabuleiro[i,j] ==  ' '){
                        return false;
                    }
                }
            }
            return true;
        }

        private static void coletandoJogada(){
            do{
                if(turnoJogada % 2 == 0){
                    identificadorJogador = 0;
                }
                else{
                    identificadorJogador = 1;
                }
                RefazerJogada:
                Console.WriteLine("Indique a sua jogada {0}, use o exemplo: 1,3(linha 1 coluna 3) como formato:", players[identificadorJogador]);
                String n = Console.ReadLine();
                virgula = n.Substring(1,1);
                number1 = int.Parse(n.Substring(0,1));
                number2 = int.Parse(n.Substring(2));
                if(!virgula.Equals(",") || (number1 < 1 || number1 > 3) || (number2 < 1 || number2 > 3)){
                    Console.WriteLine("Indique a sua jogada {0}, use o exemplo: 1,3(linha 1 coluna 3) como formato:", players[identificadorJogador]);
                    n = Console.ReadLine();
                    virgula = n.Substring(1,1);
                    number1 = int.Parse(n.Substring(0,1));
                    number2 = int.Parse(n.Substring(2));
                    if((number1 < 1 || number1 > 3) || (number2 < 1 || number2 > 3)){
                        goto RefazerJogada;
                    }
                    else{
                        if(tabuleiro[number1 - 1, number2 -1] == 'O' || tabuleiro[number1 - 1, number2 - 1] == 'X'){
                            Console.WriteLine("Posição já ocupada com {0}, escolha outra posição. ", tabuleiro[number1 - 1, number2 - 1]);
                            goto RefazerJogada;
                        }
                        else{
                            break;
                        }
                    }
                }
                else{
                       if(tabuleiro[number1 - 1, number2 -1] == 'O' || tabuleiro[number1 - 1, number2 - 1] == 'X'){
                            Console.WriteLine("Posição já ocupada com {0}, escolha outra posição. ", tabuleiro[number1 - 1, number2 - 1]);
                            goto RefazerJogada;
                        }
                        else{
                            break;
                        }
                }
            }
            while(!virgula.Equals(",") || (number1 < 1 || number1 > 3) || (number2 < 1 || number2 > 3));
            linhaJogada = number1 - 1;
            colunaJogada = number2 - 1;
            if(identificadorJogador == 0){
                tabuleiro[linhaJogada, colunaJogada] = 'X';
            }
            else{
                tabuleiro[linhaJogada, colunaJogada] = 'O';
            }
        }
        static void Main()
        {
            Console.WriteLine(players[0] + ": X e " + players[1] + ": O");
            Console.WriteLine("\n");
            Console.WriteLine("O {0} ira iniciar o jogo! \n", players[0]);
            inicializarTabuleiro();
            renderizarTabuleiro();
            Console.WriteLine("\n");   
            do{
                coletandoJogada();
                Console.WriteLine("\n");
                renderizarTabuleiro();
                Console.WriteLine("\n");
                if(checarVitoria()){
                    Console.Write("{0} venceu, parabens!", players[identificadorJogador]);
                    break;
                }
                else if(checarEmpate()){
                    Console.Write("O jogo terminou empatado, que pena!");
                    break;
                }
            turnoJogada++;
        }
        while(!checarVitoria());
        }
    }
}