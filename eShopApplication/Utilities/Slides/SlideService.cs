using eShopData.EF;
using eShopData.Entities;
using eShopViewModels.Utilities.Slides;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopApplication.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly EShopDBContext _context;
        public SlideService(EShopDBContext context)
        {
            _context = context;
        }
        public async Task<List<SlideViewModel>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();
            return slides;
        }
    }
}
