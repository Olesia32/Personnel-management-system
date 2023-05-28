using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Project
{
    [Serializable]
    public class Leader : Employee
    {
        public delegate void ExcessiveNumberJuniorsEvent(object sender, ExcessiveNumberJuniorsArgument arg);
        public event ExcessiveNumberJuniorsEvent ExcessiveNumberJuniors;
        private int junior;
        private double premium;
        private const int normal_number_juniors = 5;

        public Leader()
            : base()
        {
            junior = 0;
            Minimum_amount_hour = 40;
        }

        public Leader(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour, int _junior)
            : base(_surname, _experience, _wage_per_hour, _minimum_amount_hour)
        {
            junior = _junior;
            Minimum_amount_hour = 40;
        }

        public Leader(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour)
            : base(_surname, _experience, _wage_per_hour, _minimum_amount_hour)
        {
            junior = 0;
            Minimum_amount_hour = 40;
        }
        public int Junior
        {
            get { return junior; }
            set
            {
                junior = value;
                if (junior > normal_number_juniors)
                {
                    OnExcessiveNumberJuniors(junior - normal_number_juniors);
                }
            }
        }
        public override double Salary()
        {
            double salary = base.Salary();
            for (int i = 0; i < junior; i++)
            {
                salary *= 1.01;
            }
            if (premium != 0.0)
            {
                salary += premium;
            }
            return Math.Round(salary, 2);
        }

        public override string ToString()
        {
            return $"Керівник: {base.ToString()}";
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введіть кількість підлеглих: ");
            junior = Int32.Parse(Console.ReadLine());
        }
        public void JuniorSuccess(object sender, ExcessiveHoursArgument arg)
        {
            Programmer programmer = sender as Programmer;
            if (arg is ExcessiveHoursArgument) (arg as ExcessiveHoursArgument).Message =
                    $"Вітаю з чудовим результатом колего {programmer.Surname}.";
        }
        public void OnExcessiveNumberJuniors(double param)
        {
            if (ExcessiveNumberJuniors != null)
            {
                ExcessiveNumberJuniorsArgument arg = new ExcessiveNumberJuniorsArgument(param);
                ExcessiveNumberJuniors(this, arg);

                if (arg.AdditionalParameter != 0.0)
                {
                    premium = arg.AdditionalParameter;
                    Console.WriteLine($"Тепер зарплата керівника становить {Salary()} UAH");
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Leader otherLeader = (Leader)obj;

            // Перевірка рівності полів базового класу (Employee)
            if (!base.Equals(obj))
            {
                return false;
            }
            return true;
        }
        public static bool operator ==(Leader leader1, Leader leader2)
        {
            if (ReferenceEquals(leader1, leader2))
            {
                return true;
            }

            if (ReferenceEquals(leader1, null) || ReferenceEquals(leader2, null))
            {
                return false;
            }

            return leader1.Equals(leader2);
        }

        public static bool operator !=(Leader leader1, Leader leader2)
        {
            return !(leader1 == leader2);
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
                return hash;
            }
        }
        public object[] ToArray()
        {
            object[] leader = new object[5] {Surname, Experience, Wage_per_hour,
                Minimum_amount_hour, Salary()};
            return leader;
        }
    }
    public class ExcessiveNumberJuniorsArgument : EventArgs
    {
        public double Parameter { get; set; }
        public double AdditionalParameter { get; set; }
        public string Message { get; set; }
        public ExcessiveNumberJuniorsArgument(double param)
        {
            Parameter = param;
        }
    }
}
