﻿namespace CarRental.Core.Models
{
    public class ElectricCar : Car
    {
        public string BatteryCapacity { get; set; }
        public int BatteryChargingTime { get; set; }

        public ElectricCar() { }
        public ElectricCar(int id, string brand, string model, decimal rentPrice, string batteryCapacity, int batteryChargingTime) : base(id, brand, model, rentPrice)
        {
            BatteryCapacity = batteryCapacity;
            BatteryChargingTime = batteryChargingTime;
        }
    }
}