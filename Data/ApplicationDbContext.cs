using BackEnd_Trabajadores.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Trabajadores.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext (DbContextOptions options) : base(options) { }        
    }
}
