using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ContractManagementSystem.DAL.DTOs.Contract;
using ContractManagementSystem.DAL.Model;

namespace ContractManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractsController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contracts = _contractService.GetAllContracts();
            var contractDtos = _mapper.Map<IEnumerable<ContractDto>>(contracts);
            return Ok(contractDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var contract = _contractService.GetContractById(id);
            if (contract == null)
                return NotFound();

            var contractDto = _mapper.Map<ContractDto>(contract);
            return Ok(contractDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateContractDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contract = _mapper.Map<Contract>(createDto);
            _contractService.AddContract(contract);

            var contractDto = _mapper.Map<ContractDto>(contract);
            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contractDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateContractDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            var contract = _mapper.Map<Contract>(updateDto);
            _contractService.UpdateContract(contract);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _contractService.DeleteContract(id);
            return NoContent();
        }
    }
}
