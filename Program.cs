Random random = new();

int n;
do
{
    n = IntInput("Введите размерность таблицы (N): ");
    if (n < 1)
    {
        Console.WriteLine("Размерность таблицы должна быть больше 0!\n");
    }
}
while (n < 1);

int x = IntInput("Введите нижний диапазон значений элементов массива: ");

int y;
do
{
    y = IntInput("Введите верхний диапазон значений элементов массива: ");
    if (y < x)
    {
        Console.WriteLine("Верхний диапазон значений элементов массива должен быть больше нижнего!\n");
    }
}
while (y < x);

int[,] a = new int[n, n];
int[,] b = new int[n, n];

int[,] sum = new int[n, n];
int[,] subtraction = new int[n, n];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        a[i, j] = random.Next(x, y + 1);
        b[i, j] = random.Next(x, y + 1);

        sum[i, j] = a[i, j] + b[i, j];
        subtraction[i, j] = a[i, j] - b[i, j];
    }
}

Console.WriteLine("\nМатрица a:");
PrintArray(a);

Console.WriteLine("\nМатрица b:");
PrintArray(b);

Console.WriteLine("\nСложение матриц:");
PrintArray(sum);

Console.WriteLine("\nВычитание матриц:");
PrintArray(subtraction);



int IntInput(string text)
{
    int value;
    bool isCorrectnumber;

    do
    {
        Console.Write(text);
        isCorrectnumber = int.TryParse(Console.ReadLine(), out value);

        if (!isCorrectnumber)
            Console.WriteLine("Неверный формат ввода!\n");

    } while (!isCorrectnumber);

    return value;
}

void PrintArray(int[,] array)
{
    int maxNumberLength = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            maxNumberLength = Math.Max(maxNumberLength, array[i, j].ToString().Length);
        }
    }

    int width = maxNumberLength + 1;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == 0) { Console.Write("|"); }
            Console.Write("{0," + width + "} |", array[i, j]);
        }
        Console.WriteLine();
    }
}