using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.Assemblers;
using ContractManagementSystem.DAL.DTOs.Contract;
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
        public async Task<ContractDto> GetById(Guid id)
        {
            var contractDtos = _contractService.GetContractById(id);
            if (contractDtos == null)
                return null;

            return contractDtos;
        }

        //[HttpPost]
        //public IActionResult Add([FromBody] CreateContractDto createDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    //var contract = _mapper.Map<Contract>(createDto);


        //    //_contractService.AddContract(contract);

        //    //var contractDto = _mapper.Map<ContractDto>(contract);
        //    //return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contractDto);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(Guid id, [FromBody] UpdateContractDto updateDto)
        //{
        //    if (id != updateDto.Id)
        //        return BadRequest();

        //    var contract = _mapper.Map<Contract>(updateDto);
        //    _contractService.UpdateContract(contract);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    _contractService.DeleteContract(id);
        //    return NoContent();
        //}
    }
}
