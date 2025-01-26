using ContractManagementSystem.BL.BusinessLogicServices;
using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.Assemblers;
using ContractManagementSystem.DAL.DTOs.Contract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContractManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<List<ContractDto>> GetAll()
        {
            var contractDtos = _contractService.GetAllContracts();
            return contractDtos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contractDtos = _contractService.GetContractById(id);
            if (contractDtos == null)
                return NotFound("Not Found");

            return Ok(contractDtos);
        }

        [HttpPost]
        public async Task<UpsertContractDto> Add([FromBody] UpsertContractDto createDto)
        {
            try
            {
                _contractService.AddContract(createDto);
                return createDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpsertContractDto createDto)
        {

            try
            {
                _contractService.UpdateContract(id, createDto);
                return await GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                // (ustawiamy IsDeleted na true)
                _contractService.DeleteContract(id);

                // Zwracamy 200 OK
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                // Zwracamy 500 Internal Server Error z komunikatem błędu
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
