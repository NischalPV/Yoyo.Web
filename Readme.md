This file describes the functionality and implementation of Yoyo test Web application using ASP.NET Core.

## Pre-requisites:
* .Net Core v3.1.403
* Working internet connection since it uses libraries from CDN

## File struture
This project implements following file structure
    
    Yoyo.Web    // Solution root folder
    |
    |- <Dir> Yoyo.Web    // Project root folder
    |    |- <Dir> Controllers
    |    |    |- HomeController.cs
    |    |- <Dir> Data
    |    |    |- Atheletes.json
    |    |    |- DataContext.cs
    |    |    |- FitnessRatings.json
    |    |    |- IDataContext.cs
    |    |- <Dir> Interfaces
    |    |    |- IAtheleteRepository.cs
    |    |    |- IFitnessRatingRepository.cs
    |    |- <Dir> Models
    |    |    |- <Dir> ViewModels
    |    |    |    |- FitnessRatingViewModel.cs
    |    |    |- Athelete.cs
    |    |    |- BaseEntity.cs
    |    |    |- ErrorViewModel.cs
    |    |    |- FitnessRating.cs
    |    |- <Dir> Properties
    |    |    |- launchSettings.json
    |    |- <Dir> Repository
    |    |    |- AtheleteRepository.cs
    |    |    |- FitnessRatingRepository.cs
    |    |- <Dir> Views
    |    |    |- <Dir> Home
    |    |    |    |- Index.cshtml
    |    |    |    |- Privacy.cshtml
    |    |    |- <Dir> Shared
    |    |    |    |- _Layout.cshtml
    |    |    |    |- _ValidationScriptsPartial.cshtml
    |    |    |    |- Error.cshtml
    |    |    |- _ViewImports.cshtml
    |    |    |- _ViewStart.cshtml
    |    |- <Dir> wwwroot
    |    |    |- <Dir> css
    |    |    |- <Dir> js
    |    |    |- <Dir> lib
    |    |    |- favicon.ico
    |    |- appSettings.Development.json
    |    |- appSettings.json
    |    |- Program.cs
    |    |- ServiceRepository.cs
    |    |- Startup.cs
    |    |- Yoyo.Web.csproj
    |- Readme.md
    |- Yoyo.Web.sln

## Project Description

Yoyo Web application implements the functionality that helps coaches keep track of atheletes during Yoyo fitness test. The web application is created with .Net Core v3.1 as back-end and razor pages as front-end.


### Functionalities

- [x] Timer starting from 00:00 mm:ss
- [x] Start timer button that shows time elapsed
- [x] Stop button that flushes the timer data
- [x] Display current level and shuttle
- [x] Progress bar that shows progress of current shuttle
- [x] Countdown displaying time remaining to the next shuttle
- [x] Speed in km/h for current shuttle
- [x] Total distance run by the atheletes
- [x] Dynamic list of atheletes from Atheletes.json file. Changes are affected when changes are made to Atheletes.json file and page is refreshed.
- [x] Action buttons to Warn and Stop Atheletes.
- [x] Setting score when athelete stops running
- [x] Edit functionality to change the score of an athelete

### Files Description
1. Yoyo.Web/Data/
    1. Atheletes.json

        This file has list of all the atheletes that takes part in Yoyo fitness test

    1. FitnessRatings.json
    
        Alias of fitnessrating_beeptest.json. Renamed it to fit the Pluralization of model as in DbContext. Contains the list of all shuttles described with start times of each shuttles.

    1. IDataContext.cs

        Interface to implement similar functionality as in DbContext files. Contains awaitable Tasks that returns list of Atheletes and FitnessRatings.

    1. DataContext.cs

        Implementation of IDataContext.cs file. Methods read Atheletes.json and FitnessRatings.json files, maps to the respective models and returns queryable list

1. Yoyo.Web/Interfaces/
    1. IAtheleteRepository.cs
    
        This file contains awaitable Task methods related to Atheletes
        * ListAllAtheletes()
        * GetAtheleteById(int)
        * SetAtheleteStatus(int, string, string)

    1. IFitnessRatingRepository.cs
    
        Interface having awaitable Task methods related to Fitness Ratings
        * ListAllFitnessRatings()
        * GetNextFitnessRating()
        * GetCurrentFitnessRating()

1. Yoyo.Web/Models/
    1. ViewModels/FitnessRatingViewModel.cs
        
        ViewModel to convert string values from FitnessRatings.json to their respective types i.e. int, float, TimeSpan. We use this ViewModel in controller.

    1. Athelete.cs
        
        Model that describes properties of an Athelete. Inherited from __BaseEntity.cs__

    1. FitnessRating.cs
    
        Model describing properties from FitnessRatings.json file. All properties have raw string from the file. Inherited from __BaseEntity.cs__

    1. BaseEntity.cs
    
        Entity class having common features from all the models. e.g. Id

1. Yoyo.Web/Repository/

    1. AtheleteRepository.cs
    
        This class implements Tasks from interface IAtheleteRepository.cs.

    1. FitnessRatingRepository.cs
    
        This class implements Tasks from interface IFitnessRatingRepository.cs

1. Yoyo.Web/ServiceRegistry.cs
    
    Registers Repository Services and Data Service when app starts.