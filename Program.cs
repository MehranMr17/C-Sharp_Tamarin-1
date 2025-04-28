using System;

class ClassTamarins
{
    public static void Main()
    {
        var myClass = new ClassTamarins();
        myClass.Menu();
    }

    public void Menu()
    {
        Console.WriteLine("1-Hanoi");
        Console.WriteLine("2-Sum");
        Console.WriteLine("3-to Binary");
        Console.WriteLine("4-matris");
        Console.WriteLine("5-generate Magic Secure");
        Console.WriteLine("6-rain");
        Console.WriteLine("7-leaders");
        Console.WriteLine("8-path");
        Console.WriteLine("9-stack");
        Console.Write("What program do you want to run? ");
        var pos = Convert.ToInt32(Console.ReadLine());
        switch (pos)
        {
            case 1:
                Console.WriteLine("Enter the n: ");
                var n = Convert.ToInt32(Console.ReadLine());
                hanoi('A', 'B', 'C', n);
                break;
            case 2:
                var a = 0;
                var b = 0;
                do
                {
                    Console.WriteLine("sum number s between => first number: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("and second number: ");
                    b = Convert.ToInt32(Console.ReadLine());
                    if (b <= a)
                    {
                        Console.WriteLine("second number must be bigger then first number: ");
                    }
                } while (b <= a);

                var s = sum(a, b);
                Console.WriteLine("sum is => " + s);
                break;
            case 3:
                Console.WriteLine("Enter a number for converting to binary");
                var num = Convert.ToInt32(Console.ReadLine());

                var binary = toBinary(num);
                Console.WriteLine("result => " + binary);
                break;
            case 4:
                matris();
                break;
            case 5:
                Console.WriteLine("Enter matris size : ");
                var size = Convert.ToInt32(Console.ReadLine());
                generateMagicSecure(size);
                break;
            case 6:
                Console.Write("Enter the number of elevations: ");
                var count = Convert.ToInt32(Console.ReadLine());
                var heights = new int[count];
                Console.WriteLine("Enter the elevations:");
                for (var i = 0; i < count; i++)
                {
                    Console.Write($"Height {i + 1}: ");
                    heights[i] = Convert.ToInt32(Console.ReadLine());
                }

                var waterStored = calculateTrappedWater(heights);
                Console.WriteLine("Trapped water at each position:");
                Console.WriteLine("[ " + string.Join(", ", waterStored) + " ]");
                break;
            case 7:
                Console.Write("Enter the number of elements: ");
                var length = Convert.ToInt32(Console.ReadLine());

                var array = new int[length];
                Console.WriteLine("Enter the elements:");
                for (var i = 0; i < length; i++)
                {
                    Console.Write($"Element {i + 1}: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                findLeaders(array, length);
                break;
            case 8:
                Console.Write("Enter the size of the matrix (n): ");
                arraySize = Convert.ToInt32(Console.ReadLine());
                var matrix = new int[arraySize, arraySize];

                Console.WriteLine("Enter the elements of the matrix:");
                for (var i = 0; i < arraySize; i++)
                {
                    for (var j = 0; j < arraySize; j++)
                    {
                        Console.Write($"Element [{i},{j}]: ");
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.Write("Enter the target weight (N): ");
                var target = Convert.ToInt32(Console.ReadLine());

                findPaths(matrix, 0, 0, 0, target, new List<(int, int)>());

                Console.WriteLine($"Total valid paths: {validPaths.Count}");
                foreach (var path in validPaths)
                {
                    Console.Write("Path: ");
                    foreach (var point in path)
                    {
                        Console.Write($"({point.Item1},{point.Item2}) -> ");
                    }

                    Console.WriteLine("End");
                }

                break;
            case 9: {
                Console.WriteLine("Enter the string to reverce");
                String str = Console.ReadLine();
                Stack stack = new Stack(str.Length);
                for (int i = 0; i < str.Length; i++) {
                    stack.push(str[i]);
                }
                for (int i = 0; i < str.Length; i++) {
                    Console.Write(stack.pop());
                    
                }
                break;
            }
            default:
                Console.WriteLine("Wrong input CHOOSE AGAIN");
                Menu();
                break;
        }
    }

    private void hanoi(char A, char B, char C, int n)
    {
        if (n <= 1)
        {
            Console.WriteLine($"{A}=={n}==>{B}");
        }
        else
        {
            hanoi(A, C, B, (n - 1));
            Console.WriteLine($"{A}=={n}==>{B}");
            hanoi(B, A, C, (n - 1));
        }
    }

    private string toBinary(int number)
    {
        if (number == 0)
        {
            return "0";
        }
        else if (number == 1)
        {
            return "1";
        }
        else
        {
            return toBinary(number / 2) + (number % 2);
        }
    }

    private int sum(int start, int end)
    {
        if (start == end)
        {
            return end;
        }
        else
        {
            return start++ + sum(start, end);
        }
    }

    private void generateMagicSecure(int n)
    {
        if (n % 2 == 0)
        {
            Console.WriteLine("Number must be odd");
            return;
        }

        var magicSquare = new int[n, n];

        int i = 0, j = n / 2;
        for (var num = 1; num <= n * n; num++)
        {
            magicSquare[i, j] = num;

            var newI = (i - 1 + n) % n;
            var newJ = (j + 1) % n;


            if (magicSquare[newI, newJ] != 0)
            {
                i = (i + 1) % n;
            }
            else
            {
                i = newI;
                j = newJ;
            }
        }

        Console.WriteLine($"MagicSquare {n}×{n}:");
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
                Console.Write(magicSquare[i, j].ToString("D2") + " ");
            Console.WriteLine();
        }
    }

    private bool isSymmetric(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] != matrix[j, i])
                    return false;
            }
        }

        return true;
    }

