using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NutrientManagementPlanApplicationRates
{
    //make a class called crop rotation that will make a list of crop objects
    public class Crop
    {
        private int _year;
        private string _cropName;
        private string _yieldGoalUnit;
        private int _yieldGoal;
        private float _cropPhosphorusRemoval;
        private float _cropNitrogenRequirement;
        private string _cropType;
        private int _previousCropAdjustment;
        private string _cropSeason;
        private string _cropNutrientMeasurementUnits;
        private float _totalCropNitrogenRequirement;
        private float _totalCropPhosphorusRemoval;

        public Crop(string cropName, int yieldGoal)
        {
            this._cropName = cropName;
            this._yieldGoal = yieldGoal;
            if (cropName == "corn silage" || cropName == "alfalfa")
            {
                this._yieldGoalUnit = "tons/ac";
            }
            else
            {
                this._yieldGoalUnit = "bu/ac";
            }
        }
        public int Year
        {
            get { return _year; }
            set {_year = DateTime.Now.Year;}
        }

        public string CropName
        {
            get { return _cropName; }
            set { _cropName = value; }
        }

        public string YieldGoalUnit
        {
            get { return _yieldGoalUnit; }
            set { _yieldGoalUnit = value;}
        }

        public int YieldGoal
        {
            get { return _yieldGoal; }
            set { _yieldGoal = value;}
        }

        public float CropNitrogenRequirement
        {
            get { return _cropNitrogenRequirement; }
            set { _cropNitrogenRequirement = value; }
        }

        public float CropPhosphorusRemoval
        {
            get { return _cropPhosphorusRemoval; }
            set { _cropPhosphorusRemoval = value; }
        }

        public string CropType
        {
            get { return _cropType; }
            set
            {
                if (_cropName == "soybeans" || _cropName == "alfalfa")
                {
                    _cropType = "legume";
                }
                else
                {
                    _cropType = "non-legume;";
                }

            }
        }

        public int PreviousCropAdjustment
        {
            get => default;
            set
            {
                if(_cropType == "legume" && _cropName == "soybeans")
                {
                    _previousCropAdjustment = 30;
                }
                else if (_cropType == "legume" && _cropName == "alfalfa")
                {
                    _previousCropAdjustment = 100;
                }
                else
                {
                    _previousCropAdjustment = 0;
                }
            }
        }

        public string CropSeason
        {
            get { return _cropSeason; }
            set
            {
                if (_cropName == "corn" || _cropName == "corn silage" || _cropName == "alfalfa" || _cropName == "soybeans")
                {
                    _cropSeason = "warm";
                }
                else
                {
                    _cropSeason = "cool";
                }
            }
        }

        //public int TypicalYieldGoal
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        //public int CropPotassiumRequirement
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public string CropNutrientMeasurementUnits
        {
            get { return _cropNutrientMeasurementUnits; }
            set { _cropNutrientMeasurementUnits = value; }
        }

        public int CropRotationYears(int year)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayCropInfo()
        {
            throw new System.NotImplementedException();
        }

        public float CalcTotalCropNitrogenRequirement(float _cropNitrogenRequirement, float _cropYieldGoal)
        {
            _totalCropNitrogenRequirement = _cropNitrogenRequirement * _cropYieldGoal;
            return _totalCropNitrogenRequirement;
        }

        public float CalcTotalCropPhosphorusRemoval(float _cropPhosphorusRemoval, float _cropYieldGoal)
        {
            _totalCropPhosphorusRemoval = _cropPhosphorusRemoval * _cropYieldGoal;
            return _totalCropPhosphorusRemoval;
        }

        public (float _cropPhosphorusRemoval, float _cropNitrogenRequirement, string _cropNutrientMeasurementUnits) setCropNutrients(string cropName)
        {
            switch (cropName)
            {
                case "alfalfa":
                    _cropPhosphorusRemoval = 12.0f;
                    _cropNitrogenRequirement = 8.0f; //look this up in NUP
                    break;
                case "corn":
                    _cropPhosphorusRemoval = 0.33f;
                    _cropNitrogenRequirement = 1.6f;
                    break;
                case "corn silage":
                    _cropPhosphorusRemoval = 3.2f;
                    _cropNitrogenRequirement = 10.67f;
                    break;
                case "soybeans":
                    _cropPhosphorusRemoval = 0.8f;
                    _cropNitrogenRequirement = 8.0f; //look this up in NUP
                    break;
                case "wheat":
                    _cropPhosphorusRemoval = 0.5f;
                    _cropNitrogenRequirement = 2.4f;
                    break;
                default:
                    _cropPhosphorusRemoval = 0;
                    _cropNitrogenRequirement = 0;
                    break;
            }
            if (cropName == "alfalfa" || cropName == "corn silage")
            {
                _cropNutrientMeasurementUnits = "lbs/ton";
            }
            else
            {
                _cropNutrientMeasurementUnits = "lbs/bu";
            }
            return (_cropPhosphorusRemoval, _cropNitrogenRequirement, _cropNutrientMeasurementUnits);
        }

        //public float CalcTotalCropPotassiumRequirement(float cropYieldGoal, float cropPotassiumRequirement)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public List<CropInfo> CropRotation(int _year, string _cropName, string _cropType, string _cropSeason, int _yieldGoal, string _yieldGoalUnit, float _cropPhosphorusRemoval, float _cropNitrogenRequirement, int _previousCropAdjustment)
        //{
        //    var cropInfo = new List<CropInfo>();
        //    var year = _year;
        //    for (var i = 0; i < 5; i++)
        //    {
        //        cropInfo.Add(_year);
        //    }
        //    return cropInfo;
        //}
    }
}