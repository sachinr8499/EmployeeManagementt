﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AdminController : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: api/Admin
        public IQueryable<Admin> GetAdmins()
        {
            return db.Admins;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult GetAdmin(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.ID)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Admin
        [ResponseType(typeof(Admin))]
        public IHttpActionResult PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admins.Add(admin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = admin.ID }, admin);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult DeleteAdmin(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admins.Remove(admin);
            db.SaveChanges();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(int id)
        {
            return db.Admins.Count(e => e.ID == id) > 0;
        }
    }
}