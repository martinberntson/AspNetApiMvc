# AspNetApiMvc

A combined API and MVC project made with ASP.NET with full CRUD functionality for three connected object types.

Artists have albums which have tracks.

in Startup.Startup() the line "Services.XmlToJsonConverter.CreateJsonDatabaseFromXml();" resets the database from an XML backup.
Make sure it is commented out if you want changes to be saved between runs, or that it's not if you want to reset the database.
