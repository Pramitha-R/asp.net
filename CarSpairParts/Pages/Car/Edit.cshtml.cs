using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSpairParts.Data;
using CarSpairParts.Model;

namespace CarSpairParts.Pages.Car
{
    public class EditModel : PageModel
    {
        private readonly CarSpairParts.Data.CarSpairPartsContext _context;

        public EditModel(CarSpairParts.Data.CarSpairPartsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SpairPartsModel SpairPartsModel { get; set; } = default!;

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
            SpairPartsModel = spairpartsmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SpairPartsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpairPartsModelExists(SpairPartsModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpairPartsModelExists(int id)
        {
            return _context.SpairPartsModel.Any(e => e.Id == id);
        }
    }
}
