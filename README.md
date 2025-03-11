# Utils.ResponseProcessor

Servicio Para Manejo de Respuestas y Exepciones de uso generico para Apis, Retorna los estatus correspondientes a las excepciones incluidas en el paquete, pudiendo enmascarando un objeto de respuesta en la siguiente estructura de datos

```json
{
  "data": {}, // datos a retornar
  "message": "", // Mensaje de la Excepcion
  "guid": "XXXXXXXXXXXXXXXXXXXXXXX" // identificador de la operacion util en caso de usar ms-insigths
}
```

## Inicio Rapido 
Instale el paquete desde la consola o usando el adminitrador nuget integrado en su IDE
```sh
dotnet add package Danorjuela.Utils.ResponseProcessor 
```
## Agregar Servicio
En el archivo Program.cs agregue la linea 
```cs
builder.Services.AddResponseProcessorService();
```
## Ejemplo
Inyecte el Servicio en el controlador de su preferencia 
```cs
private readonly IResponseService _responseService;
public ExampleController(IResponseService responseService)
{
    _responseService = responseService;
}
[HttpGet]
public async Task<IActionResult> allAsync()
{
    try
    {
        // Respuesta sin enmascaramiento
        return Ok(await _servicioExample.get() );
        // respuesta enmascarada por defecto status 200
        return _responseService.ProcessResponse<ExampleDTO>(await _servicioExample.get());
        // respuesta enmascarada con un status especifico
        return _responseService.ProcessResponse<ExampleDTO>(await _servicioExample.get(),201);
    }
    catch (ExceptionCustom ex)
    {
         // Manejo de Excepciones con status especifico 
        return _responseService.ProcessException(ex, 404);
    }
    catch (Exception ex)
    {
        // Manejo de Excepciones con status predeterminados 
        return _responseService.ProcessException(ex);
    }
}
```
## Excepciones 
Puede lanzar cualquier excepcion desde cualquier lugar del codigo, (se retornara 500 para excepciones no incluidas en la siguiente tabla )
```cs
// lanza excepcion sin data
throw new NotFoundException("No Found Data");
// Lanza excepcion con datos
throw new ConflicException<ExampleDTO>("No Valid srm type" , new ExampleDTO());
```

Acontinuacion los estados retornados por cada excepcion 

| Clase   | Codigo Retonado | 
|-------------------|------------------|
| NoDataException   | 204 |
| ForbiddenException | 403 |
| InvalidOperationException | 400 |
| NotAutorizationException | 401 |
| NotFoundException | 404 |
| ConflicException | 409 |
| BusinessException | 418 |
| Otros | 500 |


## Licencia
Distribuido con licencia MIT