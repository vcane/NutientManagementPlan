using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutrientManagementPlanApplicationRates
{
    public class CropInfo
    {
        public DateTime Year
        {
            get => default;
            set
            {
            }
        }

        public string CropName
        {
            get => default;
            set
            {
            }
        }

        public string YieldGoalUnit
        {
            get => default;
            set
            {
            }
        }

        public int YieldGoal
        {
            get => default;
            set
            {
            }
        }

        public float CropPhosphorusRemoval
        {
            get => default;
            set
            {
            }
        }

        public float CropNitrogenRequirement
        {
            get => default;
            set
            {
            }
        }

        public string CropType
        {
            get => default;
            set
            {
            }
        }

        public int PreviousCropAdjustment
        {
            get => default;
            set
            {
            }
        }

        public string CropSeason
        {
            get => default;
            set
            {
            }
        }

        public int TypicalYieldGoal
        {
            get => default;
            set
            {
            }
        }

        public int CropPotassiumRequirement
        {
            get => default;
            set
            {
            }
        }

        public DateTime CropRotationYears(DateTime year)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayCropInfo()
        {
            throw new System.NotImplementedException();
        }

        public float CalcTotalCropNitrogenRequirement(float cropNitrogenRequirement, float cropYieldGoal)
        {
            throw new System.NotImplementedException();
        }

        public float CalcTotalCropPhosphorusRemoval(float cropPhosphorusRemoval, float cropYieldGoal)
        {
            throw new System.NotImplementedException();
        }

        public float CalcTotalCropPotassiumRequirement(float cropYieldGoal, float cropPotassiumRequirement)
        {
            throw new System.NotImplementedException();
        }
    }
}