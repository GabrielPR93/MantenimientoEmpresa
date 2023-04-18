using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public int? DepartamentoId { get; set; }

    public int? EmpresaId { get; set; }

    public virtual ICollection<Acreditacione> Acreditaciones { get; set; } = new List<Acreditacione>();

    public virtual Departamento? Departamento { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
