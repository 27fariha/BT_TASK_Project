.Net 6 for API Development. 
Angular 14 for Front-End.
SQLSERVER managment Studio for DB.


how to run Project:
1.dump db into your SQL server Studio.
2.run ng serve--o for angular .
3.befor running APi project run this command in console "Scaffold-DbContext "Data Source=NameOFYourSource;Initial Catalog=inventory_schema; Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models\DBMapping"
3.run visual studio 2022 for API .