# 🏥 Pet Clinic Console App

A simple C# console application to **register customers and their pets**, manage basic information, and simulate veterinary services such as consultations and vaccinations.

---

## 🚀 Features
- Register customers and their pets through console input.
- List all registered customers and pets.
- Search for a customer by name.
- Input validation (no empty fields, only positive numbers for age/ID).
- Error handling using `try-catch`.
- Abstract veterinary service system with different types of care:
  - `GeneralConsultation`
  - `Vaccination`
- Interface `IRegistrable` implemented in both `customer` and `Pet`.

---

## 🗂️ Project Structure
pet_clinic/
│── models/
│ ├── customer.cs # customer model, implements IRegistrable
│ ├── Pet.cs # Pet model, implements IRegistrable
│ ├── Animal.cs # Extra model (optional)
│ └── IRegistrable.cs # Interface definition
│
│── services/
│ ├── customerService.cs # Handles customer registration, listing, and search
│ └── VeterinaryService.cs # Abstract class + subclasses (GeneralConsultation, Vaccination)
│
│── Program.cs # Entry point with console menu
│── pet_clinic.csproj
└── README.md

## ⚙️ Requirements
- .NET 8 SDK (or compatible)
- C# 11+ (for nullable features and better syntax)
- VS Code or Visual Studio

---

## ▶️ Running the Project
1. Clone or download this repository.
2. Navigate to the project folder:
   ```bash
   cd pet_clinic

   dotnet run


✅ Acceptance Criteria

Program compiles and runs without errors.

customers and pets can be registered and listed.

No empty or invalid input is allowed.

Information is stored in memory (collections).

Clear summary displayed after registration.

Abstract methods and interfaces are implemented correctly.



 Still Is in development