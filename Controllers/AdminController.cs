using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment.Models;
using System.Collections;

namespace Assignment.Controllers;

public class AdminController : Controller {
    public static UserModel um = new UserModel();

    [HttpGet]
    public ActionResult AdminOperation() {
        return View();
    }

    [HttpPost]
    public ActionResult AdminOperation(Admin ad) {
        if(ModelState.IsValid) {
            if(ad.Aemail == "deepanshu@gmail.com" && ad.Apassword == "1234") {
                return RedirectToAction("HomePage", "Admin", ad);
            }
        }
        return View();
    }

    public ActionResult HomePage(Admin ad) {
        ViewData["Admin"] = ad;
        return View();
    }

    public ActionResult ViewUser() {
        foreach (var item in um.UserList)
        {
            Console.WriteLine(item.Name);
        }
        ViewData["User"] = UserController.users.UserList;
        return View();
    }

    public ActionResult Delete(int id) {
        var str = UserController.users.UserList.Find(m=> m.id == id);
        UserController.users.UserList.Remove(str);
        return RedirectToAction("ViewUser", "Admin", UserController.users.UserList);
    }
}