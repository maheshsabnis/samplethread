using System.Collections.Concurrent;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Dictionary Across THreads");

Dictionary<string, int> dataDict = new Dictionary<string, int>();
ConcurrentDictionary<string, int> concurrentDataDict = new ConcurrentDictionary<string, int>();
try
{

    Thread t1 = new Thread(() => putDataInDataDictionary());
    Thread t2 = new Thread(() => putDataInDataDictionary());

    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();

    Console.WriteLine($"Records in Data Dictionary {dataDict.Values.Count}");

    Thread t3 = new Thread(() => putDataInConcurrentDataDictionary());
    Thread t4 = new Thread(() => putDataInConcurrentDataDictionary());

    t3.Start();
    t4.Start();
    t3.Join();
    t4.Join();
    Console.WriteLine($"Records in Concurrent Data Dictionary {concurrentDataDict.Values.Count}");

    // Using Tasks for the same
    Console.WriteLine("Using Tasks");

    Task task1 = Task.Factory.StartNew(() => { putDataInDataDictionary(); });
    Task task2 = Task.Factory.StartNew(() => { putDataInDataDictionary(); });

    //task1.Start();
    //task2.Start();

    Task.WaitAll();
    Console.WriteLine($"Records in Data Dictionary using Tasks {dataDict.Values.Count}");

    Task task3 = Task.Factory.StartNew(() => { putDataInConcurrentDataDictionary(); });
    Task task4 = Task.Factory.StartNew(() => { putDataInConcurrentDataDictionary(); });

    //task3.Start();
    //task4.Start();

    Task.WaitAll();
    Console.WriteLine($"Records in Concurrent Data Dictionary using Tasks {concurrentDataDict.Values.Count}");



}
catch (Exception ex)
{
    Console.WriteLine($"Error Occurred {ex.Message}");
}
Console.ReadLine();


void putDataInDataDictionary()
{
    try
    {

        for (int i = 0; i <= 10; i++)
        {
            dataDict.Add(Guid.NewGuid().ToString(), i);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in Method {ex.Message}");
    }
}

void putDataInConcurrentDataDictionary()
{
    try
    {

        for (int i = 0; i <= 10; i++)
        {
            concurrentDataDict.TryAdd(Guid.NewGuid().ToString(), i);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in Method {ex.Message}");
    }
}


