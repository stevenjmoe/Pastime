﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;


namespace Pastime.Models
{
    public class EventModel
    {
        private int eventId;
        private string name;
        private User host;
        private List<User> guests;
        private List<string> equipmentNeeded;
        private Xamarin.Essentials.Location location;
        private int maxGuests;
        private string description;
        private TimeSpan startTime;
        private DateTime endTime;
        private bool active;
        private List<Activity> activities;

        public EventModel()
        {
            //TODO: Should eventually retrieve this from the database so it is more dynamic
            activities = new List<Activity>();

            InitializeActivityList();
        }

        private void InitializeActivityList()
        {
            Activity soccer = new Activity("Soccer");
            Activity hockey = new Activity("Hockey");
            Activity basketball = new Activity("Basketball");

            AddToActivitiesList(soccer);
            AddToActivitiesList(hockey);
            AddToActivitiesList(basketball);
        }


        public List<Activity> GetActivities()
        {
            List<Activity> result = new List<Activity>();
            foreach (Activity activity in activities)
            {
                result.Add(activity);
            }
            return result;
        }

        public void AddToActivitiesList(Activity activity)
        {
            activities.Add(activity);
        }

        //validation methods.
        //output parameter will be the error message displayed on the UI
        public bool ValidateName(string name, out string errMsg)
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

        public bool ValidateDesc(string desc, out string errMsg)
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

        public bool ValidateLocationString(string loc, out string errMsg)
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


        public bool ValidateSport(string sport, out string errMsg)
        {
            if (string.IsNullOrWhiteSpace(sport))
            {
                errMsg = "Please select a sport " + sport;

                return false;
            }
            else
            {
                errMsg = string.Empty;
                return true;
            }
        }

        public bool ValidateEventDate(DateTime eventDate, TimeSpan endTime, out string errMsg)
        {
            if (eventDate < DateTime.Now.Add(new TimeSpan((int)0.45, 0, 0)))
            {
                errMsg = "Please choose a later start time";
                return false;
            }
            else if (eventDate.TimeOfDay > endTime)
            {
                errMsg = "Please choose a later end time";
                return false;
            }

            errMsg = string.Empty;
            return true;
        }



        public Event CreateEvent(string name, Activity activity,
            ObservableCollection<string> equipment, Location location,
            int maxGuests, string desc, DateTime date, DateTime endTime)
        {
            //TODO: Validate before create event maybe
            //TODO: assign eventid to object once event is created in the database?
            Event result = new Event(name, null, activity, equipment,
                location, maxGuests, desc, date, endTime);


            Console.WriteLine("Event name: " + result.Name +
                "Activity: " + result.Activity.Name + "equipment: " +
                result.EquipmentNeeded + " Location: " + result.Location.Longitude +
                result.Location.Latitude + " Max guests: " + result.MaxGuests +
                " Description: " + result.Description + " Date: " + result.StartTime +
                " End time: " + result.EndTime);
            return result;
        }

    }
}