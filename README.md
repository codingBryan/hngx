# hngx
Tasks repository
Here you, on the master branch, you will find the source code for the back-end stage one task.

The API is developed using asp.net core

To run this source code in your machine, make sure to have .net 7 framework(Standard Term Support).
cd into the project directory and run the command "dotnet watch run"  in your terminal


For stage 2 task

Testing
.net 7 Framework comes packaged with swaggerUI, a tool to test the endpoints with ease
To access swaggerUI for test purposes, go to the test endpoint: https://backendstepone.azurewebsites.net/swagger/index.html


Endpoints
1. POST https://backendstepone.azurewebsites.net/api
     Request Json body format is:  {"name":"Brian"}

     The response expected is a json object with the format: { "success":true, "message": "user created successfully" }
   
3. GET https://backendstepone.azurewebsites.net/api/1
     The response expected is a json object with the format: { "id":true, "message": "Brian" }
   
5. PUT https://backendstepone.azurewebsites.net/api/1
     Request Json body format is: { "name":"new_name" }
   
     The response expected is a json object with the format: { "success":true, "message": "user updated successfully" }
   
6. DELETE https://backendstepone.azurewebsites.net/api/{user_Id}
     The response expected is a json object with the format: { "success":true, "message": "user created successfully"}


