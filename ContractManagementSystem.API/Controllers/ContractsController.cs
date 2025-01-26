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

        //[HttpGet("{id}")]
        //public IActionResult GetById(Guid id)
        //{
        //    var contract = _contractService.GetContractById(id);
        //    if (contract == null)
        //        return NotFound();

        //    //var contractDto = _mapper.Map<ContractDto>(contract);
        //    return Ok(contract);//contractDto
        //}

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
