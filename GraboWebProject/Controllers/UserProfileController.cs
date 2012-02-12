﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraboWebProject.Controllers
{
    public class UserProfileController : Controller
    {
        private int userId = 1;
        private GrabooDBEntities entities = new GrabooDBEntities();

        //
        // GET: /UserProfile/
        public ActionResult Index()
        {
            User targetUser = entities.Users.Where( x => x.Id == userId ).FirstOrDefault();

            return View( targetUser );
        }

        //
        // GET: /UserProfile/Edit
        public ActionResult Edit( int userId )
        {
            User targetUser = entities.Users.Where( x => x.Id == userId ).FirstOrDefault();
            return View( targetUser );
        }

        [HttpPost]
        public ActionResult Edit( User user )
        {
            User targetUser = entities.Users.Where( x => x.Id == user.Id ).FirstOrDefault();
            targetUser.FirstName = user.FirstName;
            targetUser.LastName = user.LastName;
            targetUser.Age = user.Age;
            targetUser.Gender = user.Gender;

            this.entities.ObjectStateManager.ChangeObjectState( targetUser, System.Data.EntityState.Modified );

            this.entities.SaveChanges();
            return View( targetUser );
        }

        //
        // GET: /UserProfile/EditHealthProfile
        public ActionResult HealthProfile( int userId )
        {
            User targetUser = entities.Users.Where( x => x.Id == userId ).FirstOrDefault();
            
            return View( targetUser );
        }

        [HttpPost]
        public ActionResult HealthProfile( User user )
        {
            User targetUser = entities.Users.Where( x => x.Id == userId ).FirstOrDefault();
            return View();
        }

        public ActionResult AddAllergy( int userId )
        {
            User targetUser = entities.Users.Where( x => x.Id == userId ).FirstOrDefault();

            return View( targetUser );
        }

        public ActionResult GetIngredients()
        {
            var data = from ingredient in this.entities.Ingredients
                       select new
                       {
                           Id = ingredient.Id,
                           Name = ingredient.Name,
                           Description = ingredient.Description
                       };

            return Json( data, JsonRequestBehavior.AllowGet );
        }


    }
}
