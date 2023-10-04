using System.Data.SqlClient;
using Dapper;

namespace Login.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=UserInfo; Trusted_Connection=True;";

    public static User LogIn(string usern, string password){
        User elUser = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Username = @LG_us and Contraseña = @LG_pass";
            elUser = db.QueryFirstOrDefault<User>(SQL, new {LG_us = usern, LG_pass = password});
        }
        return elUser;
    }

    public static void SignUp(string user, string password){
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = @"USE [UserInfo]
                INSERT INTO [dbo].[User]
                        ([Username]
                        ,[Contraseña]
                        ,[Email]
                        ,[Edad]
                        ,[Nombre])
                    VALUES
                        (@username
                        ,@contra
                        ,''
                        ,''
                        ,'')
                    ";
            db.Execute(SQL, new {username = user, contra = password});
        }
    }
}