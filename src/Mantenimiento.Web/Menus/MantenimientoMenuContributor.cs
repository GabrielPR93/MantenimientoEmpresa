using System.Threading.Tasks;
using Mantenimiento.Localization;
using Mantenimiento.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Mantenimiento.Web.Menus;

public class MantenimientoMenuContributor : IMenuContributor
{
    private CurrentUser _currentUser;
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<MantenimientoResource>();

        var currentUser = context.ServiceProvider.GetService(typeof(ICurrentUser)) as ICurrentUser;

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MantenimientoMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (currentUser.Id != null)
        {

            context.Menu.AddItem(
                   new ApplicationMenuItem("Mantenimiento.Empleados", l["Empleados"], icon: "fas fa-users")

                       .AddItem(new ApplicationMenuItem(
                           name: " Acreditaciones",
                           displayName: l[" Acreditaciones"],
                           url: "/crm/customers")
                       )
                     );

            context.Menu.AddItem(
                  new ApplicationMenuItem("Mantenimiento.Empresas", l["Empresas"], icon: "fas fa-building")
                   .AddItem(new ApplicationMenuItem(
                           name: " Proveedores",
                           displayName: l[" Proveedores"],
                           url: "/crm/customers")
                       )
              );

            context.Menu.AddItem(
               new ApplicationMenuItem("Mantenimiento.Gestion", l["Gestion"], icon: "fas fa-tools")
                   .AddItem(new ApplicationMenuItem(
                       name: " Categorias",
                       displayName: l[" Categorias"],
                       url: "/crm/customers")
                   ).AddItem(new ApplicationMenuItem(
                        name: " Departamentos",
                        displayName: l[" Departamentos"],
                        url: "/crm/customers")
                    )
           );

            context.Menu.AddItem(
          new ApplicationMenuItem("Mantenimiento.Equipos", l["Equipos"], icon: "fas fa-desktop")

           .AddItem(new ApplicationMenuItem(
                           name: " Materiales",
                           displayName: l[" Materiales"],
                           url: "/crm/customers")
                       )
           );



        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
