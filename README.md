# CRUDSampleWinForms
**This is just an improved CRUD functions using WinForms and MS SQL Server using SQL parameters and configuration management. Created with .NET 8 and MSSQL v20. This includes a simple error try and catch and does not include dependency injection and does not use MVVM format. This is just for beginner's practice guide!**

Please check out my [simple-crud-winform-mssql](https://github.com/CheskaAbarro/simple-crud-winform-mssqql/tree/master) repository for a much simpler CRUD operations. I suggest you run and study the given link before studying this improvements. 

### Setting up and important parts 
**Step 1: Set up your database in MS SQL Server**
Database details: 
```
Database: CRUDWinForms
Table: tbl_Sensor
Table contents: ID(int, Identity Specification:Yes), SensorName(varchar 50), SensorType(varchar 50)
```
Note: You can decide if you want to create this database with query or not.


**Step 2: Create a configuration**
Right click on your project solution and click "Add new item". Then, under C# itemns, click "Data" and choose an XML file. Rename the XML file to "App.config" (not App.config.xml)
![image](https://github.com/user-attachments/assets/ba5399d7-c4b4-4d01-8dd3-cdc3567f1e06)

In App.config, contains the following:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>

	<connectionStrings>
		<add name="SensorConnectionString" connectionString="Data Source=SERVERNAME;Initial Catalog=CRUDWinForms;Integrated Security=True;TrustServerCertificate=True"
			 providerName="System.Data.SqlClient"/>
	</connectionStrings>
	
</configuration>
```
Instead of directly coding the connection string on each behind-code, you can set up a configuration where the connection string can be accessible anywhere in the project.


**Step 3: Establish connection in your code**
Install a NuGet package: ***Microsoft.Data.SqlClient***.
Then, establish connection between visual studio and MS SQL. 
In your behind-code, you can call your connection string using the following:
```
 string connectionString = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
```
Setting up application configuration also make maintenance easier, and the following:
- Code organization: It can also organize your code where all of the connection strings can be added and be used anywhere in the project.
- Source Code Security: By not embedding sensitive information like connection strings directly in the code, you minimize the risk of exposing this information in source code repositories.
- Shared Settings: If you have multiple projects in a solution, you can have shared configurations, reducing duplication and potential for mismatched settings.
- Deployment Simplicity:  App.config can be modified without changing the application itself, allowing you to adapt to new environments or settings quickly.
- Best practice: Using App.config is a best practice in .NET development for managing application settings, promoting a standard approach across different projects and teams.


**Step 4: SQL Parameters**
Implementing SQL queries directly in your codes can be be prone to SQL injection. SQL injection is a code injection technique that exploits vulnerabilities in an application's software by inserting malicious SQL statements into an input field for execution by the backend database. This can allow attackers to perform unauthorized actions, such as accessing, modifying, or deleting data from the database.

Sample of direct query in codes:
```
string sqlQuery = "INSERT INTO CRUD_Basic (Name, Age) VALUES (" + "'" + txtName.Text + "'" + "," + "'" + txtAge.Text + "'" + ")";
```
Thus, using SQL injection helps avoid SQL injection in your future applications. Please see the codes in Form.cs for the full codes. 

Snipet of SQL parameters use:
```
string sqlQuery = "INSERT INTO tbl_Sensor (SensorName, SensorType) VALUES (@sensorname, @sensortype)";

var sensorNameParameter = new SqlParameter("sensorname", System.Data.SqlDbType.VarChar);
sensorNameParameter.Value = txtSensorName.Text;
cmd.Parameters.Add(sensorNameParameter);

var sensorTypeParameter = new SqlParameter("sensortype", System.Data.SqlDbType.VarChar);
sensorTypeParameter.Value = txtSensorType.Text;
cmd.Parameters.Add(sensorTypeParameter);
```

![image](https://github.com/user-attachments/assets/32b91603-7ba4-41e8-871d-13ea5e8b78ec)


**Tip: Read all the comments and try to debug line by line in order to study it better.**

### If you encounter an error, please leave a comment of your error and I will try to answer as soon as possible. 
### Happy learning!
