﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTokenSystem.Models
{
    public class CCTokenInitializer : DropCreateDatabaseIfModelChanges<CCTokenSystemContext>
    {

        //seed mehtod is used to insert data into table while it created
        protected override void Seed(CCTokenSystemContext context)
        {
            var student = new List<Student>{
                new Student{
                    StudentID=300718283,
                    Firstname="Sri",
                    Lastname="Chatala",
                    Phoneno="6477866026",
                    Course="Software Engineering Technology",
                    Email="schatala@my.centennialcollege.ca"
                },
                new Student{
                    StudentID=300718284,
                    Firstname="Alagu",
                    Lastname="Murugappan",
                    Phoneno="6477866325",
                    Course="Software Engineering Technology",
                    Email="malagu@my.centennialcollege.ca"
                },
                  new Student{
                    StudentID=300718285,
                    Firstname="Vangli",
                    Lastname="Rajan",
                    Phoneno="6477866363",
                    Course="Software Engineering Technology",
                    Email="rvangli@my.centennialcollege.ca"
                }
            };
            foreach (var item in student)
            {
                context.Students.Add(item);
            }
            context.SaveChanges();

            var campus = new List<Campus>
            {
                new Campus
                {
                    CampusId=1,
                    CampusName="Progress Campus",
                    CampusAddress="941 Progress Avenue",
                    City="Toronto",
                    Province="Ontario",
                    PostalCode="M1B3X7",
                    Phone="6474057686"
                },
                new Campus
                {
                    CampusId=2,
                    CampusName=" Morningside Campus",
                    CampusAddress="940 Progress Avenue",
                    City="Toronto",
                    Province="Ontario",
                    PostalCode="M1T7R3",
                    Phone="4165674587"
                }
            };
                foreach (var item in campus)
                {
                    context.Campuses.Add(item);
                }
            context.SaveChanges();
        }
    }
}
