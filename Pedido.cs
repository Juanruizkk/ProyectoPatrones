using System;
using System.Collections.Generic;

// Clase Pedido (Context)
public class Pedido
{
    private List<string> pedidos;
    private Estado estado;

    public Pedido()
    {
        pedidos = new List<string>();
        estado = Ingresado.GetInstance(); // Estado inicial
    }

    public List<string> ListarInfo()
    {
        return new List<string>(pedidos);
    }

    public void SetEstado(Estado nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public Estado GetEstado()
    {
        return estado;
    }

    public void AgregarPedido(string pedido, string repartidor = null)
    {
        estado.Asignar(this, pedido, repartidor);
    }

    public void CancelarPedido()
    {
        estado.Cancelar(this);
    }

    public void RechazarPedido()
    {
        estado.Rechazar(this);
    }

    public void EntregarPedido()
    {
        estado.Entregar(this);
    }

    public void AgregarAPedidos(string pedido)
    {
        pedidos.Add(pedido);
    }

    public void RemoverDePedidos(string pedido)
    {
        pedidos.Remove(pedido);
    }
}