using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarSpairParts.Data;
using CarSpairParts.Model;

namespace CarSpairParts.Pages.Car
{
    public class DeleteModel : PageModel
    {
        private readonly CarSpairParts.Data.CarSpairPartsContext _context;

        public DeleteModel(CarSpairParts.Data.CarSpairPartsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SpairPartsModel SpairPartsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SpairPartsModel == null)
            {
                return NotFound();
            }

            var spairpartsmodel = await _context.SpairPartsModel.FirstOrDefaultAsync(m => m.Id == id);

            if (spairpartsmodel == null)
            {
                return NotFound();
            }
            else
            {
                SpairPartsModel = spairpartsmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SpairPartsModel == null)
            {
                return NotFound();
            }
            var spairpartsmodel = await _context.SpairPartsModel.FindAsync(id);

            if (spairpartsmodel != null)
            {
                SpairPartsModel = spairpartsmodel;
                _context.SpairPartsModel.Remove(SpairPartsModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
