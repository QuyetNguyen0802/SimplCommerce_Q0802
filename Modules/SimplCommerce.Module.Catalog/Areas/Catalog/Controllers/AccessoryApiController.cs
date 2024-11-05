using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    //[Authorize(Roles = "Admin, User")]
    [Area("Catalog")]
    [Route("api/accessories")]
    [ApiController]
    public class AccessoryApiController : ControllerBase
    {
        private readonly IRepository<Accessory> _accessoryRepository;
        private readonly IAccessoryService _accessoryService;
        private readonly IMapper _mapper;

        public AccessoryApiController(IRepository<Accessory> accessoryRepository, IAccessoryService accessoryService, IMapper mapper)
        {
            _accessoryRepository = accessoryRepository;
            _accessoryService = accessoryService;
            _mapper = mapper;
        }

        [HttpGet("GetWithOffsetPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            var pagedAccessories = await _accessoryService.GetWithOffsetPagination(pageNumber, pageSize);

            //var pagedAccessoriesDto = _mapper.Map<AccessoryResultDto>(pagedAccessories);

            //return new JsonResult(pagedAccessories);
            return Ok(pagedAccessories);
        }

        [HttpGet("GetWithKeysetPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWithKeysetPagination(int reference, int pageSize)
        {
            if (pageSize <= 0)
                return BadRequest($"{nameof(pageSize)} size must be greater than 0.");

            var pagedAccessories = await _accessoryService.GetWithKeysetPagination(reference, pageSize);

            //var pagedProductsDto = _mapper.Map<PagedResponseKeysetDto<ProductResultDto>>(pagedProducts);

            return Ok(pagedAccessories);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var data = _accessoryService.GetAll();


            return new JsonResult(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _accessoryRepository.Query().FirstOrDefaultAsync(p => p.Id == id);

            return new JsonResult(data);
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(Accessory model)
        {
            if (ModelState.IsValid)
            {
                var accessory = new Accessory
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    BrandId = model.BrandId,
                    Price = model.Price,
                    OldPrice = model.OldPrice,
                    SpecialPrice = model.SpecialPrice,
                    SpecialPriceEnd = model.SpecialPriceEnd,
                    SpecialPriceStart = model.SpecialPriceStart,
                    IsCallForPricing = model.IsCallForPricing,
                    ImgName = model.ImgName,
                    Description = model.Description,
                    ReviewsCount = model.ReviewsCount,
                };
                _accessoryService.Create(accessory);
                return CreatedAtAction(nameof(Get), new { id = accessory.Id }, null);
            }

            return BadRequest(ModelState);
        }

    }
}
