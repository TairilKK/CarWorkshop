﻿using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Mazda Service",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "999888777",
                        }
                    };
                    mazdaAso.EncodeName();

                    await _dbContext.CarWorkshops.AddAsync(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
