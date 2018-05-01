# APIStudyApp

For studying Client API interaction with Back-end API
## Target Group

This app targets those who wants to learn about AJAX with JavaScript(for example Angular, React, JQuery) but also those who develops Web APIs. You will be able to type code in Client side as well as Server side. 

1. Teachers can use it to learn or teach students about Web API or AJAX with JavaScript.
2. Students who focus on front-end development can use this app to type scripts directly in the app or start the app in order to use the WebApi and in that case use whatever front-end developer program, for example Sublime, Atom etc.
3. Students who focus on back-end development can use this app to develop the WebApiCore project found within the repository.

## Installation

<h4>SQL Server EXPRESS 2017 >:</h4>

1. Download SQL Server EXPRESS [Download SQL DB]
2. Install SQL server and SQL server Management Studio (SSMS) [Download SSMS]
   1. SSMS installation 
   2. Import backup file [Download Backup]
   3. Databases > Right Click > Restore Database > Source > Device > Add backup file > Click OK
   4. Guide for installation of MS SQL EXPRESS and Importing backup file [VIDEO DB] (6min).
  

<h4>Visual Studio Community 2017 > :</h4>

1. Download Visual Studio Community [Download Visual Studio]
2. Install Visual Studio as shown below
3. Choose to install following Workloads 
   1. Universal Windows Platform Development,.NET Core cross-platform development and ASP.NET and Web Development.
   2. <img src="https://docs.microsoft.com/en-us/visualstudio/install/media/install-visual-studio-enterprise.png" width="450"/>
   3. Copy URL https://github.com/simonlidm/APIStudyApp and paste into Visual Studio > Team Explorer > Clone > URL. Open .sln file.
   4. Guide for installation and use of GitHub in Visual Studio [VIDEO VS] (5min).

## Usage example

Please watch the videos in order to understand how to use this app. [GUIDE VIDEO] (10min)

### Recommendation

Front-end developers should either use the APIStudyApp project directly as seen in the video below or run the WebApiCore project and use own webdeveloper tools like Sublime, Atom etc. If you choose to use the latter dont forget to call GET requests to the WebApiCore project as seen in the guide video for WebApi Core [GUIDE VIDEO WEBAPICORE] (5min)

Back-end developers should try to create similar APIs as seen in the WebApi Core/APIStudyApp project(without copying the code in controllers). Use Postman or Restlet to see the output from the GET requests in the APIs. You can use the already created API controllers as right answers.

<h4>Basic usage:</h4>

   1. Views folder contains all test examples.
   2. For each Example there is code to be written in order to use AJAX with JavaScript.
   3. Url must be correct for each example, read carefully. Use an API tool to check url queries ex. Postman or Restlet Client (watch video).
   4. You will be able to see the WebAPI and how it works directly (watch video). There is also an API Helper when you run the app, API Helper is mainly to understand how you can use the API [local/API Help].
   5. API Key is needed and will be given by your teacher.
   6. Guide for usage of the app [GUIDE VIDEO] (10min)
   7. Guide for usage of WebApi Core [GUIDE VIDEO WEBAPICORE] (5min)


## Technologies and Methods

+ Visual Studio 2017
+ Git
+ MS SQL Server / Management Studio
+ .NET Framework
+ .NET Core
+ ASP.NET MVC 5
+ ASP.NET Core WebApi
+ Entity Framework
+ Entity Framework Core
+ LinQ to SQL
+ Bootstrap
+ HTML
+ CSS
+ Razor
+ JQuery
+ Fetch API

## Release History

* 1.0.0
   * Ready to Use
* 1.1.0
    * WebApi Core
* 1.2.0
    * Work In Progress

## Meta

Simon Lindmer – simon.lindmer@gmail.com

[https://github.com/simonlidm/APIStudyApp](https://github.com/simonlidm/APIStudyApp/)

## Contributing

Fork it (<https://github.com/simonlidm/APIStudyApp/fork>)

<!-- Markdown link & img dfn's -->
[Download SQL DB]: https://www.microsoft.com/sv-se/sql-server/sql-server-editions-express
[Download SSMS]:https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms
[Download Backup]: https://drive.google.com/drive/u/2/folders/14tWMANiO6FDZqfdaI11_opjOLFYwkShg
[VIDEO DB]:https://youtu.be/DUiPad5BuaI


[Download Visual Studio]:https://www.visualstudio.com/downloads/
[VIDEO VS]: https://youtu.be/VIRY50_sUVs

[local/API Help]:http://localhost:62818/Help
[GUIDE VIDEO]:https://youtu.be/PXLaP4mn8vU
[GUIDE VIDEO WEBAPICORE]:https://youtu.be/3wh-KfIgIJ4
