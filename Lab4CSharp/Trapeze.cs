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

    // Метод для виведення довжин на екран
    public void DisplayDimensions()
    {
        Console.WriteLine($"Основи: {_a}, {_b}; Висота: {_h}; Колір: {_c}");
    }

    // Метод для розрахунку периметра трапеції
    public double CalculatePerimeter()
    {
        // Для обчислення периметра необхідно знати довжини бічних сторін. 
        // Використовуємо теорему Піфагора для обчислення довжин бічних сторін, вважаючи їх рівними
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

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return _a;
                case 1: return _b;
                case 2: return _h;
                case 3: return _c;
                default: throw new IndexOutOfRangeException("Недійсний індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0: _a = value; break;
                case 1: _b = value; break;
                case 2: _h = value; break;
                default: throw new IndexOutOfRangeException("Недійсний індекс або спроба змінити значення кольору");
            }
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
        t._a *= scalar;
        t._h *= scalar;
        return t;
    }

    // Константи true і false
    public static bool operator true(Trapeze t)
    {
        return t._a > 0 && t._b > 0 && t._h > 0;
    }

    public static bool operator false(Trapeze t)
    {
        return t._a <= 0 || t._b <= 0 || t._h <= 0;
    }

    // Перетворення типу Trapeze в string
    public override string ToString()
    {
        return $"{_a},{_b},{_h},{_c}";
    }

    // Перетворення типу string в Trapeze
    public static Trapeze FromString(string str)
    {
        var parts = str.Split(',');
        if (parts.Length != 4) throw new FormatException("Рядок має бути у форматі 'a,b,h,c'");
        int a = int.Parse(parts[0]);
        int b = int.Parse(parts[1]);
        int h = int.Parse(parts[2]);
        int c = int.Parse(parts[3]);
        return new Trapeze(a, b, h, c);
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

        // Тестування індексатора
        var t = new Trapeze(5, 5, 5, 1);
        Console.WriteLine($"Трапеція: {t}");
        Console.WriteLine($"a: {t[0]}, b: {t[1]}, h: {t[2]}, колір: {t[3]}");

        // Тестування перевантаження операцій
        t++;
        Console.WriteLine($"Після ++: {t}");
        t--;
        Console.WriteLine($"Після --: {t}");
        t = t * 2;
        Console.WriteLine($"Після множення на 2: {t}");

        // Тестування перетворення типів
        string str = t.ToString();
        Console.WriteLine($"Рядкове представлення: {str}");
        var t2 = Trapeze.FromString(str);
        Console.WriteLine($"Трапеція з рядка: {t2}");

        // Тестування констант true і false
        if (t)
        {
            Console.WriteLine("Трапеція дійсна.");
        }
        else
        {
            Console.WriteLine("Трапеція недійсна.");
        }
    }
}

