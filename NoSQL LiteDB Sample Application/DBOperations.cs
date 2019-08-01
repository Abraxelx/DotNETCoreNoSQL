using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSQL_LiteDB_Sample_Application
{
    class DBOperations
    {
        public static void InsertData(string name, string surname)
        {
            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var customers = myDB.GetCollection<Customers>("head");
                var customer = new Customers
                {
                    Name = name,
                    Surname = surname

                };
                customers.Insert(customer);

            }

        }
        public static void GetAllDatas()
        {
            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var dbList = myDB.GetCollection<Customers>("head");
                var frList = dbList.FindAll();

                foreach (var item in frList)
                {
                    Console.WriteLine("ID:" + item.Id);
                    Console.WriteLine("Name:" + item.Name.ToString());
                    Console.WriteLine("Surname:" + item.Surname.ToString());
                    
                }
            }
        }
        public static void UpdateData(int id, string name, string surname)
        {
            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var customers = myDB.GetCollection<Customers>("head");
                var customer = new Customers();
                customer.Id = id;
                customer.Name = name;
                customer.Surname = surname;

                customers.Update(customer);

            }

        }
        public static void DeleteData(int id)
        {
            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var customers = myDB.GetCollection<Customers>("head");
                customers.Delete(x => x.Id == id);
               
            }
        }
        public static string FindDataById(int id)
        {
            string NameOfPerson = String.Empty;
            string SurnameOfPerson = String.Empty;

            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var customers = myDB.GetCollection<Customers>("head");
                var FindResult = customers.Find(x => x.Id == id);

               // return FindResult;

                foreach (var item in FindResult)
                {
                    NameOfPerson = item.Name.ToString();
                    SurnameOfPerson = item.Surname.ToString();
                }
            }

            return "The Person is : " + NameOfPerson + " " + SurnameOfPerson;

            
        }
        public static string FindDataByName(string name)
        {
            string NameOfPerson = String.Empty;
            string SurnameOfPerson = String.Empty;

            using (var myDB = new LiteDatabase("@NoSQL.db"))
            {
                var customers = myDB.GetCollection<Customers>("head");
                var FindResult = customers.Find(x => x.Name == name);

                // return FindResult;

                foreach (var item in FindResult)
                {
                    NameOfPerson = item.Name.ToString();
                    SurnameOfPerson = item.Surname.ToString();
                }
            }

            return "The Person is : " + NameOfPerson + " " + SurnameOfPerson;


        }
    }
}
