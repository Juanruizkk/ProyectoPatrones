using System;
using System.Collections.Generic;

public class TipoPedido
{
    private int idTipoPedido;
    private string tipo;

    public int IdTipoPedido { get => idTipoPedido; set => idTipoPedido = value; }
    public string Tipo { get => tipo; set => tipo = value; }

    public TipoPedido(int id, string tipo)
    {
        this.IdTipoPedido = id;
        this.Tipo = tipo;
    }


    public string ListarInfo()
    {
        return $"ID Tipo Pedido: {IdTipoPedido}, Tipo: {Tipo}";
    }
}