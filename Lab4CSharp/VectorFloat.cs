using System;

public class VectorFloat
{
    // Поля
    protected float[] FArray;
    protected uint num;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorFloat()
    {
        num = 1;
        FArray = new float[num];
        FArray[0] = 0;
        num_vec++;
    }

    public VectorFloat(uint size)
    {
        num = size;
        FArray = new float[num];
        for (int i = 0; i < num; i++)
        {
            FArray[i] = 0;
        }
        num_vec++;
    }

    public VectorFloat(uint size, float initialValue)
    {
        num = size;
        FArray = new float[num];
        for (int i = 0; i < num; i++)
        {
            FArray[i] = initialValue;
        }
        num_vec++;
    }

    // Деструктор
    ~VectorFloat()
    {
        Console.WriteLine("Об'єкт VectorFloat знищується.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i}: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                FArray[i] = float.Parse(input);
            }
        }
    }

    public void PrintElements()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i}: {FArray[i]}");
        }
    }

    public void AssignValue(float value)
    {
        for (int i = 0; i < num; i++)
        {
            FArray[i] = value;
        }
    }

    public static uint CountVectors()
    {
        return num_vec;
    }

    // Властивості
    public uint Size
    {
        get { return num; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public float this[int index]
    {
        get
        {
            if (index < 0 || index >= num)
            {
                codeError = 1;
                return 0;
            }
            return FArray[index];
        }
        set
        {
            if (index < 0 || index >= num)
            {
                codeError = 1;
            }
            else
            {
                FArray[index] = value;
            }
        }
    }

    // Перевантаження унарних операторів
    public static VectorFloat operator ++(VectorFloat v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]++;
        }
        return v;
    }

    public static VectorFloat operator --(VectorFloat v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorFloat v)
    {
        return v.Size != 0 && Array.Exists(v.FArray, element => element != 0);
    }

    public static bool operator false(VectorFloat v)
    {
        return v.Size == 0 || Array.TrueForAll(v.FArray, element => element == 0);
    }

    public static bool operator !(VectorFloat v)
    {
        return !(v);
    }

    public static VectorFloat operator ~(VectorFloat v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i] = (float)Math.Floor((double)~(int)v.FArray[i]);
        }
        return v;
    }

    // Перевантаження бінарних операторів
    public static VectorFloat operator +(VectorFloat v1, VectorFloat v2)
    {
        uint maxSize = Math.Max(v1.num, v2.num);
        VectorFloat result = new VectorFloat(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result.FArray[i] = (i < v1.num ? v1.FArray[i] : 0) + (i < v2.num ? v2.FArray[i] : 0);
        }
        return result;
    }

    public static VectorFloat operator +(VectorFloat v, float scalar)
    {
        VectorFloat result = new VectorFloat(v.num);
        for (int i = 0; i < v.num; i++)
        {
            result.FArray[i] = v.FArray[i] + scalar;
        }
        return result;
    }

    public static VectorFloat operator -(VectorFloat v1, VectorFloat v2)
    {
        uint maxSize = Math.Max(v1.num, v2.num);
        VectorFloat result = new VectorFloat(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result.FArray[i] = (i < v1.num ? v1.FArray[i] : 0) - (i < v2.num ? v2.FArray[i] : 0);
        }
        return result;
    }

    public static VectorFloat operator -(VectorFloat v, float scalar)
    {
        VectorFloat result = new VectorFloat(v.num);
        for (int i = 0; i < v.num; i++)
        {
            result.FArray[i] = v.FArray[i] - scalar;
        }
        return result;
    }

    public static VectorFloat operator *(VectorFloat v1, VectorFloat v2)
    {
        uint maxSize = Math.Max(v1.num, v2.num);
        VectorFloat result = new VectorFloat(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result.FArray[i] = (i < v1.num ? v1.FArray[i] : 0) * (i < v2.num ? v2.FArray[i] : 0);
        }
        return result;
    }

    public static VectorFloat operator *(VectorFloat v, float scalar)
    {
        VectorFloat result = new VectorFloat(v.num);
        for (int i = 0; i < v.num; i++)
        {
            result.FArray[i] = v.FArray[i] * scalar;
        }
        return result;
    }

    public static VectorFloat operator /(VectorFloat v1, VectorFloat v2)
    {
        uint maxSize = Math.Max(v1.num, v2.num);
        VectorFloat result = new VectorFloat(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result.FArray[i] = (i < v1.num ? v1.FArray[i] : 0) / (i < v2.num ? v2.FArray[i] : 1);
        }
        return result;
    }

    public static VectorFloat operator /(VectorFloat v, float scalar)
    {
        VectorFloat result = new VectorFloat(v.num);
        for (int i = 0; i < v.num; i++)
        {
            result.FArray[i] = v.FArray[i] / scalar;
        }
        return result;
    }

    public static VectorFloat operator %(VectorFloat v1, VectorFloat v2)
    {
        uint maxSize = Math.Max(v1.num, v2.num);
        VectorFloat result = new VectorFloat(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result.FArray[i] = (i < v1.num ? v1.FArray[i] : 0) % (i < v2.num ? v2.FArray[i] : 1);
        }
        return result;
    }

    public static VectorFloat operator %(VectorFloat v, float scalar)
    {
        VectorFloat result = new VectorFloat(v.num);
        for (int i = 0; i < v.num; i++)
        {
            result.FArray[i] = v.FArray[i] % scalar;
        }
        return result;
    }

    // Перевантаження операторів рівності та порівняння
    public override bool Equals(object obj)
    {
        if (obj is VectorFloat other && num == other.num)
        {
            for (int i = 0; i < num; i++)
            {
                if (FArray[i] != other.FArray[i])
                    return false;
            }
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        foreach (float f in FArray)
        {
            hash = hash * 23 + f.GetHashCode();
        }
        return hash;
    }

    public static bool operator ==(VectorFloat v1, VectorFloat v2)
    {
        return v1.Equals(v2);
    }

    public static bool operator !=(VectorFloat v1, VectorFloat v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorFloat v1, VectorFloat v2)
    {
        uint minSize = Math.Min(v1.num, v2.num);
        for (int i = 0; i < minSize; i++)
        {
            if (v1.FArray[i] <= v2.FArray[i])
                return false;
        }
        return true;
    }

    public static bool operator >=(VectorFloat v1, VectorFloat v2)
    {
        uint minSize = Math.Min(v1.num, v2.num);
        for (int i = 0; i < minSize; i++)
        {
            if (v1.FArray[i] < v2.FArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <(VectorFloat v1, VectorFloat v2)
    {
        uint minSize = Math.Min(v1.num, v2.num);
        for (int i = 0; i < minSize; i++)
        {
            if (v1.FArray[i] >= v2.FArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <=(VectorFloat v1, VectorFloat v2)
    {
        uint minSize = Math.Min(v1.num, v2.num);
        for (int i = 0; i < minSize; i++)
        {
            if (v1.FArray[i] > v2.FArray[i])
                return false;
        }
        return true;
    }
}

public class Program
{
    public static void Main()
    {
        // Приклади використання
        VectorFloat vec1 = new VectorFloat(3);
        vec1.InputElements();
        vec1.PrintElements();

        VectorFloat vec2 = new VectorFloat(3, 5.0f);
        vec2.PrintElements();

        VectorFloat vec3 = vec1 + vec2;
        vec3.PrintElements();

        vec1++;
        vec1.PrintElements();

        Console.WriteLine($"Кількість векторів: {VectorFloat.CountVectors()}");
    }
}
