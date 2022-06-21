using Test;
List<string> testResults = new();
ServiceCollectionTest servicesTest = new();
var methods = servicesTest.GetType()
    .GetMethods()
    .Where(x =>
        x.IsPublic &&
        x.ReturnParameter.ParameterType == typeof(bool) &&
        x.Name != "Equals"
    )
    .ToArray();
foreach (var method in methods)
{
    try
    {
        object? testResult = method.Invoke(servicesTest, Array.Empty<object>());
        if (testResult is bool result)
        {
            if (result)
            {
                testResults.Add($"{method.Name} passed");
            }
            else
            {
                testResults.Add($"{method.Name} did not pass");
            }
        }
    }
    catch (Exception ex)
    {
        testResults.Add($"{method.Name} did not pass with exception {ex.GetType()}");
    }
}

Console.WriteLine("Test results");
foreach (string result in testResults)
{
    Console.WriteLine(result);
}