using System.Data.SqlClient;
using Dapper;

namespace Login.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=UserInfo; Trusted_Connection=True;";

    public static User checkUser(string usern){
        User elUser = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Username = @CH_us";
            elUser = db.QueryFirstOrDefault<User>(SQL, new {CH_us = usern});
        }
        return elUser;
    }

    public static User checkEmail(string email){
        User elUser = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Email = @CH_em";
            elUser = db.QueryFirstOrDefault<User>(SQL, new {CH_em = email});
        }
        return elUser;
    }

    public static User LogIn(string usern, string password){
        User elUser = null;
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM UserInformation WHERE Username = @LG_us and Contraseña = @LG_pass";
            elUser = db.QueryFirstOrDefault<User>(SQL, new {LG_us = usern, LG_pass = password});
        }
        return elUser;
    }

    public static int SignUp(string user, string email, string password){
        int result;
        User userResult = checkUser(user);
        User emailResult = checkEmail(email);
        if(userResult != null && emailResult != null){
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
                        
                    CREATE TRIGGER TR_SignUp ON UserInformation INSTEAD OF INSERT
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                    END
                    ";
                db.Execute(SQL, new {username = user, mail = email, contra = password});
                result = 0;
            }
        } else if(userResult == null && emailResult != null){
            result = 1;
        } else  if(userResult != null && emailResult == null){
            result = 2;
        } else {
            result = 3;
        }
        return result;
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
}