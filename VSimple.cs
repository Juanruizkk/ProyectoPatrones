using System;

// Verificador simple que solo valida que la contraseña no esté vacía
public class VSimple : Verificador
{
    private bool NoVacio(string pass) => !string.IsNullOrEmpty(pass);

    public override bool Verificar(string pass)
    {
        return NoVacio(pass);
    }
}
