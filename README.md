# hngx
Tasks repository
Here you, on the master branch, you will find the source code for the back-end stage one task.

The API is developed using asp.net core

To run this source code in your machine, make sure to have .net 7 framework(Standard Term Support) installed in your machine.

cd into the project directory and run the command "dotnet watch run"  in your terminal to run the application.


For stage 2 task

# Testing

.net 7 Framework comes packaged with swaggerUI, a tool to test the endpoints with ease
To access swaggerUI for test purposes, go to the test endpoint: https://backendstepone.azurewebsites.net/swagger/index.html


# Endpoints usage and sample data
# 1. POST https://backendstepone.azurewebsites.net/api
   
     Request Json body format is:  {"name":"Brian"}

     The response expected is a json object with the format: { "success":true, "message": "user created successfully" }
   
# 2. GET https://backendstepone.azurewebsites.net/api/1
   
     The response expected is a json object with the format: { "id":true, "message": "Brian" }
   
# 3. PUT https://backendstepone.azurewebsites.net/api/1

     Request Json body format is: { "name":"new_name" }
   
     The response expected is a json object with the format: { "success":true, "message": "user updated successfully" }
   
# 4. DELETE https://backendstepone.azurewebsites.net/api/{user_Id}
     The response expected is a json object with the format: { "success":true, "message": "user created successfully"}

## Design Documents

# 1.Datababase design ER diagram link : 
https://lucid.app/lucidchart/044f62b0-74e1-4f58-82c1-1d0e3d4c52e3/edit?invitationId=inv_0836a381-1939-4e71-b44a-393e9e39ee6b&page=0_0#
# 2.UML Class diagram link :
https://lucid.app/lucidchart/8d5828d6-9148-47b3-9c86-e95731a10b2f/edit?beaconFlowId=E5194CC01B6C262A&invitationId=inv_5924091e-1b59-4ec2-be48-8e98d36713b2&page=HWEp-vi-RSFO#



