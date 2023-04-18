using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
