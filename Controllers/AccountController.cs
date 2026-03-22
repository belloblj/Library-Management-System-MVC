using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

public class AccountController : Controller
{
    // Fake in-memory user list (no database)
    private static List<User> _users = new List<User>();

    // GET: Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Register
    [HttpPost]
    public IActionResult Register(User user)
    {
        Console.WriteLine("REGISTER POST HIT");
        Console.WriteLine("VALID? " + ModelState.IsValid);

        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine("ERROR: " + error.ErrorMessage);
        }

        if (!ModelState.IsValid)
            return View(user);

        _users.Add(user);
        return RedirectToAction("Login");
    }

    // GET: Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Invalid email or password";
            return View();
        }

        // Redirect to dashboard after successful login

        HttpContext.Session.SetString("UserName", user.FullName);
        return RedirectToAction("Dashboard", "Home");
    }
    //Logout Button
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}