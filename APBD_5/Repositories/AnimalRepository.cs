using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using APBD_5.Model;
using Microsoft.Extensions.Configuration;

namespace APBD_5.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private IConfiguration _configuration;

        public AnimalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy = "name")
        {
            string[] allowedColumns = { "name", "description", "category", "area" };

            orderBy = string.IsNullOrEmpty(orderBy) || !allowedColumns.Contains(orderBy.ToLower()) ? "name" : orderBy.ToLower();

            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"SELECT Id, Name, Description, Category, Area FROM Animal ORDER BY {orderBy}";

            var dr = cmd.ExecuteReader();
            var animals = new List<Animal>();
            while (dr.Read())
            {
                var animal = new Animal
                {
                    Id = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }

            return animals;
        }




        public int CreateAnimal(Animal animal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Animal (Id, Name, Description, Category, Area) VALUES (@Id, @Name, @Description, @Category, @Area)";
            cmd.Parameters.AddWithValue("@Id", animal.Id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            
            return cmd.ExecuteNonQuery();
        }

        public int DeleteAnimal(int idAnimal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Animal WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", idAnimal);

            return cmd.ExecuteNonQuery();
        }

        public Animal GetAnimal(int idAnimal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id, Name, Description, Category, Area FROM Animal WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", idAnimal);

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var animal = new Animal
                {
                    Id = (int)dr["Id"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };
                return animal;
            }

            return null;
        }

        public int UpdateAnimal(Animal animal)
        {
            using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            con.Open();

            using var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", animal.Id);
            cmd.Parameters.AddWithValue("@Name", animal.Name);
            cmd.Parameters.AddWithValue("@Description", animal.Description);
            cmd.Parameters.AddWithValue("@Category", animal.Category);
            cmd.Parameters.AddWithValue("@Area", animal.Area);

            return cmd.ExecuteNonQuery();
        }
    }
}
