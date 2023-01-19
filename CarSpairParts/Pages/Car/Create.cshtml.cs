using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarSpairParts.Data;
using CarSpairParts.Model;

namespace CarSpairParts.Pages.Car
{
    public class CreateModel : PageModel
    {
        private readonly CarSpairParts.Data.CarSpairPartsContext _context;

        public CreateModel(CarSpairParts.Data.CarSpairPartsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SpairPartsModel SpairPartsModel { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SpairPartsModel.Add(SpairPartsModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
