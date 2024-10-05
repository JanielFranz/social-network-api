# Social Network DS
## Summary
Social Network REST API, console app and test folder. 

## Features

Swagger UI   
ASP.NET Framework  
Entity Framework Core   
MySQL Database  
Hexagonal Architecture  
MsTest  

## Instructions  
You can use one of the three users: "@Alfonso", "@Ivan", or "@Alicia"

### Posting messages
- **Post example 1**:
  - Action: `post @Alfonso Hola Mundo`
  - Output: `Alfonso posted -> "Hola Mundo" @10:30`
  
- **Post example 2**:
  - Action: `post @Alfonso Adiós mundo cruel`
  - Output: `Alfonso posted -> "Adiós mundo cruel" @20:30`
  
- **Post example 3**:
  - Action: `post @Ivan Hoy puede ser un gran día`
  - Output: `Ivan posted -> "Hoy puede ser un gran día" @08:10`
  
- **Post example 4**:
  - Action: `post @Ivan Para casa ya, media jornada, 12h`
  - Output: `Ivan posted -> "Para casa ya, media jornada, 12h" @20:10`

### Following users
- **Follow example 1**:
  - Action: `follow @Alicia @Ivan`
  - Output: `"Alicia empezó a seguir a Ivan"`

- **Follow example 2**:
  - Action: `follow @Alicia @Fonso`
  - Output: `"No se encontró ningún usuario @Fonso"`

- **Follow example 3**:
  - Action: `follow @Alicia @Alfonso`
  - Output: `"Alicia empezó a seguir a Alfonso"`

### Dashboard
**Alicia can view the posts of her following users (in this case, Alfonso and Ivan) on her dashboard**

- Action: `dashboard @Alicia`
- Output:
  - `"Hoy puede ser un gran día" @Ivan @08:10`
  - `"Hola mundo" @Alfonso @10:30`
  - `"Para casa ya, media jornada, 12h" @Ivan @20:10`
  - `"Adiós mundo cruel" @Alfonso @20:30`
