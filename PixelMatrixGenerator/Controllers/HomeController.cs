using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PixelMatrixGenerator.Models;

namespace PixelMatrixGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel
            {
                checkBoxes = new bool[100]
            };
            return View(indexModel);
        }

        [HttpPost]
        public IActionResult Index(IndexModel indexModel)
        {
            indexModel.pixelString = ConvertToStringArray(indexModel.checkBoxes);
            return View(indexModel);
        }

        public IActionResult Result(bool[] checkBoxList)
        {
            ResultModel model = new ResultModel
            {
                pixelString = ConvertToStringArray(checkBoxList)
            };
            return View(model);
        }

        public string ConvertToStringArray(bool[] checkBoxList)
        {
            var pixelString = "";
            foreach (bool checkbox in checkBoxList)
            {
                if (checkbox)
                {
                    pixelString += "1,";
                }
                else
                {
                    pixelString += "0,";
                }              
            }

            return pixelString.TrimEnd(',');
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
