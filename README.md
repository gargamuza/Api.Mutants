# Api.Mutants
Proyecto Test

Instrucciones para la ejecucion de la API

1- Desde swagger.

Acceder a la url del swagger de la api: https://apimutants.azurewebsites.net/swagger/index.html
Endpoints disponibles:
-POST /mutant

Determina si una cadena de DNA coincide con DNA mutante.
Request:
{
  "dna": [
    "string"
  ]
}

Response: 
200 Si coincide.
403 Si no.

-Get /stats

Devuelve las estadisticas del proceso de deteccion de DNA mutante.
Response
200
{
  "count_mutant_dna": 0,
  "count_human_dna": 0,
  "ratio": 0
}

2- Desde Postman
-POST https://apimutants.azurewebsites.net/mutant

-GET https://apimutants.azurewebsites.net/stats


