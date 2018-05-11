using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiSample.Infra;

namespace WebApiSample.Domain
{
    public class Contact
    {
        #region Attributes
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BornDate { get; set; }
        public string Gender { get; set; }
        #endregion

        /// <summary>
        /// Get = Select
        /// Post = Insert
        /// Put = Update(ou Insert)
        /// Delete = Delete
        /// </summary>

        #region Get All

        public List<Contact> GetAll()
        {
            List<Contact> listContact = new List<Contact>();

            try
            {
                SQLConnection.Connect();
                SqlCommand command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"SELECT * FROM Contact"
                };
                command.Parameters.AddWithValue("@User_Id", User_Id);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Contact contact = new Contact();
                    contact.User_Id = Int32.Parse(dataReader["User_Id"].ToString());
                    contact.Name = dataReader["Name"].ToString();
                    contact.Phone = dataReader["Phone"].ToString();
                    contact.Email = dataReader["Email"].ToString();
                    contact.BornDate = dataReader["BornDate"].ToString();
                    contact.Gender = dataReader["Gender"].ToString();
                    listContact.Add(contact);
                }

                dataReader.Close();

                return listContact;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SQLConnection.Disconnect();
            }
        }
        #endregion

        #region Get By Id
        public int GetById()
        {
            try
            {
                SQLConnection.Connect();
                SqlCommand command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"SELECT * FROM Contact WHERE User_Id = '{User_Id}'"
                };
                command.Parameters.AddWithValue("@User_Id", User_Id);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    User_Id = Int32.Parse(dataReader["User_Id"].ToString());
                    Name = dataReader["Name"].ToString();
                    Phone = dataReader["Phone"].ToString();
                    Email = dataReader["Email"].ToString();
                    BornDate = dataReader["BornDate"].ToString();
                    Gender = dataReader["Gender"].ToString();
                }

                dataReader.Close();

                int qtd = command.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SQLConnection.Disconnect();
            }
        }
        #endregion

        #region Post
        public int Post()
        {
            try
            {
                SQLConnection.Connect();
                var command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText =
                    $"INSERT INTO Contact (Name, Phone, Email, BornDate, Gender) " +
                    $"VALUES ('{Name}', '{Phone}','{Email}', '{BornDate}', '{Gender}')"
                };

                int qtd = command.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SQLConnection.Disconnect();
            }
        }
        #endregion

        #region Put By Id
        public int PutById()
        {
            try
            {
                SQLConnection.Connect();
                var command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"UPDATE Contact SET Name = '{Name}', Phone = '{Phone}'," +
                    $"Email = '{Email}', BornDate = '{BornDate}', Gender = '{Gender}'" +
                    $"WHERE User_Id = '{User_Id}'"
                };

                command.Parameters.AddWithValue("@User_Id", User_Id);

                int qtd = command.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SQLConnection.Disconnect();
            }
        }
        #endregion

        #region Delete By Id
        public int DeleteById()
        {
            try
            {
                SQLConnection.Connect();
                var command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"DELETE FROM Contact WHERE User_Id = '{User_Id}'"
                };

                int qtd = command.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SQLConnection.Disconnect();
            }
        }
        #endregion
        
    }
}
