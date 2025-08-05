using System;

// Clase abstracta base para verificadores de contraseña
public abstract class Verificador
{
    public abstract bool Verificar(string pass);
}
