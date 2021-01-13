using System;
using E_Players_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_Application.Controllers
{

    [Route("Team")]

    public class TeamController : Controller
    {
        
        Team teamModel = new Team();


        [Route("List")]
        public IActionResult Index()
        {

            ViewBag.teamsList = teamModel.ReadAll();

            return View();
        
        }


        [Route("Register")]
        public IActionResult Register(IFormCollection form)
        {

            Team newTeam = new Team();

            newTeam.IdTeam = Int32.Parse( form["IdTeam"]);
            newTeam.Name = form["Name"];
            newTeam.Image = form["Image"];

            teamModel.Create(newTeam);
            ViewBag.teamsList = teamModel.ReadAll();

            return LocalRedirect("~/Team/List");

        }

    }
}