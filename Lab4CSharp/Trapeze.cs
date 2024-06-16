using System;

class Trapeze
{
    // Поля
    private int _a; // Довжина першої основи
    private int _b; // Довжина другої основи
    private int _h; // Висота
    private readonly int _c; // Колір (припустимо, що це просто ціле число для представлення кольору)

    // Конструктор
    public Trapeze(int a, int b, int h, int c)
    {
        _a = a;
        _b = b;
        _h = h;
        _c = c;
    }

    // Властивості для отримання і встановлення довжин
    public int A
    {
        get { return _a; }
        set { _a = value; }
    }

    public int B
    {
        get { return _b; }
        set { _b = value; }
    }

    public int H
    {
        get { return _h; }
        set { _h = value; }
    }

    // Властивість для отримання кольору
    public int C
    {
        get { return _c; }
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            if (index == 0) return _a;
            else if (index == 1) return _b;
            else if (index == 2) return _h;
            else if (index == 3) return _c;
            else throw new IndexOutOfRangeException("Неправильний індекс");
        }
        set
        {
            if (index == 0) _a = (int)value;
            else if (index == 1) _b = (int)value;
            else if (index == 2) _h = (int)value;
            else if (index == 3) throw new InvalidOperationException("Неможливо змінити значення кольору");
            else throw new IndexOutOfRangeException("Неправильний індекс");
        }
    }

    // Перевантаження операцій ++ та --
    public static Trapeze operator ++(Trapeze t)
    {
        t._a++;
        t._b++;
        return t;
    }

    public static Trapeze operator --(Trapeze t)
    {
        t._a--;
        t._b--;
        return t;
    }

    // Перевантаження операції *
    public static Trapeze operator *(Trapeze t, int scalar)
    {
        return new Trapeze(t._a * scalar, t._b * scalar, t._h * scalar, t._c);
    }

    // Перевантаження операцій true та false
    public static bool operator true(Trapeze t)
    {
        return t._a > 0 && t._b > 0 && t._h > 0;
    }

    public static bool operator false(Trapeze t)
    {
        return !(t._a > 0 && t._b > 0 && t._h > 0);
    }

    // Перетворення типу Trapeze в string
    public static implicit operator string(Trapeze t)
    {
        return $"{t._a},{t._b},{t._h},{t._c}";
    }

    // Перетворення типу string в Trapeze
    public static explicit operator Trapeze(string s)
    {
        var parts = s.Split(',');
        if (parts.Length != 4)
            throw new FormatException("Неправильний формат строки");
        
        return new Trapeze(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
    }

    // Метод для виведення довжин на екран
    public void DisplayDimensions()
    {
        Console.WriteLine($"Основи: {_a}, {_b}; Висота: {_h}; Колір: {_c}");
    }

    // Метод для розрахунку периметра трапеції
    public double CalculatePerimeter()
    {
        double sideLength = Math.Sqrt(Math.Pow((Math.Abs(_a - _b) / 2.0), 2) + Math.Pow(_h, 2));
        return _a + _b + 2 * sideLength;
    }

    // Метод для розрахунку площі трапеції
    public double CalculateArea()
    {
        return ((_a + _b) / 2.0) * _h;
    }

    // Властивість для визначення, чи є трапеція квадратом
    public bool IsSquare
    {
        get
        {
            return _a == _b && _h == _a;
        }
    }
}

class Program
{
    static void Main()
    {
        // Створення масиву трапецій
        Trapeze[] trapezes = new Trapeze[]
        {
            new Trapeze(4, 4, 4, 1),
            new Trapeze(5, 6, 7, 2),
            new Trapeze(8, 8, 8, 3),
            new Trapeze(3, 3, 3, 4)
        };

        // Виведення інформації про трапеції
        int squareCount = 0;
        foreach (var trapeze in trapezes)
        {
            trapeze.DisplayDimensions();
            Console.WriteLine($"Площа: {trapeze.CalculateArea()}");
            Console.WriteLine($"Периметр: {trapeze.CalculatePerimeter()}");
            if (trapeze.IsSquare)
            {
                Console.WriteLine("Ця трапеція є квадратом.");
                squareCount++;
            }
            else
            {
                Console.WriteLine("Ця трапеція не є квадратом.");
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Кількість квадратів: {squareCount}");

        // Перевірка роботи індексатора
        Console.WriteLine($"Трапеція 1, індекс 0: {trapezes[0][0]}"); // Повинно вивести 4

        // Перевірка роботи ++ та --
        trapezes[0]++;
        Console.WriteLine($"Після ++, Трапеція 1, основа a: {trapezes[0].A}, основа b: {trapezes[0].B}"); // Повинно вивести 5, 5
        trapezes[0]--;
        Console.WriteLine($"Після --, Трапеція 1, основа a: {trapezes[0].A}, основа b: {trapezes[0].B}"); // Повинно вивести 4, 4

        // Перевірка роботи *
        var scaledTrapeze = trapezes[0] * 2;
        Console.WriteLine($"Після множення на 2, Трапеція 1, основа a: {scaledTrapeze.A}, висота h: {scaledTrapeze.H}"); // Повинно вивести 8, 8

        // Перевірка перетворення типу
        string trapezeString = trapezes[0];
        Console.WriteLine($"Перетворення в string: {trapezeString}"); // Повинно вивести "4,4,4,1"
        Trapeze trapezeFromString = (Trapeze)"6,7,8,3";
        trapezeFromString.DisplayDimensions(); // Повинно вивести "Основи: 6, 7; Висота: 8; Колір: 3"
    }
}
