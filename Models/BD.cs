using System.Data.SqlClient;
using Dapper;

namespace Login.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=UserInfo; Trusted_Connection=True;";

    public static User ObtenerCategorias(){
        User elUser = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM User";
            elUser =  db.QueryFirstOrDefault<User>(SQL);
        }
        return elUser;
    }
}