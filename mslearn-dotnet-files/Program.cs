using Newtonsoft.Json; 
using System.Text;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

var salesResults = CalculateSalesTotal(salesFiles);

void GenerateSalesSummary(double total, Dictionary<string, double> details, string storesDirectory, string outputFile)
{
    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($" Total Sales: {total:C}");
    report.AppendLine();
    report.AppendLine(" Details:");

    foreach (var detail in details)
    {
        report.AppendLine($"  {Path.GetRelativePath(storesDirectory, detail.Key)}: {detail.Value:C}");
    }

    File.WriteAllText(outputFile, report.ToString());
}

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesResults.Total}{Environment.NewLine}");

GenerateSalesSummary(
    salesResults.Total,
    salesResults.Details,
    storesDirectory,
    Path.Combine(salesTotalDir, "sales-summary.txt"));

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

(double Total, Dictionary<string, double> Details) CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    Dictionary<string, double> salesDetails = new Dictionary<string, double>();
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;

        // Store the total for this individual file
        salesDetails[file] = data?.Total ?? 0;
    }
    
    return (salesTotal, salesDetails);
}

record SalesData (double Total);