using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using static System.Console;

namespace _231117_CS_генерики
{
    class Timer
    {
        internal sealed class OperationTimer : IDisposable
        {
            long _startTime;
            string _text;
            int _collectionCount;

            public OperationTimer(string text)
            {
                PrepareForOperation();
                _text = text;
                _collectionCount = GC.CollectionCount(0);
                _startTime = Stopwatch.GetTimestamp();
            }
            public void Dispose()
            {
                WriteLine($"{_text}\t{Stopwatch.GetTimestamp() - _startTime / (double)Stopwatch.Frequency:0.00} секунды." +
                    $" Сборок мусора: {GC.CollectionCount(0) - _collectionCount} ");
            }
            private static void PrepareForOperation()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        
        }

    }
}
