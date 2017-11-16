﻿namespace CarDealer.Web.Models.Cars
{
    using CarDealer.Services.Cars.Models;
    using System.Collections.Generic;

    public class CarsByMakeModel
    {
        public string Make { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}