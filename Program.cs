using System;

// Clase Program para probar todos los patrones
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Prueba del Sistema Completo de Pedidos ===\n");

        // Crear un pedido completo
        Pedido pedido = new Pedido();
        Console.WriteLine($"Estado inicial: {pedido.Estado.GetNombre()}\n");

        // Verificar que los estados son singleton
        Console.WriteLine("--- Verificación Singleton ---");
        Console.WriteLine($"Ingresado instance 1: {Ingresado.GetInstance().GetHashCode()}");
        Console.WriteLine($"Ingresado instance 2: {Ingresado.GetInstance().GetHashCode()}");
        Console.WriteLine($"Son la misma instancia: {ReferenceEquals(Ingresado.GetInstance(), Ingresado.GetInstance())}\n");

        // Caso 1: Flujo normal - Ingresado -> Asignado -> Entregado
        Console.WriteLine("--- Caso 1: Flujo normal ---");
        Console.WriteLine("Asignando pedido...");
        pedido.AgregarPedido("Pizza Margherita", "Juan Pérez");
        Console.WriteLine($"Estado actual: {pedido.Estado.GetNombre()}");
        
        Console.WriteLine("\nEntregando pedido...");
        pedido.EntregarPedido();
        Console.WriteLine($"Estado actual: {pedido.Estado.GetNombre()}");
        
        Console.WriteLine("Información del pedido:");
        pedido.ListarInfo();

        // Caso 2: Cancelación desde Asignado
        Console.WriteLine("\n--- Caso 2: Cancelación desde Asignado ---");
        Pedido pedido2 = new Pedido();
        pedido2.AgregarPedido("Hamburguesa", "María García");
        Console.WriteLine($"Estado: {pedido2.Estado.GetNombre()}");
        
        Console.WriteLine("Cancelando pedido...");
        pedido2.CancelarPedido();
        Console.WriteLine($"Estado actual: {pedido2.Estado.GetNombre()}\n");

        // Caso 3: Intentar operaciones inválidas
        Console.WriteLine("--- Caso 3: Operaciones inválidas ---");
        Console.WriteLine("Intentando entregar pedido ya entregado:");
        pedido.EntregarPedido();
        
        Console.WriteLine("\nIntentando asignar pedido cancelado:");
        pedido2.AgregarPedido("Nuevo pedido", "Repartidor");
        
        Console.WriteLine("\n=== Fin de la prueba ===");
        
        Console.WriteLine("\n" + new string('=', 60) + "\n");
        
        // Prueba del patrón Chain of Responsibility (Verificadores)
        PruebaVerificador.PruebaVerificacion();
    }
}