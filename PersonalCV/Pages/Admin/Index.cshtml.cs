using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalCV.Data.Interfaces;
using PersonalCV.Domain.Models;

namespace PersonalCV.Pages.Admin;

public class IndexModel : PageModel
{
    public List<ContactMessage> ContactMessage { get; set; } = new List<ContactMessage>();
    private readonly IContactMessage _contactMessage;

    public IndexModel(IContactMessage contactMessage)
    {
        _contactMessage = contactMessage;
    }

    public async Task<PageResult> OnGetAsync()
    {
        ContactMessage = await _contactMessage.GetAll();
        return Page();
    }
}