using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Project
{
    [Serializable]
    public class Employee : IComparable, ICloneable, IFormattable
    {
        private string surname;
        private double experience;
        private double wage_per_hour;
        private double minimum_amount_hour;

        public Employee()
        {
            surname = string.Empty;
            experience = 0.0;
            wage_per_hour = 0.0;
            minimum_amount_hour = 0.0;
        }
        public Employee(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour)
        {
            surname = _surname;
            experience = _experience;
            wage_per_hour = _wage_per_hour;
            minimum_amount_hour = _minimum_amount_hour;
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value;}
        }
        public double Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public double Wage_per_hour
        {
            get { return wage_per_hour; }
            set { wage_per_hour = value; }
        }
        public double Minimum_amount_hour
        {
            get { return minimum_amount_hour; }
            set { minimum_amount_hour = value; }
        }
        public virtual double Salary()
        {
            double salary = minimum_amount_hour * wage_per_hour;
            return salary;
        }
        public virtual double Salary_in_uah()
        {
            return Math.Round(Salary(), 2);
        }
        public virtual double Salary_in_usd()
        {
            // курс НБУ на 27.03.2023
            return Math.Round(Salary() / 36.5686, 2);
        }
        public virtual double Salary_in_eur()
        {
            // курс НБУ на 27.03.2023
            return Math.Round(Salary() / 39.3076, 2);
        }
        public override string ToString()
        {
            return this.ToString("UAH", CultureInfo.CurrentCulture);
        }
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString();
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;
            string formatUpper = format.ToUpper();
            switch (formatUpper)
            {
                case "UAH":
                    return $"{surname}; {experience}; {wage_per_hour}; {minimum_amount_hour}; {Salary_in_uah()}";
                case "USD":
                    return $"{surname}; {experience}; {wage_per_hour}; {minimum_amount_hour}; {Salary_in_uah()}"; ;
                case "EUR":
                    return $"{surname}; {experience}; {wage_per_hour}; {minimum_amount_hour}; {Salary_in_uah()}";
                default:
                    return ToString();
            }
        }
        public static Employee operator +(Employee _employee, double new_wage_per_hour)
        {
            return new Employee(_employee.surname, _employee.experience, _employee.wage_per_hour + new_wage_per_hour, _employee.minimum_amount_hour);
        }
        public static bool operator <(Employee first, Employee second)
        {
            return first.Salary() < second.Salary();
        }
        public static bool operator >(Employee first, Employee second)
        {
            return first.Salary() > second.Salary();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as Employee);
        }

        public bool Equals(Employee other)
        {
            if (other == null)
            {
                return false;
            }

            return surname == other.surname &&
                   experience == other.experience &&
                   wage_per_hour == other.wage_per_hour &&
                   minimum_amount_hour == other.minimum_amount_hour;
        }
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            if (ReferenceEquals(employee1, employee2))
            {
                return true;
            }

            if (ReferenceEquals(employee1, null) || ReferenceEquals(employee2, null))
            {
                return false;
            }

            return employee1.Equals(employee2);
        }

        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return !(employee1 == employee2);
        }
        public virtual void ReadFromConsole()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Введіть прізвище працівника: ");
            surname = Console.ReadLine();

            Console.Write("Введіть стаж: ");
            experience = Double.Parse(Console.ReadLine());

            Console.Write("Введіть оплату за годину: ");
            wage_per_hour = Double.Parse(Console.ReadLine());

            Console.Write("Введіть мінімальну кількість годин, які він має відпрацювати за тиждень: ");
            minimum_amount_hour = Double.Parse(Console.ReadLine());
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Employee))
            {
                throw new ArgumentException("Compared Object is not of employee");
            }
            Employee employee = obj as Employee;
            return Salary().CompareTo(employee.Salary());
        }

        public object Clone()
        {
            return new Employee(surname, experience, wage_per_hour, minimum_amount_hour);
        }
    }
}
