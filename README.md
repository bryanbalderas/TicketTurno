# TicketTurno
Repositorio creado para colaborar en proyecto parcial 2 desarrollo web

Pasos a tomar en cuenta:
*Archivos importantes antes de correr el proyecto en tu maquina:

-Startup.cs

-appsettings.json

Antes de realizar cualquier cosa elimina los archivos en la carpeta Migrations y despues sigue los pasos a continuacion
 
En appsettings.json modificar el connectionstring ya que actualmente apunta a mi bd local, apuntalo a la tuya (recuerda que estamos usando sql server)

Para poder ingresar y traer datos recuerda usa primero los comandos:

1.- Add-Migration "migracion identity" -context TicketParcialDBContext

2.- Add-Migration "migracion ticket" -context TicketTurnoContext

3.- Update-Database -context TicketParcialDBContext

4.- Update-Database -context TicketTurnoContext

En ese orden para poder generar las migraciones de tu bd
