using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberAnimalSpecies { get; set; }
    }
}