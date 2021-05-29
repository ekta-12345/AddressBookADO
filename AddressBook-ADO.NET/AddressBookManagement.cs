﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    public class AddressBookManagement
    {
        // UC1:- Address Book ServiceDB using SQL Client to create DB and DB Records.

        public static string connectionString = @"Data Source=ABHISHEK\SQLEXPRESS;Initial Catalog=AddressBookSys;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"; //Specifying the connection string from the sql server connection.

        SqlConnection connection = new SqlConnection(connectionString); // Establishing the connection using the Sqlconnection.  

        public void DataBaseConnection()
        {
            try
            {
                DateTime now = DateTime.Now; //create object DateTime class //DateTime.Now class access system date and time 
                connection.Open(); // open connection
                using (connection)  //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful {now}"); //print msg

                }
                connection.Close(); //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // UC2:- Ability to create a Address Book Table with different attributes
                     
        public void GetAllContact()
        {

            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.AddressBookSys"; // Query to get all the data from the table

                    SqlCommand command = new SqlCommand(query, connection); // Impementing the command on the connection fetched database table

                    connection.Open();  //Open the connection.

                    SqlDataReader reader = command.ExecuteReader();  // executing the sql data reader to fetch the records
                    if (reader.HasRows)
                    {

                        while (reader.Read())  // Mapping the data to the employee model class object
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.Zip = reader.GetString(5);
                            model.PhoneNumber = reader.GetString(6);
                            model.EmailId = reader.GetString(7);
                            model.AddressBookType = reader.GetString(8);
                            model.AddressBookName = reader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.FirstName, model.LastName,
                                model.Address, model.City, model.State, model.Zip, model.PhoneNumber, model.EmailId, model.AddressBookType, model.AddressBookName);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found in the Address Book Sys Table");
                    }
                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close(); // Always ensuring the closing of the connection
            }

        }
    }
}
