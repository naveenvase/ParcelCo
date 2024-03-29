﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ParcelCo.Parcel.ServiceContracts;
using ParcelCo.Parcel.ModelContracts;
using ParcelCo.Parcel.Resources.Input;
using ParcelCo.Parcel.Constants.UserInput;
using ParcelCo.Parcel.Exceptions;

namespace ConsoleParcelApp
{
    /// <inheritdoc/>
    public class App : IApp
    {
        private readonly IParcel parcelService = null;
        private readonly ILogger applicationlogger = null;
        private readonly IParcelType parcelType = null;
        private IEnumerable<IParcelType> parcelTypes = null;

        /// <summary>Initializes a new instance of the <see cref="App"/> class.</summary>
        /// <param name="ResourceFileLocation">The resource file location.</param>
        /// <param name="parcelService">The parcel service.</param>
        /// <param name="parcelType">Type of the parcel.</param>
        /// <param name="logger">The logger.</param>
        public App(string ResourceFileLocation, IParcel parcelService, IParcelType parcelType, ILogger<App> logger)
        {
            this.parcelService = parcelService;
            this.applicationlogger = logger;
            this.parcelType = parcelType;
            this.parcelTypes = parcelType.ReadFromFile(ResourceFileLocation);
        }

        ///<inheritdoc/>
        public void Run()
        {
            try
            {
                GetInputFromConsole(Resource.ResourceManager.GetString(nameof(Constants.LengthEntry)), out float length);
                GetInputFromConsole(Resource.ResourceManager.GetString(nameof(Constants.BreathEntry)), out float breath);
                GetInputFromConsole(Resource.ResourceManager.GetString(nameof(Constants.HeightEntry)), out float height);
                GetInputFromConsole(Resource.ResourceManager.GetString(nameof(Constants.WeightEntry)), out float weight);
                
                var res = parcelService.Calculate(parcelTypes, length, breath, height, weight);
                
                Console.WriteLine(Resource.ResourceManager.GetString(nameof(Constants.RecommendedPackage)), res.Type, res.Cost);
            }
            
            catch (SolutionNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                applicationlogger.LogCritical(e.Message);
            }
            

        }

        /// <summary>Gets the input from console.</summary>
        /// <param name="msg">The error message to display.</param>
        /// <param name="input">The input.</param>
        private void GetInputFromConsole(string msg, out float input)
        {
            string consoleInputValue = null;
            bool tempResult = false;
            do
            {
                Console.WriteLine(msg);
                consoleInputValue = Console.ReadLine();
                tempResult = float.TryParse(consoleInputValue, out input);
            }
            while (!tempResult || (tempResult && input <=0));
        }

    }

}
