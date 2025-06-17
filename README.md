# Task Tracker CLI

Project source - [roadmap.sh](https://roadmap.sh/projects/task-tracker)  
Requirements - .NET 9

Task Tracker is a simple command-line interface (cli) application, designed for simple managing your tasks. You can add, delete, update and list your tasks with a simple commands. All tasks are stored in a JSON file, which you can configure with config command.

## Installation
*Warning: To run this app, you need to build it first, not just download (will be better in future).*

**1. Clone repository**
```bash
git clone https://github.com/ctznOScraft/Task_Tracker.git
```
**2. Navigate to clonned directory**
```bash
cd Task_Tracker
```
**3. Build app**
```bash
dotnet build -c Release -o ./<your_directory>
```
**4. Navigate to builded directory**
```bash
cd <your_directory>
```
**5. Run app**
```bash
./task-cli [command] [arguments]
```

## Usage

**1. "add" command**  
*adds task to the database*
```bash
./task-cli add <description>
```

**2. "delete" command**  
*deletes task from the database*
```bash
./task-cli delete <id>
```

**3. "update" command**  
*updates specified task*  
```bash
./task-cli update <id> <field> <new_value>
```
fields: description/status  
statuses: Todo/InProgress/Done  

**4. "list" command**  
*lists all or filtered tasks*  
```bash
task-cli update <filter>
```
filters (for now it's statuses): Todo/InProgress/Done  
if you won't specify a filter, it lists all tasks  

**5. "config" command**
*configures the app*
```bash
task-cli config <option> <value>
```
options (for now): dbname - sets the name for the database file
