using System;

// Clase Program para probar el patrón
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Prueba del Patrón State con Singleton Perezoso - Sistema de Pedidos ===\n");

        // Crear un nuevo pedido
        Pedido pedido = new Pedido();
        Console.WriteLine($"Estado inicial: {pedido.GetEstado().GetNombre()}\n");

        // Verificar que los estados son singleton
        Console.WriteLine("--- Verificación Singleton ---");
        Console.WriteLine($"Ingresado instance 1: {Ingresado.GetInstance().GetHashCode()}");
        Console.WriteLine($"Ingresado instance 2: {Ingresado.GetInstance().GetHashCode()}");
        Console.WriteLine($"Son la misma instancia: {ReferenceEquals(Ingresado.GetInstance(), Ingresado.GetInstance())}\n");

        // Caso 1: Flujo normal - Ingresado -> Asignado -> Entregado
        Console.WriteLine("--- Caso 1: Flujo normal ---");
        Console.WriteLine("Asignando pedido...");
        pedido.AgregarPedido("Pizza Margherita", "Juan Pérez");
        Console.WriteLine($"Estado actual: {pedido.GetEstado().GetNombre()}");
        Console.WriteLine($"Es instancia singleton Asignado: {ReferenceEquals(pedido.GetEstado(), Asignado.GetInstance())}");
        
        Console.WriteLine("\nEntregando pedido...");
        pedido.EntregarPedido();
        Console.WriteLine($"Estado actual: {pedido.GetEstado().GetNombre()}");
        Console.WriteLine($"Es instancia singleton Entregado: {ReferenceEquals(pedido.GetEstado(), Entregado.GetInstance())}");
        
        Console.WriteLine($"Pedidos en la lista: {string.Join(", ", pedido.ListarInfo())}\n");

        // Caso 2: Cancelación desde Asignado
        Console.WriteLine("--- Caso 2: Cancelación desde Asignado ---");
        Pedido pedido2 = new Pedido();
        pedido2.AgregarPedido("Hamburguesa", "María García");
        Console.WriteLine($"Estado: {pedido2.GetEstado().GetNombre()}");
        
        Console.WriteLine("Cancelando pedido...");
        pedido2.CancelarPedido();
        Console.WriteLine($"Estado actual: {pedido2.GetEstado().GetNombre()}");
        Console.WriteLine($"Es instancia singleton Cancelado: {ReferenceEquals(pedido2.GetEstado(), Cancelado.GetInstance())}\n");

        // Caso 3: Intentar operaciones inválidas
        Console.WriteLine("--- Caso 3: Operaciones inválidas ---");
        Console.WriteLine("Intentando entregar pedido ya entregado:");
        pedido.EntregarPedido();
        
        Console.WriteLine("\nIntentando asignar pedido cancelado:");
        pedido2.AgregarPedido("Nuevo pedido", "Repartidor");
        
        Console.WriteLine("\n=== Fin de la prueba ===");
    }
}