﻿using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Essentials;


namespace Pastime.Models
{
    public class EventModel
    {
        private int eventId;
        private string name;
        private User host;
        private List<User> guests;
        private Activity activity;
        private List<string> equipmentNeeded;
        private Xamarin.Essentials.Location location;
        private int maxGuests;
        private string description;
        private TimeSpan startTime;
        private DateTime endTime;
        private bool active;

        //validation methods.
        //output parameter will be the error message displayed on the UI
        public bool validateName(string name, out string errMsg)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                errMsg = "Please enter a name for the event";
                return false;

            }
            else if (name.Length > 30)
            {
                errMsg = "Please enter a name less than 30 characters long";
                return false;
            }
            else
            {
                errMsg = string.Empty;
                return true;
            }
        }

        public bool validateDesc(string desc, out string errMsg)
        {
            if (string.IsNullOrWhiteSpace(desc))
            {
                errMsg = "Please enter a description for the event";
                return false;
            }
            else if (desc.Length < 20)
            {
                errMsg = "Please enter at least 20 characters";
                return false;
            }
            else if (desc.Length > 300)
            {
                errMsg = "Description can be no more than 300 characters long";
                return false;
            }
            else
            {
                errMsg = string.Empty;
                return true;
            }
        }

        public bool validateLocationString(string loc, out string errMsg)
        {
            if (string.IsNullOrWhiteSpace(loc))
            {
                errMsg = "Location can not be empty";
                return false;
            }
            else
            {
                errMsg = string.Empty;
                return true;
            }
        }


        public bool validateSport(string sport, out string errMsg)
        {
            if (string.IsNullOrWhiteSpace(sport))
            {
                errMsg = "Please select a sport";
                return false;
            }
            else
            {
                errMsg = string.Empty;
                return true;
            }
        }

        public bool validateEventDate(DateTime eventDate, out string errMsg)
        {
            DateTime dateTime = eventDate.Date + startTime;
            if (eventDate < DateTime.Now.Add(new TimeSpan((int)0.45, 0, 0)))
            {
                errMsg = "Please choose a later time";
                return false;
            }

            errMsg = string.Empty;
            return true;
            
        }

        public Event createEvent(string name, List<string>euipment, Location location, int maxGuests, string desc, DateTime date, TimeSpan endTime )
        {
            //TODO: call all validation before creating the object
            //TODO: assign eventid to object once event is created in the database?
            Event result = new Event(name, null, null, location, maxGuests, desc, date, endTime);

            return result;
        }

    }
}
