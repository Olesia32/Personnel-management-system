﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GI_Project
{
    [Serializable]
    public class HumanResourcesDepartment
    {
        public string Message
        {
            get;
            set;
        }
        public string AdditionalMessage
        {
            get;
            set;
        }
    
        public void TrackingWorkEmployees(object sender, ExcessiveHoursArgument arg)
        {
            Programmer programer = sender as Programmer;
            Console.WriteLine("\n-----Відділ кадрів-----");
            Message = $"Працівник {programer.Surname} понаднормово відпрацював {arg.Parameter} годин";
            if(arg.Parameter > 25)
            {
                if (arg is ExcessiveHoursArgument) (arg as ExcessiveHoursArgument).AdditionalParameter =
                    Math.Round(programer.Salary() * 0.2, 2);
                AdditionalMessage = $"За вражаючий понаднормовий відробіток працівник {programer.Surname} отримує " +
                    $"премію в розмірі 20% від його зарплати. Розмір премії складає {arg.AdditionalParameter} UAH";
            }
            Console.WriteLine("-----------------------\n");
        }
        public void TrackingWorkLeaders(object sender, ExcessiveNumberJuniorsArgument arg)
        {
            Leader leader = sender as Leader;
            Console.WriteLine("\n-----Відділ кадрів-----");
            Message = $"Керівник {leader.Surname} тепер має на {arg.Parameter} підлеглих більше від норми";
            if (arg.Parameter >= 5)
            {
                if (arg is ExcessiveNumberJuniorsArgument) (arg as ExcessiveNumberJuniorsArgument).AdditionalParameter =
                    Math.Round(leader.Salary() * 0.2, 2);
                AdditionalMessage = $"За вражаючу кількість підлеглих керівник {leader.Surname} отримує " +
                    $"премію в розмірі 20% від його зарплати. Розмір премії складає {arg.AdditionalParameter} UAH";
            }
            Console.WriteLine("-----------------------\n");

        }
    }
}
