using System;

// Clase para probar el sistema de verificación de contraseñas
public class PruebaVerificador
{
    public static void PruebaVerificacion()
    {
        Console.WriteLine("=== Prueba del Sistema de Verificación de Contraseñas ===\n");

        // Crear verificadores individuales
        VSimple vSimple = new VSimple();
        VLongMin vMinimo = new VLongMin(8);
        VLongMax vMaximo = new VLongMax(20);
        VCantNum vNumeros = new VCantNum(2);
        VCantMayus vMayusculas = new VCantMayus(1);

        // Crear cadena de verificadores
        VLongMin vComplejo = new VLongMin(8, 
            new VLongMax(20, 
                new VCantNum(2, 
                    new VCantMayus(1, 
                        new VSimple()))));

        // Pruebas con diferentes contraseñas
        string[] contraseñas = {
            "",                    // Vacía
            "abc",                 // Muy corta
            "Password123",         // Válida
            "password123",         // Sin mayúscula
            "PASSWORD",            // Sin números
            "Pass1",               // Muy corta y pocos números
            "ThisIsAVeryLongPasswordThatExceedsTheLimit123" // Muy larga
        };

        foreach (string pass in contraseñas)
        {
            Console.WriteLine($"Contraseña: '{pass}'");
            Console.WriteLine($"  Verificador Simple: {vSimple.Verificar(pass)}");
            Console.WriteLine($"  Verificador Complejo: {vComplejo.Verificar(pass)}");
            Console.WriteLine($"  Longitud mínima (8): {vMinimo.Verificar(pass)}");
            Console.WriteLine($"  Longitud máxima (20): {vMaximo.Verificar(pass)}");
            Console.WriteLine($"  Cantidad números (2): {vNumeros.Verificar(pass)}");
            Console.WriteLine($"  Cantidad mayúsculas (1): {vMayusculas.Verificar(pass)}");
            Console.WriteLine();
        }
    }
}
