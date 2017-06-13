using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MeanShiftAlg
{
    public class MeanShift
    {
        public void Run()
        {
            // Create the MATLAB instance 
            MLApp.MLApp matlab = new MLApp.MLApp();

            // Change to the directory where the function is located 
            var fullPath = @"C:\Users\dawid\Documents\Visual Studio 2017\Projects\MeanShift\MeanShiftAlg\MeanShiftAlg\MatlabFiles";
            matlab.Execute(String.Format("addpath('{0}')", fullPath));

            // Define the output 
            object result = null;

            // Call the MATLAB function myfunc
            matlab.Feval("sourceCODE", 1, out result, "101085.jpg", 8.0, 7.0, 0.25);

            // Display result 
            object[] res = result as object[];



            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
            Console.ReadLine();
        }
    }
}
