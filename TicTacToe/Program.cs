using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {

        static int[,] tablero = new int[3, 3];
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {

            dibujarTablero();
            Console.WriteLine($"Jugador 1 = O\nJugador 2 = X");

            bool terminado = false;
            do
            {

                //Inicia el jugador 1
                preguntarPosicion(1);
                dibujarTablero();
                terminado = comprobarGanador();

                if (terminado)
                {
                    Console.WriteLine($"¡El jugador 1 a ha ganado!");

                }//Fin IF
                else { 
                    terminado = comprobarEmpate();
                    if (terminado)
                    {
                        Console.WriteLine($"¡Esto es un empate!");

                    }//Fin IF
                    else
                    {
                        preguntarPosicion(2);
                        dibujarTablero();
                        terminado = comprobarGanador();

                        terminado = comprobarGanador();

                        if (terminado)
                        {
                            Console.WriteLine($"¡El jugador 2 a ha ganado!");

                        }//Fin IF
                        else {
                            terminado = comprobarEmpate();
                            if (terminado)
                            {
                                Console.WriteLine($"¡Esto es un empate!");

                            }//Fin IF

                        }//Fin ELSE

                    }//Fin ELSE
                }//Fin ELSE
                

            }
            while (terminado == false);

        }//Fin MAIN

        static void dibujarTablero()
        {

            int fila = 0;
            int columna = 0;

            Console.WriteLine();
            Console.WriteLine($"-------------");
            for (fila = 0; fila < 3; fila++)
            {
                Console.Write($"|");
                for (columna = 0; columna < 3; columna++)
                {
                    Console.Write($" {simbolo[tablero[fila,columna]]} |");

                }//Fin FOR

                Console.WriteLine($"");
                Console.WriteLine($"-------------");

            }//Fin FOR


        }//Fin DIBUJAR_TABLERO

        static void preguntarPosicion(int jugador) {

            int fila, columna;

            do
            {
                Console.WriteLine($"");
                Console.WriteLine($"Turno del jugador: {jugador}");

                do
                {
                    Console.WriteLine($"Selecciona la fila:");
                    fila = Convert.ToInt32( Console.ReadLine() );

                }
                while (fila<1 || fila>3);

                do
                {
                    Console.WriteLine($"Selecciona la columna:");
                    columna = Convert.ToInt32( Console.ReadLine() );
                }
                while (columna<1 || columna>3);

                if (tablero[fila-1, columna-1] != 0)
                {
                    Console.WriteLine($"!Casilla ocupada!");
                }//Fin IF

            }
            while (tablero[fila-1, columna-1] !=0);

            tablero[fila - 1, columna - 1] = jugador;

        }//Fin PREGUNTAR_POSICION

        static bool comprobarGanador() {

            int fila = 0;
            int columna = 0;
            bool ganador = false;

            for (fila = 0; fila < 3; fila++)
            {

                if ( (tablero[fila, 0] == tablero[fila, 1]) &&
                     (tablero[fila, 0] == tablero[fila, 2]) &&
                     (tablero[fila,0] !=0) )
                {
                    ganador=true;
                }//Fin IF

            }//Fin FOR verificar filas


            for (columna = 0; columna < 3; columna++)
            {

                if ( (tablero[0, columna] == tablero[1, columna]) &&
                     (tablero[0, columna] == tablero[2, columna]) &&
                     (tablero[0, columna] !=0) )
                {
                    ganador = true;
                    
                }//Fin IF

            }//Fin FOR verifiacr columnas

            if ( (tablero[0,0] == tablero[1,1]) &&
                 (tablero[0,0] == tablero[2,2]) &&
                 (tablero[0,0] != 0) )
            {
                ganador = true;

            }//Fin IF verificar diagonal \

            if ( (tablero[0,2] == tablero[1,1]) &&
                 (tablero[0,2] == tablero[2,0]) &&
                 (tablero[0,2] != 0) )
            {
                ganador = true;

            }//Fin IF verificar diagonal /

            return ganador;
        }//Fin COMPROBAR_GANADOR

        static bool comprobarEmpate() {

            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for (fila = 0; fila < 3; fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {

                    if (tablero[fila, columna] ==0)
                    {
                        //Si hay una casilla vacia NO HAY ganador
                        hayEspacio = true;
                    }//Fin IF

                }//Fin FOR COLUMNAS

            }//Fin FOR FILAS

            return !hayEspacio;

        }//Fin COMPROBAR_EMPATE

    }//Fin CLASS
}
