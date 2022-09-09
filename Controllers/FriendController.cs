using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment.Models;
using System.Collections;

namespace Assignment.Controllers;

public class FriendController : Controller
{

    public static User FriendUser = new User();

    public ActionResult Index(User user)
    {
        ViewData["Message"] = user;
        FriendUser = user;
        return View();
    }

    public ActionResult AddFriend()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddFriend(Friend fnd1)
    {
        if (ModelState.IsValid)
        {
            FriendUser.addFriend(fnd1);
            return RedirectToAction("ViewFriend", "Friend", FriendUser);
        }
        return View();
    }

    public ActionResult ViewFriend(User fnd)
    {
        Console.WriteLine(fnd);
        foreach (var item in fnd.FriendList)
        {
            Console.WriteLine(item.Fname);
        }
        ViewData["Message1"] = FriendUser;

        return View();
    }

    // public ActionResult Delete(int id) {
    //     var str = UserController.users.UserList.Find(m => m.id == id);
    //     UserController.users.UserList.Remove(str);
    //     return RedirectToAction("ViewFriend", "Friend");
    // }
}