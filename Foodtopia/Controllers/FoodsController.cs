using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Context;
using Foodtopia.Common.Controllers;
using RepositoryService.Interface;

namespace Foodtopia.Controllers
{
    public class FoodsController : BaseController
    {
        private readonly DatabaseContext _context;
        private readonly IFoodRepository _foodRepository;

        public FoodsController(DatabaseContext context, IFoodRepository foodRepository)
        {
            _context = context;
            _foodRepository = foodRepository;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var dbResult = await _foodRepository.GetAllAsync();

            if (!dbResult.Success || dbResult.Data == null)
            {
                return NotFound();
            }

            return View(dbResult.Data);
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var dbResult = await _foodRepository.GetAsync(id.Value);

            if (!dbResult.Success || dbResult.Data == null)
            {
                return NotFound();
            }

            return View(dbResult.Data);
        }
    }
}
