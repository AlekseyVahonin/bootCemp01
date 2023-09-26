//Сортировка подсчетом

int[] inputArray = { 1, 0, 5, 6, 7, 8, 9, 4, 5, 4 };

void countingSortig(int[] array)
{
    int[] countArray = new int[10];

    for (int i = 0; i < array.Length; i++)// подсчет количества повторений
    {
        countArray[array[i]]++;
    }

    int index = 0;
    for (int i = 0; i < countArray.Length; i++)//перебираем массив повторений
    {
        for (int j = 0; j < countArray[i]; j++)//каждый повтор последовательно записывается в исходный массив
        {
            array[index] = i;
            index++; //перемещаем индекс исходного массива
        }
    }
}

Console.WriteLine($"[{string.Join(", ", inputArray)}]");
countingSortig(inputArray);
Console.WriteLine($"[{string.Join(", ", inputArray)}]");