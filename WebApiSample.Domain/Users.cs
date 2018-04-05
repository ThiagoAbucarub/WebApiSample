using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySQL_Windows.Infra;

namespace MySQL_Windows.Domain
{
    public class Users
    {
        #region Attributes
        public int UserId { get; set; }
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

        public List<Users> GetAll()
        {
            List<Users> listUsers = new List<Users>();

            try
            {
                SQLConnection.Connect();
                SqlCommand command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"SELECT * FROM Users"
                };
                command.Parameters.AddWithValue("@UserId", UserId);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Users users = new Users();
                    users.UserId = Int32.Parse(dataReader["UserId"].ToString());
                    users.Name = dataReader["Name"].ToString();
                    users.Phone = dataReader["Phone"].ToString();
                    users.Email = dataReader["Email"].ToString();
                    users.BornDate = dataReader["BornDate"].ToString();
                    users.Gender = dataReader["Gender"].ToString();
                    listUsers.Add(users);
                }

                dataReader.Close();

                return listUsers;

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
                    CommandText = $"SELECT * FROM Users WHERE UserId = '{UserId}'"
                };
                command.Parameters.AddWithValue("@UserId", UserId);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    UserId = Int32.Parse(dataReader["UserId"].ToString());
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
                    $"INSERT INTO Users (Name, Phone, Email, BornDate, Gender) " +
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
                    CommandText = $"UPDATE Users SET Name = '{Name}', Phone = '{Phone}'," +
                    $"Email = '{Email}', BornDate = '{BornDate}', Gender = '{Gender}'" +
                    $"WHERE UserId = '{UserId}'"
                };

                command.Parameters.AddWithValue("@UserId", UserId);

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
                    CommandText = $"DELETE FROM Users WHERE UserId = '{UserId}'"
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
