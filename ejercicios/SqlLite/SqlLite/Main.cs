using System;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using SQLite.Designer;

public class pruebaSQLite
{
    public static void Main()
    {
        Console.WriteLine("Creando la base de datos...");
        // Creamos la conexion a la BD.
        // El Data Source contiene la ruta del archivo de la BD
        SQLiteConnection conexion = new SQLiteConnection
        ("Data Source=prueba.sqlite;Version=3;New=True;Compress=True;");
        conexion.Open();
        // Creamos la tabla
        string creacion = "CREATE TABLE gente "
        + "(codigo INT PRIMARY KEY, nombre VARCHAR(40), edad INT);";
        SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
        cmd.ExecuteNonQuery();
        // E insertamos dos datos
        string insercion = "INSERT INTO gente VALUES (1,'Juan',20);";
        cmd = new SQLiteCommand(insercion, conexion);
        int cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        insercion = "INSERT INTO gente VALUES (2,'Pedro',19);";
        cmd = new SQLiteCommand(insercion, conexion);
        cantidad = cmd.ExecuteNonQuery();
        if (cantidad < 1)
            Console.WriteLine("No se ha podido insertar");
        // Finalmente, cerramos la conexion
        conexion.Close();
        Console.WriteLine("Creada.");
    }
}