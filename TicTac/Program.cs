using System;

namespace Krestiki
{
    class game
    {
        /// Ячейки для крестиков и ноликов (игровое поле).
        static char[,] field = new char[3, 3]
        {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        };

        /// Символ текущего игрока.
        private static char player = 'X';

        static void ShowError(string ErrorMessage)
        {
            Console.WriteLine(ErrorMessage);
        }

        /// Эта функция сообщает игроку о выиграше.
        /// Она так же ждёт нажатия клавиши и очищает экран после этого.
        /// В функцию передается символ игрока который победил.
        static void Win(char player)
        {
            Console.WriteLine($"You [{player}] win");
            Console.WriteLine("press any key");
            Console.ReadKey();
            Console.Clear();
        }
        
         
        
        //задаем ничью 
        
        static void Game ()
        {
            Console.WriteLine("Tie");
            Console.WriteLine("press any key");
            Console.ReadKey();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            int x, y;
            // Главный игровой цикл.
            while (true)
            {
                // ===== НАЧАЛО ХОДА =====
                
                // Считываем координаты хода текущего игрока.

                // Считываем координату X
                Console.Write("\n Enter line number: [0, 2] ");
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    ShowError("wrong");
                    continue;
                }

                if (x == -1) break;


                // Считываем координату Y
                Console.Write("\n Enter column number: [0, 2] ");
                if (!int.TryParse(Console.ReadLine(), out y))
                {
                    ShowError("wrong");
                    continue;
                }

                if (y == -1) break;

                // Делаем ход текущим игроком.
                Update(x, y);

                // Показываем поле снова после хода игрока.
                ShowField();

                // Проверяем победу для текущего игрока.
                if (Winner('X'))
                {
                    // Текущий игрок победил, пишем о победе и очищаем поле.
                    Win('X');
                    continue;
                }
                
                
                if (Winner('0'))
                {
                    // Текущий игрок победил, пишем о победе и очищаем поле.
                    Win('0');
                    continue;
                }
                else
                {
                    Game();
                }

                if (player == '0')
                {
                    player = 'X';
                }
                else 
                {
                    player ='0';
                }
                
                
                // ===== КОНЕЦ ХОДА =====
                
                
            }
        }

        /// Эта функция показывает игровое поле в консоле. Она не меняет игровое поле.
        static void ShowField()
        {
            // Т.к. поле маленькое мы можем просто перечислить все ячейки по координатам.
            Console.WriteLine($" {field[0, 0]} | {field[0, 1]} | {field[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {field[1, 0]} | {field[1, 1]} | {field[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {field[2, 0]} | {field[2, 1]} | {field[2, 2]} ");
            Console.WriteLine(".");
        }

        /// Эта функция проверяет победил ли игрок. Функция вернет true  если игрок победил и false если нет.
        /// Значек игрока для проверки передается в функцию.
        /// Чтобы проверить победу для двух игроков необходимо вызвать функцию для кажлого игрока отдельно.
        static bool Winner(char player1)
        {
            // Эта функция проверяет координаты по столбикам, диагонали и колонкам.
            // Обычно здесь бы был цикл, но мы можем перечислить ячейки по координатам т.к. поле маленькое.
            return (
                // Rows
                (field[0, 0] == player1 && field[0, 1] == player1 && field[0, 2] == player1) ||
                (field[1, 0] == player1 && field[1, 1] == player1 && field[1, 2] == player1) ||
                (field[2, 0] == player1 && field[2, 1] == player1 && field[2, 2] == player1) ||
                // Columns
                (field[0, 0] == player1 && field[1, 0] == player1 && field[2, 0] == player1) ||
                (field[0, 1] == player1 && field[1, 1] == player1 && field[2, 1] == player1) ||
                (field[0, 2] == player1 && field[1, 2] == player1 && field[2, 2] == player1) ||
                // Diagonals
                (field[0, 0] == player1 && field[1, 1] == player1 && field[2, 2] == player1) ||
                (field[0, 2] == player1 && field[1, 1] == player1 && field[2, 0] == player1)
            );
        }
        
        
        /// Эта функция проверяет ничью. 
        /// Значек игрока для проверки передается в функцию.
        /// Чтобы проверить победу для двух игроков необходимо вызвать функцию для кажлого игрока отдельно.
        static bool Tie()
        {
            // Эта функция проверяет координаты по столбикам, диагонали и колонкам.
            // Обычно здесь бы был цикл, но мы можем перечислить ячейки по координатам т.к. поле маленькое.
            return ( (field[0, 0] != ' ' && field[0, 1] != ' ' && field[0, 2] != ' ') &&
                     (field[1, 0] != ' ' && field[1, 1] != ' ' && field[1, 2] != ' ') &&
                     (field[2, 0] != ' ' && field[2, 1] != ' ' && field[2, 2] != ' ')
                );
        }
               
            
        

        /// Функция ставит символ текущего игрока по заданным координатам.
        /// Она меняет игровое поле но не проверяет условие победы. 
        static void Update(int x, int y)
        {
            if ((0 <= x && x <= 2) &&
                (0 <= y && y <= 2))
            {
                if (field[x, y] == ' ')
                {
                    field[x, y] = player;
                }
                else
                {
                    ShowError("A move has already been made along these coordinates.");
                }
                
                
            }
        }
    }
}