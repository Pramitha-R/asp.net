using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarSpairParts.Data;
using CarSpairParts.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarSpairParts.Pages.Car
{
    public class IndexModel : PageModel
    {
        private readonly CarSpairParts.Data.CarSpairPartsContext _context;

        public IndexModel(CarSpairParts.Data.CarSpairPartsContext context)
        {
            _context = context;
        }

        public IList<SpairPartsModel> SpairPartsModel { get; set; } = default!;


        //for search
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }



        [BindProperty(SupportsGet = true)]
        public string? FilterMethod { get; set; }

        /*
        public SelectList? engin { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }*/

        public async Task OnGetAsync()
        {
            var parts = from m in _context.SpairPartsModel
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                parts = parts.Where(s => s.name.Contains(SearchString));
                if (!string.IsNullOrEmpty(FilterMethod))
                {
                    parts = parts.Where(s => s.engin.Contains(FilterMethod));
                        //.Where(s => s.color.Contains(FilterMethod));
                }
            }
            else if (!string.IsNullOrEmpty(FilterMethod))
            {
                parts = parts.Where(s => s.engin.Contains(FilterMethod));//.Where(s => s.color.Contains(FilterMethod)); 
            }

            SpairPartsModel = await parts.ToListAsync();
            //SpairPartsModel = await _context.SpairPartsModel.ToListAsync();

            //if (_context.SpairPartsModel != null)
            //{
            //    SpairPartsModel = await _context.SpairPartsModel.ToListAsync();
            //}
        }
    }
}
