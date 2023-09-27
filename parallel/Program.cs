//Синхронизация в сортировке подсчетом

const int THREADS_NUMBER = 4;//число потоков
const int N = 10000;//размер массива

object locker = new object();

Random rnd = new Random();
int[] resSerial = new int[N].Select(r => rnd.Next(0, 5)).ToArray();
int[] resParallel = new int[N];
Array.Copy(resSerial, resParallel, N);

CountingSortExtended(resSerial);
parallel(resParallel);

// Console.WriteLine($"[{string.Join(", ", resSerial)}]");
// Console.WriteLine($"[{string.Join(", ", resParallel)}]");

Console.WriteLine(EqualityMatrix(resSerial, resParallel));

void parallel(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];

    int eachThread = N / THREADS_NUMBER;
    var threadsParallel = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThread;//начало треда
        int endPos = (i + 1) * eachThread;//конец треда

        if (i == THREADS_NUMBER - 1) endPos = N;//докидываем излишки в поток

        threadsParallel.Add(new Thread(() => countigSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParallel[i].Start();
    }
    foreach (var thread in threadsParallel)
    {
        thread.Join();
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

void countigSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (locker)
        {
            counters[inputArray[i] + offset]++;
        }
    }
}

void CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;

    for (int i = 0; i < N; i++) //N константа размер массива
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }

    return res;
}