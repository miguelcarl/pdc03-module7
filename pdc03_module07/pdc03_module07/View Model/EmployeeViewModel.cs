﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using pdc03_module07.Model;

using System.Threading.Tasks;

namespace pdc03_module07.View_Model
{
    public class EmployeeViewModel
    {
        //Call Database

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        //Insert Records
        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        //Retrieve Records
        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employees.ToListAsync();
            return res;
        }

        //Delete Records
        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        //Update Records
        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}
