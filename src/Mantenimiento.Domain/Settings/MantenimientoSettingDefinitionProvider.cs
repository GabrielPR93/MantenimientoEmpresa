using Volo.Abp.Settings;

namespace Mantenimiento.Settings;

public class MantenimientoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MantenimientoSettings.MySetting1));
    }
}
