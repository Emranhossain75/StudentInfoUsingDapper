using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CrudDapper.Models;

namespace CrudDapper
{
    public class DALStudent
    {
        public List<Student>GetStudent()
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            SqlCommand command = new SqlCommand("ViewStudent", cnn);
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            List<Student> IsData = new List<Student>();
            while (reader.Read())
            {
                IsData.Add(new Student()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Name = reader["Name"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Salary = reader["Salary"].ToString()

                });
                
               
            }
            return IsData;
        }
    }
}