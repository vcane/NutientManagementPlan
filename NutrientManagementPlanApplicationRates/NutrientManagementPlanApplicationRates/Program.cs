using System.Globalization;
using NutrientManagementPlanApplicationRates;

Console.WriteLine("Welcome to the Nutrient Management Plan Calculator." + "\n");

// CALCULATING PLANT-AVAILABLE NUTRIENTS FROM THE SOIL

Console.WriteLine("===== Soil Nutrient Information =====" + "\n");

var soilNutrients = new SoilNutrients();

Console.Write("Please enter the name of the field where the soil samples were collected. ");
soilNutrients.FieldName = Console.ReadLine();

Console.Write("Please enter the soil testing method. (Mehlich-III, Bray-1, or Olsen) ");
soilNutrients.SoilTestMethod = Console.ReadLine().ToLower();

Console.Write("Please enter the pH of the soil reported in the soil analysis report. ");
soilNutrients.Ph = float.Parse(Console.ReadLine());

Console.Write("Please enter the phosphorus (ppm) reported in the soil analysis report. ");
SoilNutrients.Phosphorus = int.Parse(Console.ReadLine());

Console.Write("Please enter the nitrate (ppm) reported in the soil analysis report. ");
var nitratePpm = float.Parse(Console.ReadLine());
Console.Write("Please enter the depth of the soil sample taken for the soil nitrate analysis. ");
var depth = float.Parse(Console.ReadLine());

Console.Write("Please enter the soil organic matter percentage. ");
var somPercentage = float.Parse(Console.ReadLine());
Console.Write("Please enter the season your crop grows in. (cool vs. warm) ");
var cropSeason = Console.ReadLine().ToLower();
var mineralizedOM = soilNutrients.CalculateSomMineralization(cropSeason, somPercentage);

Console.WriteLine(" ");

Console.WriteLine($"The name of the field is {soilNutrients.FieldName}.");
Console.WriteLine($"The soil pH of the field is {soilNutrients.Ph}.");
Console.WriteLine($"The soil phosphorus concentration is {SoilNutrients.Phosphorus} ppm.");
Console.WriteLine($"The soil nitrate concentration is {soilNutrients.CalculateNitrate(nitratePpm, depth)} lbs./acre.");
Console.WriteLine($"The nitrogen concentration from mineralized soil organic matter is {mineralizedOM} lbs./acre." + "\n");


// CALCULATING PLANT-AVAILABLE NUTRIENTS FROM THE MANURE

Console.WriteLine("====== Manure Nutrient Information ======" + "\n");

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

Console.Write("Please enter the pH of the manure sample. ");
manureNutrients.Ph = float.Parse(Console.ReadLine());

Console.Write("Please enter the organic nitrogen (either lbs/ton or lbs/1000gal) from the manure. ");
manureNutrients.OrganicNitrogen = float.Parse(Console.ReadLine());
//manureNutrients.OrganicNitrogen = orgN;

Console.Write("Please enter the ammonium nitrogen (either lbs/ton or lbs/1000gal) from the manure. ");
manureNutrients.AmmoniumNitrogen = float.Parse(Console.ReadLine());
//manureNutrients.AmmoniumNitrogen = NH4;

Console.Write("Please enter the P2O5 (either lbs/ton or lbs/1000gal) from the manure. ");
manureNutrients.Phosphorus = float.Parse(Console.ReadLine());
Console.WriteLine(" ");

Console.WriteLine($"The pH of the manure same is {manureNutrients.Ph}");
Console.WriteLine($"The plant-available nitrogen from organic nitrogen is {manureNutrients.OrganicNitrogen}");
Console.WriteLine($"The plant-available nitrogen from organic nitrogen is {manureNutrients.AmmoniumNitrogen}");
Console.WriteLine($"The total plant-available nitrogen from the manure is {manureNutrients.CalculatePAN(manureNutrients.AmmoniumNitrogen, manureNutrients.OrganicNitrogen)}");
Console.WriteLine($"The plant-available phosphorus from P2O5 is {manureNutrients.Phosphorus}");


//Crop Information

Console.WriteLine("====== Crop Information ======" + "\n");

Console.Write("Please enter crop to be planted in the field. ");
var cropName = Console.ReadLine().ToLower();
Console.Write("Please enter yield goal of the crop. ");
var yieldGoal = int.Parse(Console.ReadLine());

var crop = new Crop(cropName, yieldGoal);

crop.setCropNutrients(cropName);


Console.WriteLine($"The crop P removal and crop N requirement are {crop.CropPhosphorusRemoval} {crop.CropNutrientMeasurementUnits} and {crop.CropNitrogenRequirement} {crop.CropNutrientMeasurementUnits} for {crop.CropName}.");
Console.WriteLine($"The total nitrogen requirement for {crop.CropName} is {crop.CalcTotalCropNitrogenRequirement(crop.CropNitrogenRequirement, crop.YieldGoal)} {crop.CropNutrientMeasurementUnits} for {crop.YieldGoal} {crop.YieldGoalUnit} .");
Console.WriteLine($"The total phosphorus removal for {crop.CropName} is {crop.CalcTotalCropPhosphorusRemoval(crop.CropPhosphorusRemoval, crop.YieldGoal)} {crop.CropNutrientMeasurementUnits} for {crop.YieldGoal} {crop.YieldGoalUnit}.");