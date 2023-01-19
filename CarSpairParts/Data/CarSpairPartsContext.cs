using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarSpairParts.Model;

namespace CarSpairParts.Data
{
    public class CarSpairPartsContext : DbContext
    {
        public CarSpairPartsContext(DbContextOptions<CarSpairPartsContext> options)
            : base(options)
        {
        }

        public DbSet<CarSpairParts.Model.SpairPartsModel> SpairPartsModel { get; set; } = default!;
    }
}
