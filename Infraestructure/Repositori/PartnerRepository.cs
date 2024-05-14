using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositori
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly KobaniContext context;
        private readonly ILogger<PartnerRepository> logger;

        public PartnerRepository(KobaniContext context, ILogger<PartnerRepository> logger ) {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Partner> getPartnerByIdAsync(int id)
        {
            try
            {
                return await context.Partners.FindAsync(id);
            }
            catch(Exception)
            {
                return null;
            }           
        }

        public async Task<IReadOnlyList<Partner>> getPartnersAsync()
        {
             return  await context.Partners.ToListAsync();            
        }
    }
}
