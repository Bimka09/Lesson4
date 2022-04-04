using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            const int count = 1000000;
            string csvString = null;
            string jsonString = null;

            Stopwatch stopWatch = new Stopwatch();

            F f = new F(1, 2, 3, 4, 5);

            stopWatch.Start();

            for (int i = 0; i < count; i++)
            {
                csvString = Serializer.SerializeFromObjectToCSV(f);
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                   ts.Hours, ts.Minutes, ts.Seconds,
                   ts.Milliseconds);

            stopWatch.Reset();
            stopWatch.Start();

            Console.WriteLine($"Сериализованная cvs строка: {csvString}");
            Console.WriteLine($"Итераций: {count}. Потрачено времени: {elapsedTime}");

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                  ts.Hours, ts.Minutes, ts.Seconds,
                  ts.Milliseconds);

            Console.WriteLine();

            Console.WriteLine($"Время затраченное на вывод в консоль: {elapsedTime}");

            Console.WriteLine();

            stopWatch.Reset();
            stopWatch.Start();

            F csvOnject = null;

            for (int i = 0; i < count; i++)
            {
                csvOnject = Serializer.DeserializeFromCSVToObject<F>(csvString);
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                  ts.Hours, ts.Minutes, ts.Seconds,
                  ts.Milliseconds);

            Console.WriteLine($"Десереализовация из cvs в объект: {csvOnject.Get()}");
            Console.WriteLine($"Итераций: {count}. Потрачено времени: {elapsedTime}");

            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < count; i++)
            {
                jsonString = JsonConvert.SerializeObject(f);
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                  ts.Hours, ts.Minutes, ts.Seconds,
                  ts.Milliseconds);

            Console.WriteLine($"Сереализованная строка: {jsonString}");
            Console.WriteLine($"Итераций: {count}. Времени потрачено: {elapsedTime}");
            Console.WriteLine();

            stopWatch.Reset();
            stopWatch.Start();

            F jsonOnject = null;

            for (int i = 0; i < count; i++)
            {
                jsonOnject = JsonConvert.DeserializeObject<F>(jsonString);
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                  ts.Hours, ts.Minutes, ts.Seconds,
                  ts.Milliseconds);

            Console.WriteLine($"Десерализованная строка из json: {jsonOnject.Get()}");
            Console.WriteLine($"Итераций: {count}. Времени потрачено: {elapsedTime}");


        }
    }
}
