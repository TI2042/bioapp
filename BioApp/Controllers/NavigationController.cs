using BioApp.Data;
using BioApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace BioApp.Controllers
{
    public class NavigationController : Controller
    {
        private readonly BioContext _context;
        public NavigationController (BioContext context)
        {
            _context = context;
        }


    }
}
