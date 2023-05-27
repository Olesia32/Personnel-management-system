using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime;

namespace GI_Project
{
    public static class Personal
    {
        public static Dictionary<Leader, List<Programmer>> hierarchy = new Dictionary<Leader, List<Programmer>>();
        public static List<string> log = new List<string>();
        public static HumanResourcesDepartment human_resources_department = new HumanResourcesDepartment();

        public static int CountProgrammer
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<Leader, List<Programmer>> pair in hierarchy)
                {
                    count += pair.Value.Count;
                }
                return count;
            }
        }
        public static int CountLeader
        {
            get { return hierarchy.Count; }
        }
        public static void AddNewLeader(Leader leader)
        {
            leader.ExcessiveNumberJuniors += human_resources_department.TrackingWorkLeaders;
            hierarchy.Add(leader, new List<Programmer>());
        }
        public static void AddNewEmployee(Leader leader, Programmer employee)
        {
            leader.Junior += 1;
            if (human_resources_department.Message != null)
            {
                log.Add(human_resources_department.Message);
                human_resources_department.Message = null;
                if (human_resources_department.AdditionalMessage != null)
                {
                    log.Add(human_resources_department.AdditionalMessage);
                    human_resources_department.AdditionalMessage = null;
                }
            }
            employee.ExcessiveHours += human_resources_department.TrackingWorkEmployees;
            hierarchy[leader].Add(employee);
        }
        public static void DeleteEmployee(Programmer employee)
        {
            foreach (List<Programmer> programmerList in hierarchy.Values)
            {
                if (programmerList.Contains(employee))
                {
                    programmerList.Remove(employee);
                }
            }
        }
        public static List<Programmer> DeleteLeader(Leader leader)
        {
            List<Programmer> employeeList = new List<Programmer>();
            if (hierarchy.ContainsKey(leader))
            {
                employeeList = hierarchy[leader];
                hierarchy.Remove(leader);
            }
            return employeeList;
        }
        public static Leader GetLeaderByEmployee(Programmer programmer)
        {
            foreach (var pair in hierarchy)
            {
                if (pair.Value.Contains(programmer))
                {
                    return pair.Key;
                }
            }
            return null;
        }
        public static List<Programmer> GetEmployeesByLeader(Leader leader)
        {
            if (hierarchy.ContainsKey(leader))
            {
                return hierarchy[leader];
            }
            return null;
        }
        public static void UpdateEmployee(bool isLeader, Employee oldEmployee, Employee newEmployee)
        {
            if (isLeader)
            {
                foreach (var leader in hierarchy.Keys)
                {
                    if (leader.Equals(oldEmployee))
                    {
                        leader.Surname = newEmployee.Surname;
                        leader.Experience = newEmployee.Experience;
                        leader.Wage_per_hour = newEmployee.Wage_per_hour;
                        leader.Minimum_amount_hour = newEmployee.Minimum_amount_hour;
                        break;
                    }
                }
            }
            else
            {
                foreach (var leader in hierarchy.Keys)
                {
                    foreach (var programmer in hierarchy[leader])
                    {
                        if (programmer.Equals(oldEmployee))
                        {
                            programmer.Surname = newEmployee.Surname;
                            programmer.Experience = newEmployee.Experience;
                            programmer.Wage_per_hour = newEmployee.Wage_per_hour;
                            programmer.Minimum_amount_hour = newEmployee.Minimum_amount_hour;
                            programmer.HoursWorked = (newEmployee as Programmer).HoursWorked;
                            if(human_resources_department.Message != null)
                            {
                                log.Add(human_resources_department.Message);
                                human_resources_department.Message = null;
                                if (human_resources_department.AdditionalMessage != null)
                                {
                                    log.Add(human_resources_department.AdditionalMessage);
                                    human_resources_department.AdditionalMessage = null;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
        public static void ReadDataFromFile(string filePath)
        {
            hierarchy = new Dictionary<Leader, List<Programmer>>();
            Leader currentLeader = null;
            List<Programmer> currentProgrammers = new List<Programmer>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("-"))
                {
                    string[] programmerData = line.Substring(1).Trim().Split(':');
                    Programmer programmer = CreateProgrammerFromData(programmerData);
                    currentProgrammers.Add(programmer);
                }
                else
                {
                    if (currentLeader != null && currentProgrammers.Count > 0)
                    {
                        AddNewLeader(currentLeader);
                        foreach (Programmer programmer in currentProgrammers)
                        {
                            AddNewEmployee(currentLeader, programmer);
                        }

                        currentProgrammers = new List<Programmer>();
                    }

                    string[] leaderData = line.Split(':');
                    currentLeader = CreateLeaderFromData(leaderData[1]);
                }
            }

            if (currentLeader != null && currentProgrammers.Count > 0)
            {
                AddNewLeader(currentLeader);
                foreach (Programmer programmer in currentProgrammers)
                {
                    AddNewEmployee(currentLeader, programmer);
                }
            }
        }

        public static Leader CreateLeaderFromData(string leaderData)
        {
            string[] leaderProperties = leaderData.Split(';');

            string surname = leaderProperties[0];
            double experience = double.Parse(leaderProperties[1]);
            double wagePerHour = double.Parse(leaderProperties[2]);
            double minimumAmountHour = double.Parse(leaderProperties[3]);

            return new Leader(surname, experience, wagePerHour, minimumAmountHour, 0);
        }

        public static Programmer CreateProgrammerFromData(string[] programmerData)
        {
            string[] programmerProperties = programmerData[1].Split(';');

            string surname = programmerProperties[0];
            double experience = double.Parse(programmerProperties[1]);
            double wagePerHour = double.Parse(programmerProperties[2]);
            double minimumAmountHour = double.Parse(programmerProperties[3]);
            double salary = double.Parse(programmerProperties[4]);
            double workedHours = double.Parse(programmerProperties[5]);

            return new Programmer(surname, experience, wagePerHour, minimumAmountHour, workedHours);
        }

        public static void WriteDataToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<Leader, List<Programmer>> pair in hierarchy)
                {
                    Leader leader = pair.Key;
                    List<Programmer> programmers = pair.Value;

                    // Записуємо дані про керівника
                    string leaderData = string.Format("Керівник:{0}; {1}; {2:0.00}; {3:0.00}; {4:0.00}",
                        leader.Surname, leader.Experience, leader.Wage_per_hour, leader.Minimum_amount_hour, leader.Salary());
                    writer.WriteLine(leaderData);

                    foreach (Programmer programmer in programmers)
                    {
                        // Записуємо дані про програмістів
                        string programmerData = string.Format("-Програміст:{0}; {1}; {2:0.00}; {3:0.00}; {4:0.00}; {5:0.00}",
                            programmer.Surname, programmer.Experience, programmer.Wage_per_hour,
                            programmer.Minimum_amount_hour, programmer.Salary(), programmer.HoursWorked);
                        writer.WriteLine(programmerData);
                    }
                }
            }
        }
        internal static void WriteToBinaryFile(string path)
        {
            IFormatter serializer = new BinaryFormatter();
            using (FileStream saveFile = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(saveFile, hierarchy);
            }
        }
        internal static void WriteToXmlFile(string path)
        {
            XElement rootElement = new XElement("Dictionary");

            foreach (var kvp in hierarchy)
            {
                XElement leaderElement = new XElement("Leader");
                leaderElement.Add(new XElement("Surname", kvp.Key.Surname));
                leaderElement.Add(new XElement("Experience", kvp.Key.Experience));
                leaderElement.Add(new XElement("WagePerHour", kvp.Key.Wage_per_hour));
                leaderElement.Add(new XElement("MinimumAmountHour", kvp.Key.Minimum_amount_hour));

                foreach (var programmer in kvp.Value)
                {
                    XElement programmerElement = new XElement("Programmer");
                    programmerElement.Add(new XElement("Surname", programmer.Surname));
                    programmerElement.Add(new XElement("Experience", programmer.Experience));
                    programmerElement.Add(new XElement("WagePerHour", programmer.Wage_per_hour));
                    programmerElement.Add(new XElement("MinimumAmountHour", programmer.Minimum_amount_hour));
                    programmerElement.Add(new XElement("HoursWorked", programmer.HoursWorked));

                    leaderElement.Add(programmerElement);
                }

                rootElement.Add(leaderElement);
            }
            File.WriteAllText(path, rootElement.ToString());
        }
        public static void ReadFromBinaryFile(string fileName)
        {
            IFormatter serializer = new BinaryFormatter();
            using (FileStream loadFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                hierarchy = serializer.Deserialize(loadFile) as Dictionary<Leader, List<Programmer>>;
            }
        }

        public static object[] ToArray(bool leaders)
        {
            if (leaders)
            {
                object[] array = new object[hierarchy.Count];
                int index = 0;
                foreach (KeyValuePair<Leader, List<Programmer>> pair in hierarchy)
                {
                    array[index] = pair.Key.ToArray();
                    index++;
                }
                return array;
            }
            else
            {
                object[] array = new object[CountProgrammer];
                int index = 0;
                foreach (KeyValuePair<Leader, List<Programmer>> pair in hierarchy)
                {
                    foreach (Programmer pr in pair.Value)
                    {
                        array[index] = pr.ToArray();
                        index++;
                    }
                }
                return array;
            }
        }
        public static List<string> ListOfLeaders()
        {
            List<string> list = new List<string>();
            foreach (var i in hierarchy.Keys)
            {
                string line = string.Empty;
                line += $"{i.Surname}; {i.Experience}; {i.Wage_per_hour}; {i.Minimum_amount_hour}";
                list.Add(line);
            }
            return list;
        }
        public static void ReadFromXmlFile(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            XElement rootElement = xmlDoc.Element("Dictionary");
            hierarchy = new Dictionary<Leader, List<Programmer>>();
            foreach (XElement leaderElement in rootElement.Elements("Leader"))
            {
                Leader leader = new Leader();
                leader.Surname = leaderElement.Element("Surname").Value;
                leader.Experience = double.Parse(leaderElement.Element("Experience").Value);
                leader.Wage_per_hour = double.Parse(leaderElement.Element("WagePerHour").Value);
                leader.Minimum_amount_hour = double.Parse(leaderElement.Element("MinimumAmountHour").Value);
                List<Programmer> programmers = new List<Programmer>();
                foreach (XElement programmerElement in leaderElement.Elements("Programmer"))
                {
                    Programmer programmer = new Programmer();
                    programmer.Surname = programmerElement.Element("Surname").Value;
                    programmer.Experience = double.Parse(programmerElement.Element("Experience").Value);
                    programmer.Wage_per_hour = double.Parse(programmerElement.Element("WagePerHour").Value);
                    programmer.Minimum_amount_hour = double.Parse(leaderElement.Element("MinimumAmountHour").Value);
                    programmer.HoursWorked = double.Parse(programmerElement.Element("HoursWorked").Value);
                    programmers.Add(programmer);
                }
                hierarchy.Add(leader, programmers);
            }
        }
        // Зчитати дані з файлу у форматі JSON
        public static void ReadFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Dictionary<string, List<Programmer>>>(json);
            hierarchy = new Dictionary<Leader, List<Programmer>>();

            foreach (var item in data)
            {
                var leaderData = JsonConvert.DeserializeObject<Leader>(item.Key);
                hierarchy.Add(leaderData, item.Value);
            }
        }

        // Записати дані у форматі JSON
        public static void WriteToJsonFile(string filePath)
        {
            var data = new Dictionary<string, List<Programmer>>();
            foreach (var item in hierarchy)
            {
                string key = JsonConvert.SerializeObject(item.Key);
                data.Add(key, item.Value);
            }

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }
        public static void Clear()
        {
            hierarchy = new Dictionary<Leader, List<Programmer>>();
        }
        public static double CalculateAverageSalary()
        {
            List<Employee> allEmployees = hierarchy.Keys.Cast<Employee>()
                .Concat(hierarchy.Values.SelectMany(programmers => programmers))
                .ToList();
            double totalSalary = allEmployees.Sum(employee => employee.Salary());
            int totalEmployeeCount = allEmployees.Count;
            if (totalEmployeeCount > 0)
            {
                return totalSalary / totalEmployeeCount;
            }
            return 0.0;
        }
        public static double CalculateTotalSalary()
        {
            List<Employee> allEmployees = hierarchy.Keys.Cast<Employee>()
                .Concat(hierarchy.Values.SelectMany(programmers => programmers))
                .ToList();
            double totalSalary = allEmployees.Sum(employee => employee.Salary());
            return totalSalary;
        }
        public static double CalculateAverage(string propertyName)
        {
            double sum = 0;
            int count = 0;
            foreach (KeyValuePair<Leader, List<Programmer>> kvp in hierarchy)
            {
                if (kvp.Key.GetType().GetProperty(propertyName) != null)
                {
                    sum += (double)kvp.Key.GetType().GetProperty(propertyName).GetValue(kvp.Key);
                    count++;
                }
                foreach (Programmer programmer in kvp.Value)
                {
                    if (programmer.GetType().GetProperty(propertyName) != null)
                    {
                        sum += (double)programmer.GetType().GetProperty(propertyName).GetValue(programmer);
                        count++;
                    }
                }
            }
            if (count > 0) return sum / count;
            return 0;
        }
        public static double CalculateSum(string propertyName)
        {
            double sum = 0;
            foreach (KeyValuePair<Leader, List<Programmer>> kvp in hierarchy)
            {
                if (kvp.Key.GetType().GetProperty(propertyName) != null)
                {
                    sum += (double)kvp.Key.GetType().GetProperty(propertyName).GetValue(kvp.Key);
                }
                foreach (Programmer programmer in kvp.Value)
                {
                    if (programmer.GetType().GetProperty(propertyName) != null)
                    {
                        sum += (double)programmer.GetType().GetProperty(propertyName).GetValue(programmer);
                    }
                }
            }
            return sum;
        }
        public static double FindMaxSalary()
        {
            List<Employee> allEmployees = hierarchy.Keys.Cast<Employee>()
                .Concat(hierarchy.Values.SelectMany(programmers => programmers))
                .ToList();
            return allEmployees.Max().Salary();
        }

        public static double FindMinSalary()
        {
            List<Employee> allEmployees = hierarchy.Keys.Cast<Employee>()
                .Concat(hierarchy.Values.SelectMany(programmers => programmers))
                .ToList();
            return allEmployees.Min().Salary();
        }
        public static void AddNewRecordToLog(string record)
        {
            log.Add(record);
        }
        public static void ClearLog()
        {
            log = new List<string>();
        }
        internal static void StoreLog()
        {
            string logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }
            string name = DateTime.Now.ToString().Replace(":", ".") + ".txt";
            string logFilePath = Path.Combine(logFolderPath, name);
            using (StreamWriter writer = new StreamWriter(logFilePath))
            {
                writer.WriteLine(log.Count);
                foreach (string line in log)
                {
                    writer.WriteLine(line);
                }
            }
        }
        public static Employee FindHighestPaidEmployee()
        {
            List<Employee> allEmployees = hierarchy.Keys.Cast<Employee>()
                .Concat(hierarchy.Values.SelectMany(programmers => programmers))
                .ToList();
            return allEmployees.Max();
        }
        public static List<double> GetLeaderSalaries()
        {
            List<double> salaries = new List<double>();
            // Отримуємо зарплати керівників
            foreach (var leader in hierarchy.Keys)
            {
                salaries.Add(leader.Salary());
            }
            return salaries;
        }
        public static List<double> GetProgarammerSalaries()
        {
            List<double> salaries = new List<double>();

            // Отримуємо зарплати працівників
            foreach (var leader in hierarchy.Keys)
            {
                foreach (var programmer in hierarchy[leader])
                {
                    salaries.Add(programmer.Salary());
                }
            }
            return salaries;
        }
        public static Dictionary<double, double> CalculateEmpiricalDistribution(List<double> values)
        {
            Dictionary<double, double> empiricalDistribution = new Dictionary<double, double>();

            // Сортуємо значення за зростанням
            values.Sort();

            // Обчислюємо емпіричну функцію розподілу
            int n = values.Count;
            for (int i = 0; i < n; i++)
            {
                double x = values[i];
                double y = (double)(i + 1) / n;

                empiricalDistribution[x] = y;
            }

            return empiricalDistribution;
        }
    }
}