using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? ProveedorId { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Proveedore? Proveedor { get; set; }
}
