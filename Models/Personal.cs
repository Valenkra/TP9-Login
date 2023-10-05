namespace Login.Controllers;

public static class Persona {
    public static string Username {get; set;}
    public static string Contraseña {get; set;}
    public static string Email {get; set;}
    public static int Edad {get; set;}
    public static string Nombre {get; set;}

    public static bool logged = false;
}