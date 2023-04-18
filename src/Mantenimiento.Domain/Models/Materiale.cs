using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Materiale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Proveedore? Proveedor { get; set; }
}
