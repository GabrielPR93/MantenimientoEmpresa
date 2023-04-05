using System.Threading.Tasks;

namespace Mantenimiento.Data;

public interface IMantenimientoDbSchemaMigrator
{
    Task MigrateAsync();
}
