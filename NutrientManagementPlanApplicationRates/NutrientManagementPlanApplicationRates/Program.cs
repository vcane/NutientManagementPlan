using System.Globalization;
using NutrientManagementPlanApplicationRates;

Console.WriteLine("Welcome to the Nutrient Management Plan Calculator.");

var manureNutrients = new ManureNutrients();
Console.WriteLine("Please enter information from your manure test results.");

Console.Write("Please enter the type of manure that you sampled. (Enter solid or liquid): ");
var manureType = Console.ReadLine().ToLower();
manureNutrients.ManureType = manureType;

Console.Write("Please enter the date that you sampled the manure. ");

var cultureInfo = new CultureInfo("en-US");
var dateString = Console.ReadLine();
var dateSampled = DateTime.Parse(dateString);
manureNutrients.DateSampled = dateSampled;

// ADD MANUREAPPTYPE HERE