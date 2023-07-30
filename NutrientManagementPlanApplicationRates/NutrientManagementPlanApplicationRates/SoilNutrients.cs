using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace NutrientManagementPlanApplicationRates
{
    public class SoilNutrients
    {
        //private DateTime _dateSampled;
        private float _pH;
        private string _fieldName;
        private float _mineralizedOM;
        private static int _phosphorus; // had to use static member variable and property to have the ability to use the _phosphorus variable for calculating the available phosphorus in the manure in the ManureNutrients class
        private float _nitrate;
        private int _potassium;
        private int _coolSeasonConversion = 10;
        private int _warmSeasonConversion = 20;
        private string _soilTestMethod;

        //public DateTime DateSampled // use inheritance or composition here....
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                if (value != null) { _fieldName = value; } //need better validation
                else { Console.WriteLine("Please enter a field name."); }                
            }
        }

        //public float Nitrate // may not be useful
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public float Ph
        {
            get { return _pH; }
            set { _pH = value; }
        }

        public static int Phosphorus 
        {
            get { return _phosphorus; }
            set { _phosphorus = value; }
        }

        public int Potassium
        {
            get { return _potassium; }
            set { _potassium = value;}
        }

        //public float SoilOrganicMatter
        //{
        //    get => default;
        //    set
        //    {
        //        if ( == "cool") { }
        //    }
        //}

        //public string SoilType
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public string SoilTestMethod
        {
            get { return _soilTestMethod; }
            set
            {
                if (value != null && value == "mehlich-iii")
                {
                    _soilTestMethod = "Mehlich-III";
                }
                else if (value != null && value == "bray-1")
                {
                    _soilTestMethod = "Bray-1";
                }
                else
                {
                    _soilTestMethod = "Olsen";
                }
            }
        }

        public void DisplaySoilTestResults()
        {
            throw new System.NotImplementedException();
        }

        public float CalculateNitrate(float nitratePpm, float depth)
        {
            _nitrate = nitratePpm * depth * 0.3f;
            return _nitrate;
        }

        public float CalculateSomMineralization(string cropSeason, float soilOrganicMatter)
        {
            if(cropSeason == "cool")
            {
                _mineralizedOM = soilOrganicMatter * _coolSeasonConversion;
            }
            else
            {
                _mineralizedOM = soilOrganicMatter * _warmSeasonConversion;
            }
            return _mineralizedOM;
        }
    }
}