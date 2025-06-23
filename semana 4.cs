using System;
using System.Collections.Generic; // Se usa List<T> para colecciones

// --- Clase Paciente ---
public class Paciente
{
    public int Id { get; }                        // Tipo de dato entero (int) para identificar al paciente
    public string Nombre { get; }                 // Tipo string para almacenar nombres
    public string Apellido { get; }               // Tipo string para apellidos
    public DateTime FechaNacimiento { get; }      // Tipo DateTime para representar fechas
    public string Telefono { get; }               // Tipo string para el número telefónico

    // Constructor con parámetros
    public Paciente(int id, string nombre, string apellido, DateTime fechaNacimiento, string telefono) =>
        (Id, Nombre, Apellido, FechaNacimiento, Telefono) = (id, nombre, apellido, fechaNacimiento, telefono);

    public void MostrarDatos() =>
        Console.WriteLine($"ID: {Id}, Nombre: {Nombre} {Apellido}, Nacimiento: {FechaNacimiento:dd/MM/yyyy}, Tel: {Telefono}");
}

// --- Clase Turno ---
public class Turno
{
    public int Id { get; }                        // int: identificador único del turno
    public DateTime Fecha { get; set; }           // DateTime: fecha del turno
    public TimeSpan Hora { get; set; }            // TimeSpan: representa la hora exacta (hora:minuto)
    public Paciente Paciente { get; }             // Objeto de tipo Paciente (relación entre clases)
    public string Medico { get; set; }            // string: nombre del médico
    public string Motivo { get; set; }            // string: motivo del turno

    public Turno(int id, DateTime fecha, TimeSpan hora, Paciente paciente, string medico, string motivo) =>
        (Id, Fecha, Hora, Paciente, Medico, Motivo) = (id, fecha, hora, paciente, medico, motivo);

    public void Mostrar() =>
        Console.WriteLine($"\nTurno #{Id} | {Fecha:dd/MM/yyyy} {Hora:hh\\:mm} | Médico: {Medico} | Motivo: {Motivo}\nPaciente: {Paciente.Nombre} {Paciente.Apellido}");
}

// --- Clase AgendaTurnos ---
public class AgendaTurnos
{
    private List<Turno> turnos = new();           // Lista (List<Turno>) para almacenar los turnos
    private int idTurno = 1, idPaciente = 1;       // int: contadores para generar IDs automáticos

    public Paciente RegistrarPaciente(string nombre, string apellido, DateTime nacimiento, string telefono) =>
        new(idPaciente++, nombre, apellido, nacimiento, telefono); // Crea nuevo paciente con tipos string y DateTime

    public void AgregarTurno(DateTime fecha, TimeSpan hora, Paciente paciente, string medico, string motivo) =>
        turnos.Add(new Turno(idTurno++, fecha, hora, paciente, medico, motivo)); // Uso de DateTime, TimeSpan, string

    public void MostrarTurno(int id) =>
        turnos.Find(t => t.Id == id)?.Mostrar() ?? Console.WriteLine($"Turno ID {id} no encontrado."); // int: ID

    public void ModificarTurno(int id, DateTime? fecha = null, TimeSpan? hora = null, string medico = null, string motivo = null)
    {
        var t = turnos.Find(x => x.Id == id); // int: ID de turno
        if (t == null) { Console.WriteLine($"No encontrado: Turno ID {id}"); return; }
        if (fecha != null) t.Fecha = fecha.Value;
        if (hora != null) t.Hora = hora.Value;
        if (medico != null) t.Medico = medico;
        if (motivo != null) t.Motivo = motivo;
    }

    public void CancelarTurno(int id)
    {
        var eliminado = turnos.RemoveAll(t => t.Id == id) > 0; // int: ID del turno a cancelar
        Console.WriteLine(eliminado ? $"Cancelado Turno ID {id}" : $"Turno ID {id} no encontrado.");
    }

    public void MostrarTodos() => turnos.ForEach(t => t.Mostrar());

    public void MostrarPorFecha(DateTime fecha) => turnos.FindAll(t => t.Fecha.Date == fecha.Date).ForEach(t => t.Mostrar());

    public void MostrarPorPaciente(int idPaciente) => turnos.FindAll(t => t.Paciente.Id == idPaciente).ForEach(t => t.Mostrar());
}

// --- Clase Principal ---
class Program
{
    static void Main()
    {
        var agenda = new AgendaTurnos();

        // Crear objetos Paciente con tipos string, DateTime, int
        var p1 = agenda.RegistrarPaciente("Juan", "Pérez", new DateTime(1980, 5, 15), "0981234567");
        var p2 = agenda.RegistrarPaciente("María", "García", new DateTime(1992, 11, 22), "0997654321");

        // Agregar Turnos (DateTime, TimeSpan, string)
        agenda.AgregarTurno(new DateTime(2025, 7, 10), new TimeSpan(10, 0, 0), p1, "Dr. López", "Control");
        agenda.AgregarTurno(new DateTime(2025, 7, 10), new TimeSpan(11, 30, 0), p2, "Dra. Rodríguez", "Dolor");
        agenda.AgregarTurno(new DateTime(2025, 7, 12), new TimeSpan(9, 0, 0), p1, "Dr. Pérez", "Chequeo");

        agenda.MostrarTodos();                     // Muestra todos los turnos
        agenda.MostrarTurno(1);                    // int: muestra un turno específico
        agenda.MostrarPorFecha(new DateTime(2025, 7, 10)); // DateTime: consulta por fecha
        agenda.MostrarPorPaciente(p1.Id);          // int: consulta por ID de paciente

        // Modificación y cancelación de turnos usando tipos opcionales
        agenda.ModificarTurno(2, nuevaHora: new TimeSpan(12, 0, 0), medico: "Dra. Ana");
        agenda.MostrarTurno(2);
        agenda.CancelarTurno(3);
        agenda.MostrarTodos();
    }
}
