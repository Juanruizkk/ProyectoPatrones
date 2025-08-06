using System;
using System.Linq;

// Verificador de presencia de letras en la contraseña
public class VCaracLetras : VEspecifico
{
    private bool letras;

    public VCaracLetras(bool letras, Verificador? vClass = null) : base(vClass)
    {
        this.letras = letras;
    }

    protected override bool VerificarEsp(string pass)
    {
        bool tieneLetras = pass.Any(char.IsLetter);
        
        return letras ? tieneLetras : !tieneLetras;
    }
}