# Library Management System (ASP.NET MVC)
A clean, modular, and fully functional Library Management System built with ASP.NET MVC, C#, and the Repository Pattern.
This project demonstrates strong separation of concerns, session‑based authentication, and full CRUD operations across Books, Readers, and Borrowings.

## Features
### Authentication
- Login system with session-based user tracking
- Dashboard displays the logged‑in user’s name
- Protected routes — only authenticated users can access the system
  
### Books Module
- View all books
- Add new books
- Edit existing books
- Delete books
- Track:
- Category
- Total Copies
- Available Copies

### Readers Module
- Full CRUD for library members
- Clean forms with validation
- Repository-backed data storage

### Borrowings Module
(Currently in progress)
- View all borrowings
- Next phase:
- Borrow book workflow
- Return book workflow
- Auto-update available copies
- Dropdowns for selecting books and readers

## Architecture
This project follows a clean, maintainable structure:
```
/Controllers
    BookController.cs
    ReaderController.cs
    BorrowingController.cs
    AccountController.cs

/Models
    Book.cs
    Reader.cs
    Borrowing.cs

/Repositories
    IBookRepository.cs
    BookRepository.cs
    IReaderRepository.cs
    ReaderRepository.cs
    IBorrowingRepository.cs
    BorrowingRepository.cs

/Views
    /Book
    /Reader
    /Borrowing
    /Account
    /Shared
```

### Repository Pattern
Each module uses an interface + implementation for clean data access.
### Dependency Injection
Repositories are registered as Scoped in Program.cs.
### MVC Separation
- Controllers handle logic
- Models represent data
- Views render UI

## Technologies Used
- ASP.NET Core MVC
- C#
- Razor Views
- Bootstrap 5
- Dependency Injection
- Session Management
- Repository Pattern

## Running the Project
- Clone the repository:
```
git clone https://github.com/yourusername/LibraryManagementSystem.git
```
- Open the project in Visual Studio or VS Code.
- Restore dependencies:
```
dotnet restore
```
- Run the application:
```
dotnet run
```
- Navigate to:
```
https://localhost:xxxx
```
- Log in and explore the Dashboard.

- Dashboard
  <img width="1910" height="525" alt="image" src="https://github.com/user-attachments/assets/5790f2ab-6520-4c6f-9206-6fd4d195875d" />

- Books Index
  <img width="1909" height="560" alt="image" src="https://github.com/user-attachments/assets/da29a9b3-c0f9-4126-8c74-a4a050885b2b" />

- Create/Edit/Delete pages
- Readers module
  <img width="1915" height="565" alt="image" src="https://github.com/user-attachments/assets/9040fe14-2382-431c-b8cf-7bbccc6561ec" />

- Borrowings module

### Future Enhancements
- Borrow/Return workflow
- Search and filtering
- Pagination
- Database integration (EF Core)
- User roles (Admin vs Staff)
- Activity logs

## Contributing
Pull requests are welcome.
For major changes, please open an issue first to discuss what you’d like to improve.

### License
This project is open-source and available under the MIT License.
