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

    public static void SignUp(string user, string email, string password){
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = @"USE [UserInfo]
                INSERT INTO [dbo].[UserInformation]
                        ([Username]
                        ,[Contraseña]
                        ,[Email]
                        ,[Edad]
                        ,[Nombre])
                    VALUES
                        (@username
                        ,@contra
                        ,@mail
                        ,''
                        ,'')
                    ";
            db.Execute(SQL, new {username = user, mail = email, contra = password});
        }
    }

    public static void UpdateInfo(string username, string nombre, string age, string mail){
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = @"USE [UserInfo]
                        UPDATE [dbo].[UserInformation]
                        SET [Email] = @email
                            ,[Edad] = @edad
                            ,[Nombre] = @name
                        WHERE Username = @user";
            db.Execute(SQL, new {email = mail, edad = age, name = nombre, user = username});
        }
    }

    public static User GetInfoFromUser(string myUser){
        User MiUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Username = @miUsuario";
            MiUsuario = db.QueryFirstOrDefault<User>(SQL, new {miUsuario = myUser});
        }
        return MiUsuario;
    }

    public static User GetInfoFromEmail(string myEmail){
        User MiUsuario = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Email = @miMail";
            MiUsuario = db.QueryFirstOrDefault<User>(SQL, new {miMail = myEmail});
        }
        return MiUsuario;
    }
}