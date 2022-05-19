using Microsoft.Data.SqlClient;
using DbUp;
using DotNetEnv;
using Polly;

Env.Load();
var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

var csb = new SqlConnectionStringBuilder(connectionString);
Console.WriteLine($"Deploying database: {csb.InitialCatalog}");

Console.WriteLine("Testing connection...");
var policy = Policy.Handle<SqlException>()
    .WaitAndRetry(3, retryAttmpt =>
        TimeSpan.FromSeconds(Math.Pow(2, retryAttmpt)));

policy.Execute(() => {
    var conn = new SqlConnection(csb.ToString());
    conn.Open();
    conn.Close();
});

Console.WriteLine("Starting deployment...");
var dbUp = DeployChanges.To
    .SqlDatabase(csb.ConnectionString)
    .WithScriptsFromFileSystem("../SQL")
    .JournalToSqlTable("dbo", "$__dbup_journal")
    .LogToConsole()
    .Build();

var result = dbUp.PerformUpgrade();

if (!result.Successful)
{
    Console.WriteLine(result.Error);
    return -1;
}

Console.WriteLine("Success");
return 0;
