using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers;

public class BlogController : Controller
{
    static List<BlogEntry> Posts = new List<BlogEntry>();
    
    public IActionResult CreatorPage(Guid id)
    {
        if (id != Guid.Empty)
        {
            BlogEntry existingEntry = Posts.FirstOrDefault(x => x.Id == id);

            return View(model: existingEntry);
        }
        return View();
    }
    
    public IActionResult Index()
    {
        return View("Index", Posts);
    }

    [HttpPost]
    public IActionResult CreatorPage(BlogEntry entry)
    {
        if (entry.Id == Guid.Empty)
        {
            BlogEntry blogEntry = new BlogEntry();
            blogEntry.Content = entry.Content;
            blogEntry.Id = Guid.NewGuid();
            Posts.Add(blogEntry);
        }
        else
        {
            BlogEntry existingEntry = Posts.FirstOrDefault(x => x.Id == entry.Id);
            existingEntry.Content = entry.Content;
        }
        
        return RedirectToAction("Index");
    }
}