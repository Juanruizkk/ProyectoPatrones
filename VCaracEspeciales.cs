using System;
using System.Linq;

// Verificador de cantidad específica de caracteres especiales en la contraseña
public class VCaracEspeciales : VEspecifico
{
    private bool especiales;

    public VCaracEspeciales(bool especiales, Verificador? vClass = null) : base(vClass)
    {
        this.especiales = especiales;
    }

    protected override bool VerificarEsp(string pass)
    {
        string caracteresEspeciales = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        int count = pass.Count(c => caracteresEspeciales.Contains(c));
        return especiales ? count > 0 : count == 0;
    }
}