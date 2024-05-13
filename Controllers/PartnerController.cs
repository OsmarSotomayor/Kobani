using Azure.Core;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Repositori;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Kobani.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController: ControllerBase
    {
        private readonly IPartnerRepository partnerRepository;
        private readonly ILogger<PartnerRepository> logger;

        public PartnerController(IPartnerRepository partnerRepository, ILogger<PartnerRepository> logger) 
        {
            this.partnerRepository = partnerRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Partner>>> getPartners()
        {
            try
            {
                logger.LogInformation("getting the partners");
                return Ok(await partnerRepository.getPartnersAsync());
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex + "An error occurred while fetching partners");
                return NotFound();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> getPartner(int id)
        {
            try{

                var partner = await partnerRepository.getPartnerByIdAsync(id);
                if(partner == null)
                {
                    logger.LogWarning("Partner was no found with id " + id);
                    return NotFound();
                }
                return Ok(partner);

            }catch(Exception ex)
            {
                logger.LogWarning(ex + "An error occurred while fetching partner with id  "+ id);
                return NotFound();
            }           
        }
       
    }
}

