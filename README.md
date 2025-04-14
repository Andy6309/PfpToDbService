# PFP to Database Service

## Overview

The PFP to Database Service is a lightweight .NET 9 application designed to parse `.pfp` files, extract their information, and store it in a Microsoft SQL Express database. *The application can run as a service or a console application*, providing flexibility for various deployment scenarios.

## Features

- Monitors configured folders (including network-shared folders) for new or modified `.pfp` files.
- Parses `.pfp` files into structured data.
- Stores parsed data into a Microsoft SQL Express database.
- Detects and updates records if `.pfp` files are modified.
- Detects if files are removed from folders and udpates SQL database accordingly.
- Processes unhandled files on application startup.

## Prerequisites

- **Microsoft SQL Express** installed and configured.
- **Database Table**: A table named `PfpData` must exist in the target database.
  - **For new databases:** Create the table using the SQL script provided below or from the file `create_pfpdata_table.sql` in the repository.
  - **For existing databases:** If the table already exists but does not include the latest fields, apply the provided update script to alter the table.
- Access to folders containing `.pfp` files (can include network-shared folders).

## Creating or Updating the Database

### Creating a New `PfpData` Table

If you are setting up the database for the first time, run the following SQL script to create the `PfpData` table:

```sql
CREATE TABLE PfpData (
    FilePath NVARCHAR(255) NOT NULL PRIMARY KEY,
    FileName NVARCHAR(255) NOT NULL,
    FileHash NVARCHAR(255) NOT NULL,
    FileLastModified DATETIME NOT NULL,
    LastUpdatedTimestamp DATETIME NOT NULL,
    PartName NVARCHAR(255) NOT NULL,
    BendingMachineName NVARCHAR(255) NOT NULL,
    UBC BIT NOT NULL,
    ASP BIT NOT NULL,
    AUT BIT NOT NULL,
    Tested BIT NOT NULL,
    PanelBendable BIT NOT NULL
);
```

### Updating an Existing `PfpData` Table

If the `PfpData` table already exists but you need to add the `PanelBendable` column (or ensure it has the correct default value), run the following SQL command:

```sql
ALTER TABLE PfpData
ADD PanelBendable BIT NOT NULL DEFAULT 0;
```

> **Note:**
>
> - If the `PanelBendable` column already exists in your table, you do not need to run the ALTER TABLE command.
> - Always back up your database before making schema changes.

## Usage

- **Startup**: On startup, the application scans the configured folder(s) for `.pfp` files, parses them, and updates the database if necessary.

- **Continuous Monitoring**: The application monitors the folder(s) for new or modified `.pfp` files and processes them automatically.

- **Running as a Service using NSSM**: When deploying the application as a Windows service, it is recommended to use [NSSM (the Non-Sucking Service Manager)](https://nssm.cc/). NSSM simplifies the process of running the application as a service. Follow these general steps:

  1. **Download and Install NSSM**: Download NSSM from the official website and extract it.

  2. **Install the Service**: Open a command prompt with administrative privileges and run a command similar to the following:

     ```batch
     nssm install "PFPToDatabaseService" "C:\Path\To\PfpToDatabaseService.exe"
     ```

  3. **Configure Service Settings**: NSSM provides a GUI where you can configure details like the working directory, startup parameters, and recovery options.

  4. **Start the Service**: Once configured, start the service using the Windows Services console or via the command line:

     ```batch
     net start PFPToDatabaseService
     ```

  NSSM helps ensure that the application runs reliably in a service context and can automatically restart in case of failures.

## File Parsing Details

The following properties are parsed from each `.pfp` file and stored in the database:

```csharp
• Part name [string]
• Bending machine name [string]
• Bending program filepath [string]
• UBC [ON/OFF]
• ASP [ON/OFF]
• AUT [ON/OFF]
• Tested [ON/OFF]
• Panel Bendable [TRUE/FALSE]
```

## Database Integration

- The application uses a Microsoft SQL Express database to store parsed `.pfp` data.
- Ensure the connection string in `appsettings.json` points to a valid SQL Express instance.
- Tables are created manually. You can use the SQL commands above or refer to the `sql_command.sql` file in the repository for commands.

## Configuration

All configuration is handled through `appsettings.json`. Example configuration:

```json
{
  "FileMonitoring": {
    "Folders": [
      {
        "Path": "C:\\PfpFiles\\PfpOk",
        "PanelBendable": true
      },
      {
        "Path": "C:\\PfpFiles\\PfpErrors",
        "PanelBendable": false
      }
    ]
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=NCXDB;User ID=sa;Password=YourStrongPassword!;Encrypt=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

---

By following these instructions, you can ensure that your database is correctly set up or updated and that the PFP to Database Service runs smoothly, whether executed from the console or deployed as a Windows service using NSSM.

