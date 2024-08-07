﻿using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ICarRentService _carRentService;
        public EmployeeController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var allEmployees = await _carRentService.GetAllEmployeesFromDb();
            return Ok(allEmployees);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _carRentService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            try
            {
                await _carRentService.InsertEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                await _carRentService.UpdateEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _carRentService.DeleteEmployee(id);
            return Ok();
        }

        //ALGOS ENDPOINTS TODO
    }
}
