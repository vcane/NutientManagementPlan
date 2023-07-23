using System.Globalization;
using NutrientManagementPlanApplicationRates;

Console.WriteLine("Welcome to the Nutrient Management Plan Calculator.");


// CALCULATING PLANT-AVAILABLE NUTRIENTS FROM THE MANURE

var manureNutrients = new ManureNutrients();
Console.WriteLine("Please enter information from your manure test results.");

Console.Write("Please enter the type of manure that you sampled. (Enter solid or liquid): ");
var manureType = Console.ReadLine().ToLower();

Console.Write($"Will the {manureType} manure be incorporated? (type yes or no) ");
var incorporated = Console.ReadLine().ToLower();

manureNutrients.ManureTypeAndApplicationMethod(manureType, incorporated); 

Console.Write("Please enter the date that you sampled the manure. ");

var cultureInfo = new CultureInfo("en-US");
var dateString = Console.ReadLine();
var dateSampled = DateTime.Parse(dateString);
manureNutrients.DateSampled = dateSampled;

Console.WriteLine("Please enter the pH of the manure sample. ");
manureNutrients.Ph = float.Parse(Console.ReadLine());

Console.Write("Please enter the organic nitrogen (either lbs/ton or lbs/1000gal) from the manure. ");
var orgN = float.Parse(Console.ReadLine());
manureNutrients.OrganicNitrogen = orgN;

Console.Write("Please enter the ammonium nitrogen (either lbs/ton or lbs/1000gal) from the manure. ");
var NH4 = float.Parse(Console.ReadLine());
manureNutrients.AmmoniumNitrogen = NH4;

Console.Write("Please enter the P2O5 (either lbs/ton or lbs/1000gal) from the manure. ");
var P2O5 = float.Parse(Console.ReadLine());
manureNutrients.Phosphorus = P2O5;

Console.WriteLine($"The pH of the manure same is {manureNutrients.Ph}");
Console.WriteLine($"The plant-available nitrogen from organic nitrogen is {manureNutrients.OrganicNitrogen}");
Console.WriteLine($"The plant-available nitrogen from organic nitrogen is {manureNutrients.AmmoniumNitrogen}");
Console.WriteLine($"The total plant-available nitrogen from the manure is {manureNutrients.CalculatePAN(NH4, orgN)}");
Console.WriteLine($"The plant-available nitrogen from P2O5 is {manureNutrients.Phosphorus}");

