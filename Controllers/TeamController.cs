using System;
using System.IO;
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

            newTeam.IdTeam = Int32.Parse(form["IdTeam"]);
            newTeam.Name = form["Name"];
            newTeam.Image = form["Image"];


            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Teams");

                if (!Directory.Exists(folder))
                {

                    Directory.CreateDirectory(folder);

                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);


                using (var stream = new FileStream(path, FileMode.Create))
                {

                    file.CopyTo(stream);

                }


                newTeam.Image = file.FileName;

            }

            else
            {

                newTeam.Image = "standard.png";

            }



            teamModel.Create(newTeam);
            ViewBag.teamsList = teamModel.ReadAll();

            return LocalRedirect("~/Team/List");

        }



        [Route("{id}")]

        public IActionResult Delete(int id)
        {

            teamModel.Delete(id);

            ViewBag.Teams = teamModel.ReadAll();

            return LocalRedirect("~/Team/List");

        }





    }
}