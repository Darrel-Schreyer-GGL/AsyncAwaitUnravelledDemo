var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/api/bad", () =>
{
    var result = AsyncHelpers.GetStringAsync(0).Result;
    return result;
});

app.MapGet("/api/good", async () =>
{
    return await AsyncHelpers.GetStringAsync(1);
});

#region Bad
app.MapGet("/api/exception", () =>
{
    try
    {
        var result = AsyncHelpers.GetException().Result;
        return result;
    }
    catch (Exception ex)
    {
        return $"Exception {ex.Message}";
    }
});
#endregion

app.Run();

public static class AsyncHelpers
{
    public static async Task<string> GetStringAsync(int i)
    {
        await Task.Delay(10000); // Increase the delay to 10 seconds
        return await Task.FromResult($"Value {i}");
    }

    public static async Task<string> GetException()
    {
        try
        {
            return await GetExceptionLevel2();
        }
        catch
        {
            throw;
        }
    }

    public static async Task<string> GetExceptionLevel2()
    {
        throw new Exception("This is the important part.");
    }
}
