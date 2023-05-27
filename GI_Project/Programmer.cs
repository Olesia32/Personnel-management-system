using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Project
{
    [Serializable]
    public class Programmer : Employee
    {
        public delegate void ExcessiveHoursEvent(object sender, ExcessiveHoursArgument arg);
        public event ExcessiveHoursEvent ExcessiveHours;
        private double hours_worked;
        private double premium;
        public Programmer() : base() { hours_worked = 0.0; }
        public Programmer(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour,
            double _hours_worked) : base(_surname, _experience, _wage_per_hour, _minimum_amount_hour)
        {
            hours_worked = _hours_worked;
        }
        public Programmer(Employee _employee, double _hours_worked) : base(_employee.Surname, _employee.Experience,
            _employee.Wage_per_hour, _employee.Minimum_amount_hour)
        {
            hours_worked = _hours_worked;
        }
        public override string ToString()
        {
            return $"-{base.ToString()}; {hours_worked};";
        }
        public double HoursWorked
        {
            get { return hours_worked; }
            set
            {
                hours_worked = value;
                if (hours_worked > Minimum_amount_hour)
                {
                    OnExcessiveHours(hours_worked - Minimum_amount_hour);
                }
            }
        }
        public override double Salary()
        {
            double salary = Wage_per_hour * hours_worked;
            if (hours_worked < Minimum_amount_hour)
            {
                salary -= salary * 0.25;
            }
            if (premium != 0.0)
            {
                salary += premium;
            }
            return salary;
        }
        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введіть кількість насправді відпрацьованих годин за тиждень: ");
            hours_worked = Double.Parse(Console.ReadLine());
        }
        public void OnExcessiveHours(double param)
        {
            if (ExcessiveHours != null)
            {
                ExcessiveHoursArgument arg = new ExcessiveHoursArgument(param);
                ExcessiveHours(this, arg);
                if (arg.Message != string.Empty)
                {
                    Console.WriteLine($"Працівник {this.Surname} отримав повідомлення від свого керівника: '{arg.Message}'");
                }
                if (arg.AdditionalParameter != 0.0)
                {
                    premium = arg.AdditionalParameter;
                    Console.WriteLine($"Тепер запрлата працівника становить {Salary()} UAH");
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Programmer otherProgrammer = (Programmer)obj;
            if (!base.Equals(obj))
            {
                return false;
            }
            return hours_worked == otherProgrammer.hours_worked;
        }
        public static bool operator ==(Programmer programmer1, Programmer programmer2)
        {
            if (ReferenceEquals(programmer1, programmer2))
            {
                return true;
            }

            if (ReferenceEquals(programmer1, null) || ReferenceEquals(programmer2, null))
            {
                return false;
            }

            return programmer1.Equals(programmer2);
        }
        public static bool operator !=(Programmer programmer1, Programmer programmer2)
        {
            return !(programmer1 == programmer2);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Surname.GetHashCode();
                hash = hash * 23 + Experience.GetHashCode();
                hash = hash * 23 + Wage_per_hour.GetHashCode();
                hash = hash * 23 + Minimum_amount_hour.GetHashCode();
                hash = hash * 23 + HoursWorked.GetHashCode();
                return hash;
            }
        }
        public object[] ToArray()
        {
            object[] programmer = new object[6] {Surname, Experience, Wage_per_hour,
                Minimum_amount_hour, HoursWorked, Salary()};
            return programmer;
        }

    }
    public class ExcessiveHoursArgument : EventArgs
    {
        public double Parameter { get; set; }
        public double AdditionalParameter { get; set; }
        public string Message { get; set; }
        public ExcessiveHoursArgument(double param)
        {
            Parameter = param;
        }
    }
}
