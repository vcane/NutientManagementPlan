using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace NutrientManagementPlanApplicationRates
{
    public class ManureNutrients
    {
        
        private float _ammoniumNitrogen;
        private DateTime _dateSampled;
        private string _manureAppMethod;
        private string _manureType;
        private float _organicNitrogen;
        private float _pH;
        private float _phosphorus;
        private int _totalKjeldahlNitrogen;
        private float _wetPercentage;
        private float _inorganicNitrogenAvailability;
        private string _nutrientConcentrationUnit;
        private float _organicNitrogenAvailability;
        private float _plantAvailableN;
        

        public DateTime DateSampled
        {
            get
            {
                return _dateSampled;
            }
            set // need validation to ensure a date format was entered...
            {
                //Console.WriteLine(DateTime.Now - value);
                if ((DateTime.Now - value) < TimeSpan.FromDays(365)) //appears to work as of 7-10-23
                    _dateSampled = value;
                else
                    Console.WriteLine("The sample date is more than 365 days old. Please collect a new sample."); //probably should make custom exception for this and not use write line
            }
        }

        public int TotalKjeldahlNitrogen
        {
            get 
            {
                return _totalKjeldahlNitrogen; 
            }
            set
            {
                _totalKjeldahlNitrogen = value; //need validation to ensure numbers are entered
            }
        }

        public float OrganicNitrogen
        {
            get
            {
                return _organicNitrogen;
            }
            set 
            {
                // need to include a conditional for winter vs. summer crop
                // if winter multiply _organicNitrogen by 0.5
                
                
                _organicNitrogen = value * _organicNitrogenAvailability;
            }
        }

        public float AmmoniumNitrogen
        {
            get
            {
                return _ammoniumNitrogen;
            }
            set
            { 
                _ammoniumNitrogen = value * _inorganicNitrogenAvailability;
            }
        }

        public float Phosphorus
        {
            get
            {
                return _phosphorus;
            }
            set 
            {
                //var soilNutrients = new SoilNutrients(); //creates new instance so soilNutrients.Phosphorus == 0 at this point. Therefore, it will always run the first part of the conditional and multiply value * 0.5
                if (SoilNutrients.Phosphorus <= 20)
                {
                    _phosphorus = value * 0.5f;
                }
                else
                {
                    _phosphorus = value;
                }   
            }
        }

        //public float WetPercentage // may not be useful
        //{
        //    get
        //    {
        //        return _wetPercentage;
        //    }
        //    set
        //    {
        //        _wetPercentage = value;
        //    }
        //}

        public float Ph
        {
            get
            {
                return _pH;
            }
            set
            {
                _pH = value;
            }
        }

        //public void DisplayManureNutrientsTable()
        //{
        //    Console.WriteLine();
        //}

        public void ManureTypeAndApplicationMethod(string manureType, string incorporated)
        {
            if (manureType == "solid")
            {
                _nutrientConcentrationUnit = "lbs/ton";
                _organicNitrogenAvailability = 0.25f;
                //Console.Write("Will the solid manure be incorporated into the soil? ");
                //var incorporated = Console.ReadLine().ToLower();
                //if (incorporated == "yes")
                //{
                    Console.Write("Within how many days will it be incorporated? Options are: less than 1, 1, 2, 3, 4, 5, 6, or 7+. ");
                    var days = Console.ReadLine().ToLower();

                    switch (days)
                    {
                        case "less than 1":
                            _inorganicNitrogenAvailability = 0.9f;
                            break;

                        case "1":
                            _inorganicNitrogenAvailability = 0.65f;
                            break;

                        case "2":
                            _inorganicNitrogenAvailability = 0.5f;
                            break;

                        case "3":
                            _inorganicNitrogenAvailability = 0.4f;
                            break;

                        case "4":
                            _inorganicNitrogenAvailability = 0.3f;
                            break;

                        case "5":
                            _inorganicNitrogenAvailability = 0.2f;
                            break;

                        case "6":
                            _inorganicNitrogenAvailability = 0.1f;
                            break;

                        default:
                            _inorganicNitrogenAvailability = 0.05f;
                            break;
                    }
                //}
            }
            else
            {
                _nutrientConcentrationUnit = "lbs/1000 gal";
                _organicNitrogenAvailability = 0.3f;
                //Console.Write("Will the liquid be incorporated? ");
                //var incorporated = Console.ReadLine().ToLower();
                if (incorporated == "no")
                {
                    _manureAppMethod = "surface"; // conversion multiplier 0.5
                    _inorganicNitrogenAvailability = 0.5f;
                }
                else
                {
                    Console.Write("What type of incorporation will be utilized? Sweep or knife? ");
                    var incorporationType = Console.ReadLine().ToLower();
                    if (incorporationType == "sweep")
                    {
                        _manureAppMethod = "sweep"; // conversion multiplier 1.0
                        _inorganicNitrogenAvailability = 1.0f;
                    }
                    else
                    {
                        _manureAppMethod = "knife"; // conversion multiplier 0.9
                        _inorganicNitrogenAvailability = 0.9f;
                    }
                }
            }
        }

        public float CalculatePAN(float ammonium, float orgN)
        {
            _plantAvailableN = ammonium + orgN;
            return _plantAvailableN;
        }        
    }
}