﻿using CCTokenSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CCTokenSystem.Controllers
{
    public class DepartmentController : ApiController
    {
        CCTokenSystemContext dbcontext = new CCTokenSystemContext();

        [HttpGet]
        public IEnumerable<Department> GetAllDepartment()
         {
            var department = dbcontext.Departments.AsEnumerable<Department>();
            if(department == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return department;
        }
        [HttpGet]
        public HttpResponseMessage GetbyDepartmentID([FromUri]int CampusID)
        {
            // var department = dbcontext.Departments.Where(sid => sid.campus_Id == CampusID);
            var department = from c in dbcontext.Departments where c.campus_Id.Equals(CampusID) select c;
            if (department == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, department);

            response.StatusCode = HttpStatusCode.Created;

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }
        [HttpGet]
        public Department GetStudentByID(int Id)
        {
            Department department = dbcontext.Departments.Find(Id);

            if (department == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return department;
        }

        [HttpPut]
        public HttpResponseMessage UpdateDepartment(Department department)
        {
            if (department != null)
            {
                dbcontext.Entry(department).State = EntityState.Modified;
            }

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, department);

            response.StatusCode = HttpStatusCode.Created;

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

        [HttpPost]
        public HttpResponseMessage CreateDepartment(Department department)
        {
            var checkName = dbcontext.Departments.Where(d_name => d_name.dept_name == department.dept_name).Any();
            if (!checkName)
            {
                dbcontext.Departments.Add(department);
                try
                {
                    dbcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, department);

                response.StatusCode = HttpStatusCode.Created;

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return response;
            }
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            return res;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteDepartment(int Id)
        {
            Department department = dbcontext.Departments.Find(Id);

            if (department == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            dbcontext.Departments.Remove(department);

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
