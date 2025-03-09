using System;

class ClassTamarins {
    public static void Main() {
        var myClass = new ClassTamarins();
        myClass.Menu();
    }

    public void Menu() {
        Console.WriteLine("1-Hanoi");
        Console.WriteLine("2-Sum");
        Console.WriteLine("3-to Binary");
        Console.WriteLine("4-Hanoi");
        Console.WriteLine("5-generate Magic Secure");
        Console.WriteLine("6-Hanoi");
        Console.WriteLine("7-Hanoi");
        Console.WriteLine("8-Hanoi");
        Console.WriteLine("What program do you want to run?");
        var pos = Convert.ToInt32(Console.ReadLine());
        switch (pos)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            default:
                Console.WriteLine("Wrong input CHOOSE AGAIN");
                Menu();
                break;
                
        }
    }

    public void hanoi(char A, char B, char C, int n) {
        if (n <= 1) {
            Console.WriteLine($"{A}=={n}==>{B}");
        } else {
            hanoi(A,C,B, (n - 1));
            Console.WriteLine($"{A}=={n}==>{B}");
            hanoi(B,A,C, (n - 1));
        }
    }
    
    public string toBinary(int number) {
        if (number == 0) {
            return "0";
        }else if (number == 1) {
            return "1";
        }else
        {
            return toBinary(number / 2) + (number % 2);
        }
    }
    
    public int sum(int start, int end) {
        if (start == end) {
            return end;
        } else {
            return start++ + sum(start,end);
        }
    }

    public void generateMagicSecure(int n) {
        if (n % 2 == 0) {
            Console.WriteLine("Number must be odd");
            return;
        }

        var magicSquare = new int[n, n];

        int i = 0, j = n / 2;
        for (var num = 1; num <= n * n; num++) {
            magicSquare[i, j] = num;

            var newI = (i - 1 + n) % n;
            var newJ = (j + 1) % n;


            if (magicSquare[newI, newJ] != 0) {
                i = (i + 1) % n;
            } else {
                i = newI;
                j = newJ;
            }
        }
        
        Console.WriteLine($"MagicSquare {n}×{n}:");
        for (i = 0; i < n; i++) {
            for ( j = 0; j < n; j++)
                Console.Write(magicSquare[i, j].ToString("D2") + " ");
            Console.WriteLine();
        }
    }
    
    

}