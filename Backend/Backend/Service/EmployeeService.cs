using Backend.Models;
using Backend.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Service
{
    public class EmployeeService
    {
        private readonly MaindbContext _context;

        public EmployeeService(MaindbContext context)
        {
            _context = context;
        }

        public async Task<EpEmployee?> GetEmployee(string employee_id)
        {
            try
            {
                return await _context.EpEmployees.FirstOrDefaultAsync(e => e.EmployeeId == employee_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employee: {ex.Message}");

                throw;
            }
        }

        public async Task<bool> AddEmployee(EpEmployee employee)
        {
            try
            {
                employee.PasswordHash = HashPassword(employee.PasswordHash);
                employee.EmployeeId = GenerateEmployeeId();
                employee.PositionId = 1;
                employee.Timestamp = DateTime.Now;
                employee.LastLogin = DateTime.Now;
                employee.IsDelete = false;

                await _context.EpEmployees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employee: {ex.Message}");

                return false;
            }

            return true;
        }

        public string GenerateEmployeeId()
        {
            string newId;
            var lastEmployee = _context.EpEmployees
                .OrderByDescending(e => e.EmployeeId)
                .FirstOrDefault();

            string yearMonth = DateTime.Today.ToString("yyyyMM"); // e.g., 202504

            if (lastEmployee == null || string.IsNullOrEmpty(lastEmployee.EmployeeId))
            {
                newId = $"{yearMonth}0001";
            }
            else
            {
                string lastId = lastEmployee.EmployeeId;

                // Check if the last ID is from the same year & month
                if (lastId.StartsWith(yearMonth))
                {
                    int lastNumber = int.Parse(lastId.Substring(6));
                    newId = $"{yearMonth}{(lastNumber + 1).ToString("D4")}";
                }
                else
                {
                    newId = $"{yearMonth}0001";
                }
            }

            return newId;
        }


        public string HashPassword(string plainPassword)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null, plainPassword);
        }
    }
}
