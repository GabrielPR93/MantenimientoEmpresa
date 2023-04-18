using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Acreditacione
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime? FechaValidez { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
