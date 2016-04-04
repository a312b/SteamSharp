# SteamSharp
A C# library for the steam apis. 
## Set up
To use the the library, you need to add a refrence in your project. 
1. Create an instance of the SteamSharp class
```cs
var steamSharp = new SteamSharp();
```
2. You now have access to the functions.
3. You can also run a simple test using the Tests class.
```cs
var steamSharpTest = new Tests(STEAM_API_KEY);
```
4. You can now test the library by calling the print functions. These functions print to the console.
```cs
//Print Games to the console, in this case Democracy 3 and Dovetail Games Flight School
steamSharpTest.PrintGamesFromStoreTest();
```
## Models
The models for the return objects can be found in the models folder for each of the apis.
### Example
The Steam Game model can be found at lib/steamStore/models

# Database library
This solution contains a library for working with a [MongoDB](https://www.mongodb.org/) database. 
## Set up
1. Install [MongoDB](https://www.mongodb.org/downloads#production) for your platform.
2. A setup guide for Windows can be found [here](https://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/).
3. To use the library and the database provided, specify the path to the folder containing the data.
Assuming your dir is at C:\Source\
```
C:\mongodb\bin\mongod.exe --dbpath C:\Source\SteamSharp\Database\data
```
