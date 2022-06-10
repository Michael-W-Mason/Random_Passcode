using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Random_Passcode.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode.Controllers;

public class Passcode : Controller
{

    [HttpGet("")]
    public ViewResult Home()
    {
        if (HttpContext.Session.GetInt32("num") != null)
        {
            return View("Home");
        }
        HttpContext.Session.SetInt32("num", 1);
        return View("Home");
    }

    [HttpGet("passcode")]
    public JsonResult Result()
    {
        int? num = HttpContext.Session.GetInt32("num");
        num += 1;
        HttpContext.Session.SetInt32("num", (int)num);
        Dictionary<string, string> passcode = new Dictionary<string, string> { { "passcode", GenerateRandomPasscode() }, { "num", num.ToString() } };
        return Json(passcode);
    }

    public string GenerateRandomPasscode()
    {
        string result = "";
        string pool = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random rand = new Random();
        for(int i = 0 ; i < 14; i++){
            char letter = pool[rand.Next(0, pool.Length)];
            result += letter;
        }
        return result;
    }
}