using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Mantenimiento.Pages;

public class Index_Tests : MantenimientoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
