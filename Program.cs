int IntInput(string text)
{
    int value;
    bool isCorrectnumber;

    do
    {
        Console.Write(text);
        isCorrectnumber = int.TryParse(Console.ReadLine(), out value);

        if (!isCorrectnumber)
        {
            Console.WriteLine("Неверный формат ввода!\n");
        }
    } while (!isCorrectnumber);

    return value;
}

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


// Заполнение матрицы a случайными числами
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        a[i, j] = random.Next(x, y);
    }
}

// Заполнение матрицы b случайными числами
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        b[i, j] = random.Next(x, y);
    }
}

// Сложение матриц a и b
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        sum[i, j] = a[i, j] + b[i, j];
    }
}

// Определение максимальной длины числа в матрице sum
int maxNumber = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        maxNumber = Math.Max(maxNumber, Math.Abs(sum[i, j]));
    }
}
int width;
if (x < 0)
    width = maxNumber.ToString().Length + 2;
else
    width = maxNumber.ToString().Length + 1;

// Вывод матрицы sum
Console.WriteLine();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write("{0," + -width + "}", sum[i, j]);
    }
    Console.WriteLine();
}