    private bool isUpperTriangular(int[,] matrix, int n)
    {
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] != 0)
                    return false;
            }
        }

        return true;
    }

    private bool isLowerTriangular(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] != 0)
                    return false;
            }
        }

        return true;
    }

    private bool isDiagonal(int[,] matrix, int n)
    {
        return isUpperTriangular(matrix, n) && isLowerTriangular(matrix, n);
    }

    private void matris()
    {
        Console.Write("Enter the size of the matrix (n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Enter the elements of the matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Symmetric: " + isSymmetric(matrix, n));
        Console.WriteLine("Upper Triangular: " + isUpperTriangular(matrix, n));
        Console.WriteLine("Lower Triangular: " + isLowerTriangular(matrix, n));
        Console.WriteLine("Diagonal: " + isDiagonal(matrix, n));
    }


    private int[] calculateTrappedWater(int[] heights)
    {
        var n = heights.Length;
        if (n == 0) return [];

        var leftMax = new int[n];
        var rightMax = new int[n];
        var trappedWater = new int[n];

        leftMax[0] = heights[0];
        for (var i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], heights[i]);
        }

        rightMax[n - 1] = heights[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], heights[i]);
        }

        for (var i = 0; i < n; i++)
        {
            trappedWater[i] = Math.Min(leftMax[i], rightMax[i]) - heights[i];
        }

        return trappedWater;
    }

    static void findLeaders(int[] array, int n)
    {
        if (n == 0) return;

        int maxRight = array[n - 1];
        Console.WriteLine("Leaders in the array:");
        Console.Write(maxRight + " ");

        for (int i = n - 2; i >= 0; i--)
        {
            if (array[i] > maxRight)
            {
                maxRight = array[i];
                Console.Write(maxRight + " ");
            }
        }

        Console.WriteLine();
    }

    static int arraySize;
    static List<List<(int, int)>> validPaths = [];

    static void findPaths(int[,] matrix, int x, int y, int sum, int target, List<(int, int)> path)
    {
        if (x < 0 || y < 0 || x >= arraySize || y >= arraySize)
            return;

        sum += matrix[x, y];
        path.Add((x, y));

        if (x == arraySize - 1 && y == arraySize - 1)
        {
            if (sum == target)
            {
                validPaths.Add(new List<(int, int)>(path));
            }
        }
        else
        {
            findPaths(matrix, x + 1, y, sum, target, path);
            findPaths(matrix, x, y + 1, sum, target, path);
        }

        path.RemoveAt(path.Count - 1);
    }
}


class Stack
{
    private int size;
    private int index = -1;
    private char[] array;

    public Stack(int size)
    {
        this.size = size;
        array = new char[size];
    }

    public void push(char x)
    {
        if (size > index) {
            array[++index] = x;
        }
        else
        {
            Console.WriteLine("Stack overflow");
        }
    }

    public char pop()
    {
        if (index >-1)
        {
            return array[index--];
        }
        else
        {
            return ' ' ;
            Console.WriteLine("Stack underflow");
        }
    }
}