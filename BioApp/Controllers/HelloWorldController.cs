using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BioApp.Controllers
{
    public class HelloWorldController : Controller
    {
        //Get: /HelloWorld/
        public string Index()
        {
            return "Hello world Index!";
        }

        ////Get  /HelloWorld/Welcome
        //public string Welcome()
        //{
        //    return "Welcome stranger!";
        //}

        //Get  /HelloWorld/Welcome
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
    }
}
