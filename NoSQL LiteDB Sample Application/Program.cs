using LiteDB;
using System;

namespace NoSQL_LiteDB_Sample_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            #region Insert Data LiteDB will add Id automatically
             DBOperations.InsertData("Halil", "Şahin");
            #endregion

            DBOperations.UpdateData(4, "Halil", "Şahin");
            DBOperations.DeleteData(4);
            string WhoIsID = DBOperations.FindDataById(3);
            string WhoIsName = DBOperations.FindDataByName("Halil");
            Console.WriteLine(WhoIsID);
            Console.WriteLine(WhoIsName);



            
            DBOperations.GetAllDatas();
            


        }
    }
}
