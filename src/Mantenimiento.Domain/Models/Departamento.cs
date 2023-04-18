using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
