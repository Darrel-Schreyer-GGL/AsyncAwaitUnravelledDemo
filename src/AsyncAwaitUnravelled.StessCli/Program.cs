var numberOfRequests = 2000;

using var httpClient = new HttpClient();

while (true)
{
    Console.WriteLine("""
                Choose your poison:
                1. Bad
                2. Good

                Type 'exit' to quit
                """);

    var choice = Console.ReadLine()!;
    var isChoice = int.TryParse(choice, out var choiceNumber);

    if (isChoice)
    {
        var url = choiceNumber switch
        {
            1 => "http://localhost:5123/api/bad",
            2 => "http://localhost:5123/api/good",
            _ => "http://localhost:5123/api/good"
        };

        await StressTestHelper.StressTestEndpoint(httpClient, url, numberOfRequests);

    }
    else if (choice == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice");
    }
}