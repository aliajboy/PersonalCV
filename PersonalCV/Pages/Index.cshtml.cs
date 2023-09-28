using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalCV.Data.Interfaces;
using PersonalCV.Domain.Models;

namespace PersonalCV.Pages;
public class IndexModel : PageModel
{
    public ContactMessage Message { get; set; } = null!;
    public string PageMessage { get; set; } = "";

    private readonly IContactMessage _contactMessage;

    public IndexModel(IContactMessage contactMessage)
    {
        _contactMessage = contactMessage;
    }

    public async Task<ContentResult> OnPostSendMessageAsync([FromForm] ContactMessage message)
    {
        if (!ModelState.IsValid)
        {
           return Content("خطا");
        }

        await _contactMessage.Add(message);

       return Content("پیام شما با موفقیت ارسال شد");
    }
}