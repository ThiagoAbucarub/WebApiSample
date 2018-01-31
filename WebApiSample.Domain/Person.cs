using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiSample.Infra;

namespace WebApiSample.Domain
{
    public class Person
    {
        #region Attributes
        public int PersonId { get; set; }
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

        public List<Person> GetAll()
        {
            List<Person> listPerson = new List<Person>();

            try
            {
                SQLConnection.Connect();
                SqlCommand command = new SqlCommand
                {
                    Connection = SQLConnection.connection,
                    CommandType = CommandType.Text,
                    CommandText = $"SELECT * FROM Person"
                };
                command.Parameters.AddWithValue("@PersonId", PersonId);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Person person = new Person();
                    person.PersonId = Int32.Parse(dataReader["PersonId"].ToString());
                    person.Name = dataReader["Name"].ToString();
                    person.Phone = dataReader["Phone"].ToString();
                    person.Email = dataReader["Email"].ToString();
                    person.BornDate = dataReader["BornDate"].ToString();
                    person.Gender = dataReader["Gender"].ToString();
                    listPerson.Add(person);
                }

                dataReader.Close();

                return listPerson;

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
                    CommandText = $"SELECT * FROM Person WHERE PersonId = '{PersonId}'"
                };
                command.Parameters.AddWithValue("@PersonId", PersonId);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    PersonId = Int32.Parse(dataReader["PersonId"].ToString());
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
                    $"INSERT INTO Person (Name, Phone, Email, BornDate, Gender) " +
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
                    CommandText = $"UPDATE Person SET Name = '{Name}', Phone = '{Phone}'," +
                    $"Email = '{Email}', BornDate = '{BornDate}', Gender = '{Gender}'" +
                    $"WHERE PersonId = '{PersonId}'"
                };

                command.Parameters.AddWithValue("@PersonId", PersonId);

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
                    CommandText = $"DELETE FROM Person WHERE PersonId = '{PersonId}'"
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
