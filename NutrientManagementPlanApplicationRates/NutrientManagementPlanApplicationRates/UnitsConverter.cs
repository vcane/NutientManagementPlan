using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutrient_Management_Plan_Application_Rates
{
    public class UnitsConverter
    {
        private double _ppm;
        private double _poundsPerAcre;
        private double _poundsPer1000Gal;
        private double _poundsPerAcreInch;
        private double _poundsPerTon;
        private double _percentage;
        private double _acreInches;
        private double _tons;
        private double _cubicFeet;
        private double _gallons;
        private double _elementalPhosphorus;
        private double _p2o5;
        private double _elementalPotassium;
        private double _potash;
        private double _acreFeet;

        public double PpmToPoundsPer1000Gal
        {
            get { return _poundsPer1000Gal; }
            set
            {
                if (value > 0)
                {
                    _poundsPer1000Gal = value * 0.00835;
                }
                
            }
        }

        public double PpmToPoundsPerAcreInch
        {
            get => default;
            set
            {
            }
        }

        public double PpmToPoundsPerTon
        {
            get => default;
            set
            {
            }
        }

        public double ElementalPhosToP2O5
        {
            get => default;
            set
            {
            }
        }

        public double ElementalKToPotash
        {
            get => default;
            set
            {
            }
        }

        public double PoundsPerAcreInchToPoundsPer1000Gal
        {
            get => default;
            set
            {
            }
        }

        public double PoundsPer1000GalToPoundsPerAcreInch
        {
            get => default;
            set
            {
            }
        }

        public double AcreInchToGal
        {
            get => default;
            set
            {
            }
        }

        public double GalToAcreInch
        {
            get => default;
            set
            {
            }
        }

        public double PercentageToPpm
        {
            get => default;
            set
            {
            }
        }
    }
}