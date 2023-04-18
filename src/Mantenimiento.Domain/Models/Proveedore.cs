using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual ICollection<Materiale> Materiales { get; set; } = new List<Materiale>();
}
