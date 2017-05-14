//Kassandra Lopez & Zhiyuan Xue CIS 345 4:30-5:45 Project 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;


namespace Lopez_Xue_Project
{
    class Flight
    {
        Passenger[] passengerManifest = new Passenger[20];//Set up the array passengerManifest for passengers
        private int flightNo;
        private string flightOrigin;
        private string flightDestination;
        private int passengerCount;

        public int FlightNo //FlightNo property
        { 
            get
            {
                return flightNo;
            } 
            set
            {
                flightNo = value;
            }
        }
        public string FlightOrigin//FlightOrigin property
        {
            get
            {
                return flightOrigin;
            }
            set
            {
                flightOrigin = value;
            }
        }

        public string FlightDestination //FlightDestination property
        { 
            get
            {
                return flightDestination;
            }
            set
            {
                flightDestination = value;
            }
        }
        public Passenger[] PassengerManifest//PassengerManifest property
        {
            get
            {
                return passengerManifest;
            }  
            set
            {
                passengerManifest = value;
            }
        }
        public int PassengerCount//PassengerCount property
        {
            get
            {
                return passengerCount;
            }
            set
            {
                passengerCount = value;
            }
        }
        public Flight()//Flight constructor
        {
 
        }
        //Constructor that creates a flight 
        public Flight(int flightNo, string origin, string destination)
        {
            this.FlightNo = flightNo;
            this.FlightOrigin = origin;
            this.FlightDestination = destination;
        }
        
     }
 }

