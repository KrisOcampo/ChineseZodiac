using ChineseZodiac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ChineseZodiac.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "You must enter a year. You cannot leave this box empty")]
    [Range(1900, 2024, ErrorMessage = "You must enter a year between 1900 and next year (2024)")]
    public int Year { get; set; }
    public string Zodiac { get; set; }
    public string ZodiacImage { get; set; }
    public bool IsResultAvailable { get; set; }
    public string ErrorMessage { get; set; }


    public void OnGet()
    {
        ViewData["Year"] = 0;
    }

    
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            Zodiac = Utils.GetZodiac(Year);
            ZodiacImage = Zodiac.ToLower().Replace(" ", "_").Replace("'", "").Replace("(", "").Replace(")", "").Replace(" ", "_").Replace(".", "").Replace("-", "").Replace("&", "and").Replace("/", "_").Replace("__", "_").Replace("&amp;", "and") + ".png";
            IsResultAvailable = true;
        }
        else
        {
            IsResultAvailable = false;
            ErrorMessage = "You must enter a year between 1900 and next year (2024). Please try again.";
        }
    }

}

