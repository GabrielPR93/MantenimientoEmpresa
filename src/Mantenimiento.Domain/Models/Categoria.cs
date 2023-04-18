using System;
using System.Collections.Generic;

namespace Mantenimiento.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
