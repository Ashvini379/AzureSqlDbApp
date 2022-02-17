﻿using AzureSqlDbApp.Models;
using AzureSqlDbApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureSqlDbApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;

        private readonly IConfiguration _configuration;


        public CourseController(CourseService _svc, IConfiguration configuration)
        {
            _course_service = _svc;

            _configuration = configuration;
        }

        // The Index method is used to get a list of courses and return it to the view
        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses(_configuration.GetConnectionString("SQLConnection"));
            return View(_course_list);
        }
    }
}
