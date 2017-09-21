Please follow below steps to setup the applications.

(1) 	Run all the scripts located in "Script" folder. Start from "JA Web DDL.sql" then several stored procedures.
(2) 	Setup the application in IIS pointing to "JABackendService" and "JAFrontendWeb". Provide necessary domain name for both.
  	For example - "http://www.jabackendservice.com" ,  "http://www.jaweb.com"
(3)	Ensure the connection string in "../JABackendService/Web.Config" is pointing to the desired database.
(4)	Access web service page in browser to ensure it is working. For example "http://www.jabackendservice.com/JAService.asmx".
(5)	Browse to the frontend web via the domain defined in IIS. For example "http://www.jaweb.com/Index.aspx"