using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class Survey
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["NationalParkGeek"].ToString();
        ParkDAL dal;

        public Survey()
        {
            dal = new ParkDAL(connectionString);
        }

        public int SurveyID { get; set; }

        [Required(ErrorMessage = "Please select a park")]
        public string ParkCode { get; set; }

        public int SurveyCount { get; set; }

       
        public string ParkName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please choose an activity level")]
        public string ActivityLevel { get; set; }

        public List<SelectListItem> Parks
        {
            get
            {
                List<Park> parks = dal.GetAllParks();
                List<SelectListItem> result = new List<SelectListItem>();

                SelectListItem thisItem = new SelectListItem();
                thisItem.Text = "";
                thisItem.Value = null;
                result.Add(thisItem);

                foreach (Park park in parks)
                {
                    thisItem = new SelectListItem();
                    thisItem.Text = park.ParkName;
                    thisItem.Value = park.ParkCode;

                    result.Add(thisItem);
                }

                return result;
            }
        }

        public static List<SelectListItem> States { get; } = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "", Value = null},
            new SelectListItem() { Text = "Alabama", Value = "Alabama" },
            new SelectListItem() { Text = "Alaska", Value = "Alaska" },
            new SelectListItem() { Text = "Arizona", Value = "Arizona" },
            new SelectListItem() { Text = "Arkansas", Value = "Arkansas" },
            new SelectListItem() { Text = "Califonia", Value = "Califonia" },
            new SelectListItem() { Text = "Colorado", Value = "Colorado" },
            new SelectListItem() { Text = "Connecticut" , Value = "Connecticut" },
            new SelectListItem() { Text = "Delaware", Value = "Delaware" },
            new SelectListItem() { Text = "Florida", Value = "Florida" },
            new SelectListItem() { Text = "Georgia", Value = "Georgia" },
            new SelectListItem() { Text = "Hawaii", Value = "Hawaii" },
            new SelectListItem() { Text = "Idaho", Value = "Idaho" },
            new SelectListItem() { Text = "Illinois", Value = "Illinois" },
            new SelectListItem() { Text = "Indiana", Value = "Indiana" },
            new SelectListItem() { Text = "Iowa", Value = "Iowa" },
            new SelectListItem() { Text = "Kansas", Value = "Kansas" },
            new SelectListItem() { Text = "Kentucky", Value = "Kentucky" },
            new SelectListItem() { Text = "Louisiana", Value = "Louisiana" },
            new SelectListItem() { Text = "Maine", Value = "Maine" },
            new SelectListItem() { Text = "Maryland", Value = "Maryland" },
            new SelectListItem() { Text = "Massachusetts", Value = "Massachusetts" },
            new SelectListItem() { Text = "Michigan", Value = "Michigan" },
            new SelectListItem() { Text = "Minnesota", Value = "Minnesota" },
            new SelectListItem() { Text = "Mississippi", Value = "Mississippi"},
            new SelectListItem() { Text = "Missouri", Value = "Missouri" },
            new SelectListItem() { Text = "Montana", Value = "Montana" },
            new SelectListItem() { Text = "Nebraska", Value = "Nebraska" },
            new SelectListItem() { Text = "Nevada", Value = "Nevada" },
            new SelectListItem() { Text = "New Hampshire", Value = "New Hampshire" },
            new SelectListItem() { Text = "New Jersey", Value = "New Jersey" },
            new SelectListItem() { Text = "New Mexico", Value = "New Mexico" },
            new SelectListItem() { Text = "New York", Value = "New York" },
            new SelectListItem() { Text = "North Carolina", Value = "North Carolina" },
            new SelectListItem() { Text = "North Dakota", Value = "North Dakota" },
            new SelectListItem() { Text = "Ohio", Value = "Ohio" },
            new SelectListItem() { Text = "Oklahoma", Value = "Oklahoma" },
            new SelectListItem() { Text = "Oregon", Value = "Oregon" },
            new SelectListItem() { Text = "Pennsylvania", Value = "Pennsylvania" },
            new SelectListItem() { Text = "Rhode Island", Value = "Rhode Island" },
            new SelectListItem() { Text = "South Carolina", Value = "South Carolina" },
            new SelectListItem() { Text = "South Dakota", Value = "South Dakota" },
            new SelectListItem() { Text = "Tennessee", Value = "Tennessee" },
            new SelectListItem() { Text = "Texas", Value = "Texas" },
            new SelectListItem() { Text = "Utah", Value = "Utah" },
            new SelectListItem() { Text = "Vermont", Value = "Vermont" },
            new SelectListItem() { Text = "Virginia", Value = "Virginia" },
            new SelectListItem() { Text = "Washington", Value = "Washington" },
            new SelectListItem() { Text = "West Virginia", Value = "West Virginia" },
            new SelectListItem() { Text = "Wisconsin", Value = "Wisconsin" },
            new SelectListItem() { Text = "Wyoming", Value = "Wyoming" },
        };
    }
}