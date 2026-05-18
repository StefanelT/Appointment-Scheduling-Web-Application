# 💈 BarberShop

A web platform for scheduling and managing barber shop appointments.

## Features

- Dynamic appointments list sorted chronologically (soonest appointments first)
- Add new appointments with data validation (client name and date required)
- Date restrictions preventing appointments on past dates
- Edit existing appointments using an interactive modal pop-up window
- Dynamic error alerts inside the modal if the chosen time slot is taken
- Cancel/Delete appointments with a safety confirmation prompt

## Tech Stack

**Frontend (Web Client)**
- HTML, CSS, JavaScript
- ASP.NET WebForms

**Backend (Server)**
- C# (.NET Framework)
- ASP.NET Web Services
- SQL Server LocalDB

## How to Run

### Backend & Frontend (Simultaneous)
1. Open the solution file `.sln` in **Visual Studio**.
2. Right-click the Solution -> **Properties** -> **Startup Project**.
3. Select **Multiple startup projects** and set both `FrizerServer` and `FrizerieWebClient` to **Start**.
4. Press **F5** or click **Start** to run the integrated environment.
*Note: The database connection automatically maps to any local path using the `|DataDirectory|` macro.*

## ASMX Web Service Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetToateProgramarile` | `List<ModelProgramare>` | Retrieves all appointments sorted by date |
| `AdaugaInDB` | `string` | Validates and inserts a new appointment |
| `ModificaProgramare` | `string` | Updates an appointment (validates slot availability) |
| `StergeProgramare` | `string` | Permanently deletes a specific appointment by ID |

## Project Structure

```text
Frizerie/
├── FrizerServer/                  
│   ├── App_Data/
│   │   └── FrizerieDataBase.mdf   # SQL Server Database
│   ├── ModelProgramare.cs         # Data Object Model
│   ├── ProgramariService.asmx     # SOAP API Endpoint
│   └── web.config                 # Server Configuration
│
├── FrizerieWebClient/             # Frontend Web Application
│   ├── Connected Services/        # Web Reference Proxy (FrizerieRef)
│   ├── Site.Master                # Layout Template
│   ├── SiteMaster.css             # Main stylesheet & Table layout
│   ├── Adauga.aspx                # New Appointment View & Logic
│   └── Lista.aspx                 # GridView, Modal Pop-up & Actions
│
├── .gitignore                     
└── Frizerie.sln                   
