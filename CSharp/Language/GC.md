## GC 속도 테스트
```c#
internal sealed class OperationTimer : IDisposable
{
    private Stopwatch mStopwatch;
    private string mText;
    private int mCollectionCount;

    public OperationTimer(string text)
    {
        PrepareForOperation();

        mText = text;
        mCollectionCount = GC.CollectionCount(0);
        mStopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        Console.WriteLine("{0} (GCs={1,3}) {2}", (mStopwatch.Elapsed), GC.CollectionCount(0) - mCollectionCount, mText); 
    }

    private static void PrepareForOperation()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}
```