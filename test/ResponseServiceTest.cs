using Danorjuela.Utils.ResponseProcessor.Exceptions;
using Danorjuela.Utils.ResponseProcessor.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Danorjuela.Utils.ResponseProcessor.Test;
[TestClass]
public class ResponseServiceTest
{

    readonly IServiceProvider _services = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
       .ConfigureServices((hostContext, services) =>
       {
           services.AddResponseProcessorService();

       }).Build().Services;




    [TestMethod]
    public void ProcessExceptionTest1()
    {
        // execute
        var service = _services.GetRequiredService<IResponseService>();
        try
        {
            throw new NotFoundException("Not Found Element");
        }
        catch (Exception ex)
        {
            var result =  service.ProcessResponse(ex);
            // Verify
            Assert.IsNotNull(result);




        }
    }


}
