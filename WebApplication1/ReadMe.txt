***************************************************************************
				README FOR PROG7311 POE
***************************************************************************
Welcome to the Farm Central Stock Manager Web Application. 
This document will guide you through the basics as well as covering 
navigation and functionality.

The web application is broken into 2 main users: Employee and Farmer 

This document will first cover the Employee functionality. 
***************************************************************************

			       FUNCTIONS FOR EMPLOYEE 
****************************************************************************
				   Login As Employee
_________________________________________________________________________
-> The first page upon launching the web application takes you to the 
Login as an Employee page
-> As the name suggests, this login page is strictly for employees. 
   Attempting to Login to the Employee Page with a Farmer account or with        
incorrect credentials will present you with a friendly message stating that the
information that's been entered isn't valid.
-> If your data is valid, you can press login and proceed to the next page
-> If you don't have an Employee account, you can create one by clicking on
the Create User link
____________________________________________________________________________
					Create User
____________________________________________________________________________
-> This page is for new employees who need an account to access the web
   application.
-> Here you will need to enter the appropriate employee information including 
   email, password, employee name, and current position.
-> Once you have entered in the appropriate information, you can press Create
   and you will be redirected to the login page
-> If a field is empty or contains the incorrect data type, an appropriate
   error message will appear 
__________________________________________________________________________
				  Employee Home Page
__________________________________________________________________________
->This is the home page for the employee where they will decide which task
they would like to tackle upon logging in.
->These tasks are:
*Adding Farmers, where you can add farmers to the database so that they can 
access the site and use its features 
*Search Farmer Products using ID, allows employees to easily filter and 
search Products table using the FarmerID as a search field
*Search Farmer Products using Date Range, allows you to find the product 
of a specifc farmer using their FarmerID, and create a date range to see 
if the farmer added their item within a given timeframe 

			        *Adding Farmers*
-> This page allows you to add farmers to the database when clicking the Create                     	
New link at the top.
-> Once clicked, you'll be able to fill in the necessary and required data fields
   so that farmers can be added to the database 
-> Once added, they will appear on the list, giving you 3 more options to 
choose from. 
These are Edit, Delete, and Details. 
-> Edit allows you to update fields of a particular entry, Delete removes a 
Farmer Account, and Details is a more detailed view of a particular account.
-> Beneath the Create link is a navigation link to take you back to the main page.

		        *Search Farmer Products using ID*
-> This page contains a textbox, a button, and a list. 
-> The textbox requires the FarmerID of a parituclar farmer so that only their
items can be shown to the employee while excluding other farmers
-> If the FarmerID is valid, that particular farmer's items will display on the list 
->If its invalid, an appropirate error message will display
->A link is provided beneath the textbox so that you may return to the home page
					
		*Search Farmer Products using Date Range and ID*
-> The final page for Employees allows you to search for a particular farmer's
products while using two dates to create a Date Range
-> There's a textbox, 2 calendars, a button, and a list to show the filtered 
items
-> If the FarmerID is valid, and the products fall within the date range, 
they will be displayed on the list
->If its invalid, an appropirate error message will display
->A link is provided beneath the textbox so that you may return to the home page

_________________________________________________________________________________
*******************************************************************************

			       FUNCTIONS FOR FARMER 
*******************************************************************************
				   Login As Farmer
________________________________________________________________________________
-> If you aren't an Employee, this login page can be accessed by clicking "Login
as a Farmer". 
-> Once you've landed on this page, you will need to enter the email and password
supplied to you by the Farm Central Employee. 
-> If your data is valid, you can press login and proceed to the next page
-> If the data is invalid, an appropriate error message will appear
________________________________________________________________________________
				  Farmer Home Page
________________________________________________________________________________
->This is the home page for the Farmers upon logging in. 
->There are 2 tasks that they can choose from, and these tasks are:
*Add Products to Your Store, where you can add products to the Farm Central    Database
*View Your Store Products, where you can filter the database using your FarmerID
 to show your store's products

			  *Adding Products to Your Store*
-> This page allows you to add products to the database when clicking the Create                     
New link at the top.
-> Once clicked, you'll be able to fill in the necessary and required data fields
   so that your products can be added to the database
-> Once added, they will appear on the list, giving you 3 more options to choose from. 
These are Edit, Delete, and Details. 
-> Edit allows you to update fields of a particular entry, Delete removes a Farmer Account, 
and Details is a more detailed view of a particular account.
-> Beneath the Create link is a navigation link to take you back to the main page.
			  *Search Farmer Products using ID*
-> This page contains a textbox, a button, and a list. 
-> The textbox requires your FarmerID so that only your products can be displayed
-> If the FarmerID is valid, that particular farmer's items will display on the list 
->If its invalid, an appropirate error message will display
->A link is provided beneath the textbox so that you may return to the home page


_____________________________________________________________________________________________
						CODE ATTRIBUTION
* https://www.tutorialsteacher.com/mvc/create-edit-view-in-asp.net-mvc
* https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-edit-methods-and-edit-  view
* https://www.c-sharpcorner.com/UploadFile/97fc7a/validation-failed-for-one-or-more-entities-mvcentity-frame/
* https://www.aspsnippets.com/Articles/Solved-LINQ-to-Entities-does-not-recognize-the-method-SystemString-ToString-	method.aspx
* https://www.freecodecamp.org/news/how-to-change-text-color-in-html/
* https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/
*https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/

_____________________________________________________________________________________________________________
