# Demo PostgreSQL con netcore - Api de Libros (Books)

## Funcionalidades

* Listar todos los libros
* Listar libro por titulo 
* Insertar libro

## Requerimientos de Instalación

### Postgresql y PgAdmin en windows - Descargar ultima versión estable.

https://www.postgresql.org/download/windows/


### Ejecución de scripts de la base de datos

Ejecutar los siguientes scripts que se encuentran en **ApiPostgreSQL/Scripts**, en el orden que se deja indicado:

* createdb.sql
* create_book_table.sql

### Paquetes nuget en proyecto ApiPostgresql - Ya instalados

* Dapper
* Npgsql


### Paquetes nuget en proyecto ApiPostgresql - Ya instalados

* Newtonsoft.Json
* Swashbuckle.AspNetCore
* Swashbuckle.AspNetCore.Annotations

### Ejecutar:

https://localhost:44398/swagger/index.html


## Referencias

* https://www.c-sharpcorner.com/article/getting-started-with-postgresql-using-dapper-in-net-core/
* https://dotnetcoretutorials.com/2020/07/11/dapper-with-mysql-postgresql-on-net-core/
* **Daper vs EntityFramework**: https://codewithmukesh.com/blog/using-entity-framework-core-and-dapper/


