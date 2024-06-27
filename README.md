# APBD_5

In this task I used my a local ssms (microsoft sql server management studio)
If you want to run this task change the server in appsettings.json.

In the course of these exercises, a simple REST API application needs to be
developed, which enables operations allowing for the modification of data in
an SQL Server database.

Create the table in database according to the diagram below. Communication
with the database should occur through the SqlConnection/SqlCommand
classes.

![image](https://github.com/TomTomStudent/APBD_5/assets/127242186/8fa8588f-a78e-418a-abd4-20aa2be4350f)


Server data: db-mssql16.pjwstk.edu.pl

1. Add an Animals controller.
   
2. Add a method/endpoint that allows obtaining a list of animals. The
endpoint should respond to an HTTP GET request sent to /api/animals
  1. The endpoint should allow for a query string parameter that
  specifies sorting. The parameter is named orderBy. Example:
  api/animals?orderBy=name
  2. The parameter accepts the following values: name, description,
  category, area. Sorting can only be done by one column. The
  sorting is always in the "ascending" direction.
  3. Default sorting (when no parameter is passed in the query string)
  should be by the name column.

3. Add a method/endpoint allowing for the addition of a new animal. 
  1. The method should respond to an HTTP POST request sent to
  api/animals
  2. The method should accept data in JSON format.
     
4. Add a method/endpoint allowing for the update of data for a specific
animal.
  1. The method should respond to an HTTP PUT request sent to
  /api/animals/{idAnimal}
  2. The method accepts data in JSON format.
  3. It is assumed that primary keys do not change (IdAnimal column).
     
5. Add a method/endpoint for deleting data about a specific animal.
  1. The method should respond to an HTTP DELETE request sent to
  /api/animals/{idAnimal}

6. Remember about correct HTTP codes.
7. Try to use the built-in Dependency Injection mechanism.
8. Ensure data validation.
9. Pay attention to naming and style
