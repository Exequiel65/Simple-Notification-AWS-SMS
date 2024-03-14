# Simple Ejemplo de Aws SNS con .NET

Este proyecto es una API simple desarrollada en ASP.NET que incluye una implementación de ejemplo para el envío de mensajes SMS utilizando Amazon SNS. 

## Tecnologías Utilizadas

- .NET 8
- Docker

## Instalación

1. Clona el repositorio:

```
git clone https://github.com/tuusuario/tu-proyecto.git
```

2. Abre el archivo `appsettings.json` y agrega las siguientes credenciales de AWS y configuración del mensaje SMS:

```json
{
  "AwssmsMessageOptions": {
    "AwsAccessKeyId": "TuAccessKeyId",
    "AwsSecretAccessKeyId": "TuSecretAccessKeyId",
    "SystemName": "NombreDeTuSistema"
  }
}
```

3. Ejecuta el proyecto utilizando .NET CLI:
```
dotnet run
```

## Uso
La API proporciona endpoints para interactuar con el servicio de envío de mensajes SMS a través de Amazon SNS. Puedes acceder a la API desde cualquier cliente HTTP.

### Docker
Si prefieres ejecutar la API utilizando Docker, sigue estos pasos:

Asegúrate de tener Docker instalado en tu sistema.

Desde la raíz del proyecto, construye la imagen de Docker:
```
docker build -t nombre-de-la-imagen .
```
Ejecuta el contenedor:
```
docker run -p 5000:5000 nombre-de-la-imagen
```

## Contribución
Si quieres contribuir al proyecto, puedes enviar pull requests.

## Licencia
Este proyecto está bajo la licencia MIT. Ver el archivo LICENSE para más detalles.
