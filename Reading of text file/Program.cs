/*
This is the main class of our program.
The program always starts in this class.
From here every other class is called upon, once needed.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A312a_Recommender_System;

namespace A312a_Recommender_System
{
    class Program
    {
        static void Main(string[] args)
        {
            ChoseAFunction WhatFunction = new ChoseAFunction();
            WhatFunction.ChoseFunction();  
        }   
    }
}
