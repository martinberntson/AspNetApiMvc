Just a few quick notes.
When running the IIS Express server, the username is 'guest' and the password is 'password'.
It's not meant to be safe, it was just me trying out basic authentication.
I considered implementing a better system but was running low on time with an exam approaching.

API instructions are available on the first page shown, and links to all other pages should be easy to find.

The project demonstrates:
- Use of ASP.NET to create both an API and MVC-style web pages for full CRUD functionality on three different types of objects -  Artists, Albums, and Tracks/Songs.
A quick note is that I did not implement certain types of validation, so even though tracks shouldn't be able to exist without their corresponding album, and deleting the album will delete the track, I didn't implement a check to make sure the reference ID was pointing to a valid album.
- SOLID principles, I've tried to follow them as best I can though it's probably not perfect.
- Names of classes and methods should clearly explain what they do in most cases.
- XML -> JSON conversion. The original database used was in XML, it is then converted to JSON for saving any changes made during use/testing.
- A single line has been commented out in Startup.Startup(); - letting this line run will read the database anew from the unmodified XML, restoring it to its initial state. Run this once to remove any changes made.

I had a few plans to do more in this project, things like adding JavaScript to automatically fill out forms when you've selected an ID for an object to modify, for example.
I may decide to go back to this in the future and update it with little features like that, but that will depend on too many factors to be able to make any certain statements.
