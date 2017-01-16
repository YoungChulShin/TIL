class MERCY
{
    public void Test()
    {
        string inputValue = string.Empty;
        int loopCount = 0;

        do
        {
            inputValue = Console.ReadLine();
        }
        while ((int.TryParse(inputValue, out loopCount) == false) || loopCount < 0 || loopCount > 10);

        for (int i = 1; i <= loopCount; i++)
        {
            Console.WriteLine("Hello Algospot!");
        }
    }
}