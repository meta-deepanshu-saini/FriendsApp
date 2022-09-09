using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment.Models;
using System.Collections;

namespace Assignment.Controllers;

public class UserController : Controller {
    public static UserModel users = new UserModel();

    public ActionResult Index() {
        return View();
    }

    [HttpGet]
    public ActionResult Registration() {
        return View();
    }

    [HttpPost]
    public ActionResult Registration(User user1) {
        if(ModelState.IsValid) {
            users.addUsers(user1);
            return RedirectToAction("Login", "User");
        }
        return View();
    }

    [HttpGet]
    public ActionResult Login() {
        return View();
    }

    [HttpPost]
    public ActionResult Login(User user1) {
        var foundUser = users.findUser(user1);
       
        if(foundUser.email.Equals("")) {
            return RedirectToAction("Login", "User");
        }
        return RedirectToAction("Index", "Friend", foundUser);
    }

}