# Application Overview

This repository contains an application that handles various user management tasks with a focus on performance, thread safety, and security. The system uses asynchronous programming with `async`/`await`, exception handling with `try-catch`, and thread safety with `SemaphoreSlim` to ensure smooth operation and responsiveness, especially in scenarios that involve database interaction.

## Features & Functionality

### 1. LOGIN
- **Functionality:** This function handles user authentication by verifying the credentials entered by the user (username and PIN).
- **How it works:**
  - Compares the entered credentials against the database. The password is hashed using `BCrypt.Net.BCrypt.EnhancedVerify` for comparison.
  - If credentials are valid, the user is directed to either the Admin or User page.
  - **Validations:** Ensures the username and PIN are not empty or contain whitespace. Appropriate error messages are displayed for invalid input.
  - **Async-Await:** Uses asynchronous methods to interact with the database to prevent UI freezing and to keep the main thread responsive.
  - **Try-Catch:** Handles potential exceptions (e.g., incorrect credentials or database connection errors) to ensure smooth user experience.

### 2. MINI STATEMENT
- **Functionality:** Retrieves a user's transaction history and displays it in a grid.
- **How it works:**
  - Asynchronously fetches transaction data from the database using the `getBalanceFromDb` stored procedure.
  - The method ensures that the UI thread is not blocked while waiting for the database query to complete.
  - **UI Thread Safety:** Updates the UI thread using `Invoke` to ensure thread safety when displaying the results.
  - **Async-Await:** Maintains a responsive interface by fetching data asynchronously.

### 3. CHECK BALANCE
- **Functionality:** Retrieves the balance for a given user from the database.
- **How it works:**
  - A connection to the database is established, and the balance is fetched based on the provided user ID.
  - If the user ID is invalid or there is an error, an exception is caught and an error message is displayed.
  - **Async-Await:** Performs the database query asynchronously to prevent blocking the UI thread.

### 4. CHANGE PIN
- **Functionality:** Updates a user’s PIN in the database, ensuring it is securely stored.
- **How it works:**
  - Validates that the new PIN and confirmation PIN are identical, non-empty, and consist of exactly 4 digits.
  - The PIN is hashed using `BCrypt.Net.BCrypt.EnhancedHashPassword` before storing it in the database.
  - **Thread Safety:**
    - **SemaphoreSlim:** Prevents race conditions by allowing only one thread to perform the PIN update at a time.
    - Ensures consistent data by preventing multiple threads from simultaneously updating the PIN for the same user.

### 5. ADD ROLE
- **Functionality:** Adds a new role to the database while ensuring role names are unique.
- **How it works:**
  - Before inserting, it checks if the role already exists, treating case-insensitive duplicates (e.g., "Admin" and "admin") as the same.
  - **SemaphoreSlim:** Ensures that only one thread can add a role at a time, preventing the insertion of duplicate roles.
  - **Async-Await:** Performs the operation asynchronously to avoid blocking the UI thread.

### 6. ADD USER
- **Functionality:** Admins can add new users to the system.
- **How it works:**
  - Validations are performed to ensure the following:
    - Username is not empty or already taken.
    - PIN is a 4-digit integer.
    - Balance is a positive decimal number.
    - A valid role is selected.
  - The `adduser` stored procedure is used to insert new user data into the database.
  - **SemaphoreSlim:** Prevents race conditions by allowing only one thread to add a user at a time.
  - **Async-Await:** Ensures non-blocking operations, keeping the UI responsive during the process.

### 7. DELETE USER
- **Functionality:** Soft deletes a user by marking the `isDeleted` field as `true`.
- **How it works:**
  - Executes a `DELETE` operation via the `DeleteUserByUsername` stored procedure, flagging the user as deleted without physically removing their data.
  - **SemaphoreSlim:** Ensures that only one delete operation occurs at a time, maintaining consistency and avoiding potential race conditions.
  - **Async-Await:** The deletion is performed asynchronously to prevent UI blocking.

---

## Key Concepts

### GENERAL THREAD SAFETY WITH SemaphoreSlim
- **Purpose:** Ensures that critical sections of code are executed by only one thread at a time, preventing race conditions.
- **How it works:**
  - `SemaphoreSlim` allows only one thread to enter a specific code section by calling `WaitAsync()` before entering and `Release()` after completing the operation.
  - This prevents issues where multiple threads could attempt to update or delete the same data concurrently, which could lead to data corruption.

### EXCEPTION HANDLING WITH TRY-CATCH
- **Purpose:** Ensures that errors occurring during database operations, user input validation, or threading issues are handled gracefully.
- **How it works:**
  - Encloses potentially error-prone operations (like database queries or file I/O) in `try-catch` blocks.
  - In case of failure (e.g., network issues or invalid SQL queries), the system catches the error and displays an appropriate message to the user, preventing the application from crashing.

### ASYNC-AWAIT FOR PERFORMANCE
- **Purpose:** Asynchronous programming is used to enhance performance by preventing UI blocking, especially during long-running database operations.
- **How it works:**
  - Database queries and long-running tasks are performed asynchronously using `async` methods and `await`, allowing the UI to remain responsive while waiting for these tasks to complete.

---

## How to Run
1. Ensure that the database is set up and contains the necessary tables and stored procedures (e.g., `getBalanceFromDb`, `adduser`, `DeleteUserByUsername`).
2. Configure the connection strings and settings required for database access in the application.
3. Compile and run the application. The UI will remain responsive during operations like checking balance, changing PIN, adding users, etc., due to asynchronous programming.

---

## Conclusion

This application uses a combination of asynchronous programming, stored procedures, and thread safety mechanisms (like `SemaphoreSlim`) to provide a seamless, responsive, and secure user experience. Whether handling user authentication, managing user roles, or performing database transactions, the app ensures efficient and safe operation through the use of modern programming practices.

