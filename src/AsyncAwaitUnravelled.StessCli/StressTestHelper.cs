using System.Diagnostics;

public sealed class StressTestHelper
{
    public static async Task StressTestEndpoint(HttpClient client, string url, int numberOfRequests)
    {
        List<Task> tasks = new();
        Stopwatch stopwatch = new();
        stopwatch.Start();

        for (int i = 0; i < numberOfRequests; i++)
        {
            tasks.Add(SendRequestAsync(client, url));
        }

        await Task.WhenAll(tasks);

        stopwatch.Stop();
        Console.WriteLine($"Completed {numberOfRequests} requests in {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task SendRequestAsync(HttpClient client, string url)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request to {url} failed: {ex.Message}");
        }
    }
}