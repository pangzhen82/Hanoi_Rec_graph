namespace Hanoi_Recursion_Pic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hanoi_Prog();

            Console.ReadKey();
        }

        static void Hanoi_Prog()
        {
            int height;
            height = GetHeight();
            int[,] matrix = Initial_Matrix(height);
            //PrintPole(matrix, height);
            PrintPolePicture(matrix, height);
            Hanoi(height, 1, 3, 2, height, matrix);

        }
        static int GetHeight()
        {
            bool isValid;
            int height;
        getHeight:
            Console.Write("Enter a height for the Hanoi tower: ");
            isValid = int.TryParse(Console.ReadLine(), out height);
            if (!isValid || height < 1)
            {
                Console.WriteLine("\nError! Enter a valid integer!\n");
                goto getHeight;
            }
            return height;
        }
        static int[,] Initial_Matrix(int height)
        {
            int[,] matrix = new int[3, height];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == 0)
                        matrix[i, j] = height - j;
                    else
                        matrix[i, j] = -1;
                }
            }
            return matrix;
        }
        static int MoveDisk(int[,] matrix, int from, int to, int height)
        {
            int moveDisk = -1;

            for (int i = height - 1; i >= 0; i--)
            {
                if (matrix[from - 1, i] != -1)
                {
                    moveDisk = matrix[from - 1, i];
                    matrix[from - 1, i] = -1;
                    break;
                }
            }
            for (int i = 0; i < height; i++)
            {
                if (matrix[to - 1, i] == -1)
                {
                    matrix[to - 1, i] = moveDisk;
                    break;
                }
            }
            return moveDisk;
        }
        static void PrintPole(int[,] matrix, int height)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Pole {(char)('A' + i)}");
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i, j] != -1)
                        Console.Write($"{matrix[i, j]} ");
                    else
                        break;
                }
                Console.WriteLine();
            }
        }
        static void PrintSpace(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");
        }
        static void PrintStar(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write("*");
        }
        static void PrintDottedLine(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write("-"); 
        }
        static void PrintPoleRow(int height)
        {
            PrintSpace(height);
            Console.Write('|');
            PrintSpace(height);
            Console.Write("  ");
        }
        static void PrintPolePicture(int[,] matrix, int height)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)  // print top pole
            {
                PrintPoleRow(height);
            }
            Console.WriteLine();

            for (int j = height - 1; j >= 0; j--) // Print actually pic of each pole
            {
                for(int i = 0; i < 3; i++)
                {
                    if(matrix[i, j] == -1)
                    {
                        PrintPoleRow(height);
                    }
                    else
                    {
                        PrintSpace(height - matrix[i, j] + 1);
                        PrintStar(matrix[i, j] * 2 - 1);
                        PrintSpace(height - matrix[i, j] + 1);
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 3; i++)               // print the line below plates
            {
                PrintDottedLine(height * 2 + 1);
                Console.Write("  ");
            }
            Console.WriteLine();

            for (int i = 0; i < 3; i++)    // Print the pole name
            {
                PrintSpace(height);
                Console.Write((char)('A' + i));
                PrintSpace(height);
                Console.Write("  ");
            }
            Console.WriteLine("\n");
        }
        static void Hanoi(int n, int a, int b, int c, int height, int[,] matrix)
        {
            int moveDisk;
            if (n == 0) return;
            Hanoi(n - 1, a, c, b, height, matrix);
            moveDisk = MoveDisk(matrix, a, b, height);
            PrintPolePicture(matrix, height);
            Console.WriteLine($"Move disk {moveDisk} from {(char)(a + 64)} to {(char)(b + 64)}");
            Hanoi(n - 1, c, b, a, height, matrix);
        }
    }
}
