using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutrientManagementPlanApplicationRates
{
    public class SoilNutrients
    {
        private DateTime _dateSampled;
        private float _pH;
        private string _fieldName;
        private float _soilOrganicMatter;
        private int _phosphorus;
        private float _nitrate;
        private int _potassium;

        public DateTime DateSampled
        {
            get => default;
            set
            {
            }
        }

        public string FieldName
        {
            get => default;
            set
            {
            }
        }

        public float Nitrate
        {
            get => default;
            set
            {
            }
        }

        public float Ph
        {
            get => default;
            set
            {
            }
        }

        public int Phosphorus
        {
            get => default;
            set
            {
            }
        }

        public int Potassium
        {
            get => default;
            set
            {
            }
        }

        public float SoilOrganicMatter
        {
            get => default;
            set
            {
            }
        }

        public string SoilType
        {
            get => default;
            set
            {
            }
        }

        public string SoilTestMethod
        {
            get => default;
            set
            {
            }
        }

        public void DisplaySoilTestResults()
        {
            throw new System.NotImplementedException();
        }

        public float CalculateNitrate()
        {
            throw new System.NotImplementedException();
        }

        public float CalculateSomMineralization()
        {
            throw new System.NotImplementedException();
        }
    }
}