using System;

public class FloatMatrix
{
    private float[,] FMArray;  // масив елементів матриці
    private uint n, m;         // розміри матриці
    private int codeError;     // код помилки
    private static int num_mf; // кількість матриць

    // Конструктор без параметрів
    public FloatMatrix()
    {
        n = 1;
        m = 1;
        FMArray = new float[n, m];
        FMArray[0, 0] = 0.0f;
        codeError = 0;
        num_mf++;
    }

    // Конструктор з параметрами - розмір матриці
    public FloatMatrix(uint rows, uint cols)
    {
        n = rows;
        m = cols;
        FMArray = new float[n, m];
        codeError = 0;
        num_mf++;
    }

    // Конструктор з параметрами - розмір матриці та значення ініціалізації
    public FloatMatrix(uint rows, uint cols, float initValue)
    {
        n = rows;
        m = cols;
        FMArray = new float[n, m];
        for (uint i = 0; i < n; i++)
        {
            for (uint j = 0; j < m; j++)
            {
                FMArray[i, j] = initValue;
            }
        }
        codeError = 0;
        num_mf++;
    }

    // Деструктор
    ~FloatMatrix()
    {
        Console.WriteLine("Об'єкт матриці знищено");
    }

    // Властивість для отримання розміру матриці (тільки для читання)
    public uint Rows
    {
        get { return n; }
    }

    public uint Columns
    {
        get { return m; }
    }

    // Властивість для отримання і встановлення коду помилки
    public int ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Метод для введення елементів матриці з клавіатури
    public void InputMatrix()
    {
        Console.WriteLine($"Введіть елементи матриці розміром {n}x{m}:");
        for (uint i = 0; i < n; i++)
        {
            for (uint j = 0; j < m; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                FMArray[i, j] = float.Parse(Console.ReadLine());
            }
        }
    }

    // Метод для виведення елементів матриці на екран
    public void DisplayMatrix()
    {
        Console.WriteLine("Елементи матриці:");
        for (uint i = 0; i < n; i++)
        {
            for (uint j = 0; j < m; j++)
            {
                Console.Write($"{FMArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    // Статичний метод для отримання кількості матриць
    public static int GetNumberOfMatrices()
    {
        return num_mf;
    }

    // Індексатор для доступу до елементів матриці з двома індексами
    public float this[uint rowIndex, uint colIndex]
    {
        get
        {
            if (rowIndex < n && colIndex < m)
                return FMArray[rowIndex, colIndex];
            else
            {
                codeError = -1;
                return 0.0f;
            }
        }
        set
        {
            if (rowIndex < n && colIndex < m)
                FMArray[rowIndex, colIndex] = value;
            else
                codeError = -1;
        }
    }

    // Перевантаження унарного оператора ++
    public static FloatMatrix operator ++(FloatMatrix matrix)
    {
        for (uint i = 0; i < matrix.n; i++)
        {
            for (uint j = 0; j < matrix.m; j++)
            {
                matrix.FMArray[i, j]++;
            }
        }
        return matrix;
    }

    // Перевантаження бінарних операторів +
    public static FloatMatrix operator +(FloatMatrix matrix1, FloatMatrix matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            Console.WriteLine("Розміри матриць не співпадають. Повертаю першу матрицю.");
            return matrix1;
        }

        FloatMatrix result = new FloatMatrix(matrix1.n, matrix1.m);
        for (uint i = 0; i < matrix1.n; i++)
        {
            for (uint j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    // Інші бінарні оператори та перевантаження можуть бути додані аналогічно

    // Оператор рівності (перевантаження ==)
    public static bool operator ==(FloatMatrix matrix1, FloatMatrix matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (uint i = 0; i < matrix1.n; i++)
        {
            for (uint j = 0; j < matrix1.m; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                    return false;
            }
        }
        return true;
    }

    // Оператор нерівності (перевантаження !=)
    public static bool operator !=(FloatMatrix matrix1, FloatMatrix matrix2)
    {
        return !(matrix1 == matrix2);
    }

    // Інші перевантажені оператори порівняння можуть бути додані аналогічно

    // Перевантаження методу ToString() для виводу матриці у вигляді рядка
    public override string ToString()
    {
        string result = "";
        for (uint i = 0; i < n; i++)
        {
            for (uint j = 0; j < m; j++)
            {
                result += $"{FMArray[i, j]} ";
            }
            result += "\n";
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання класу FloatMatrix
        FloatMatrix matrix1 = new FloatMatrix(2, 3); // створення матриці 2x3
        matrix1.InputMatrix(); // введення елементів матриці
        Console.WriteLine("Матриця 1:");
        matrix1.DisplayMatrix(); // виведення матриці на екран

        FloatMatrix matrix2 = new FloatMatrix(2, 3); // створення другої матриці 2x3
        matrix2.InputMatrix(); // введення елементів другої матриці
        Console.WriteLine("Матриця 2:");
        matrix2.DisplayMatrix(); // виведення другої матриці на екран

        // Перевантажені оператори
        FloatMatrix sumMatrix = matrix1 + matrix2;
        Console.WriteLine("Сума матриць:");
        Console.WriteLine(sumMatrix);

        // Інші операції, такі як ++, ==, !=, можуть бути використані подібно

        // Приклад використання статичного методу для підрахунку кількості матриць
        Console.WriteLine($"Кількість створених матриць: {FloatMatrix.GetNumberOfMatrices()}");

        // Затримка консолі
        Console.ReadLine();
    }
}
