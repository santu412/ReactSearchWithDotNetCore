This is a end-end functionality for the Rewards Search.

Backend:
This is the WEB API developed in .NET CORE 9.0 for this app to run end-end. we need to run this app in the terminal using 'dotnet run'. BE runs in port localhost: 5014

forntEnd:
This is the frontend developed WEB API  in React for this app to run end-end. we need to run this app in the terminal using 'npm run start'. FE runs in port localhost:3000

Swagger:
We have a swagger  URL: http://localhost:5014/Swagger/index.html

We are using the API end point of the BE in react FE. We also have the hardcoded values to fetch data in the react.
 But for that to work we have to delink the BE URL in the .env file and refer to the hard coded files.
