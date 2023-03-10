using Google.Cloud.Spanner.Data;
using Microsoft.AspNetCore.Mvc;
using my_first_spanner_connector.entitymodel;
using my_first_spanner_connector.models;

namespace my_first_spanner_connector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpannerConnectorController : ControllerBase
    {
        string projectId = "ark-builders-coimbatore";
        string instanceId = "my-first-spanner";
        string databaseId = "my-spanner-database";
        private readonly ILogger<SpannerConnectorController> _logger;
        private readonly SampleContext appContext;

        public SpannerConnectorController(ILogger<SpannerConnectorController> logger, SampleContext _appContext)
        {
            _logger = logger;
            this.appContext = _appContext;
        }

        [HttpGet(Name = "InsertDummyData")]
        public async Task Get()
        {
            await InsertDataAsync(projectId, instanceId, databaseId);
        }

        public async Task example()
        {

            string connectionString =
                $"Data Source=projects/{projectId}/instances/{instanceId}/"
                + $"databases/{databaseId}";
            // Create connection to Cloud Spanner.
            using (var connection = new SpannerConnection(connectionString))
            {
                // Execute a simple SQL statement.
                var cmd = connection.CreateSelectCommand(
                    @"SELECT ""Hello World"" as test");
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Console.WriteLine(
                            reader.GetFieldValue<string>("test"));
                    }
                }
            }
        }

        public async Task InsertDataAsync(string projectId, string instanceId, string databaseId)
        {
            IEnumerable<student_details> studentsList = this.appContext.student_details.ToList();
            //    string connectionString = $"Data Source=projects/{projectId}/instances/{instanceId}/databases/{databaseId}";
            //    List<StudentDetails> students = new List<StudentDetails>
            //{
            //    new StudentDetails { rollnumber = 5, student_name= "Adhila", department= "Aeronautical", grade="S" },
            //    new StudentDetails { rollnumber = 6, student_name= "Yathul", department= "Mechanical", grade="A" }
            //};

            // Create connection to Cloud Spanner.
            //using var connection = new SpannerConnection(connectionString);
            //await connection.OpenAsync();

            //await connection.RunWithRetriableTransactionAsync(async transaction =>
            //{
            //    await Task.WhenAll(students.Select(student =>
            //    {
            //        // Insert rows into the Singers table.
            //        using var cmd = connection.CreateInsertCommand("student_details", new SpannerParameterCollection
            //    {
            //            { "rollnumber", SpannerDbType.Int64, student.rollnumber },
            //            { "student_name", SpannerDbType.String, student.student_name },
            //            { "department", SpannerDbType.String, student.department },
            //            { "grade", SpannerDbType.String, student.grade }
            //    });
            //        cmd.Transaction = transaction;
            //        return cmd.ExecuteNonQueryAsync();
            //    }));
            //});
            Console.WriteLine("Data inserted.");
        }
    }
}