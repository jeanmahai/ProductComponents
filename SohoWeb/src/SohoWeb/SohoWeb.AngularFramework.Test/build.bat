@echo off

cd ..

set currentPath=%cd%\SohoWeb.AngularFramework\www

set targetpath=%cd%\SohoWeb.AngularFramework.Test\www


xcopy %currentPath%\css\*.* %targetpath%\css\*.* /s/y
xcopy %currentPath%\controllers\*.* %targetpath%\controllers\*.* /s/y
xcopy %currentPath%\main\scripts\N.js %targetpath%\main\scripts\ /s/y

if not exist %targetpath%\bower_components\ (xcopy %currentPath%\bower_components\*.* %targetpath%\bower_components\ /s/y)

if not exist %targetpath%\main\scripts\app.js (xcopy %currentPath%\main\scripts\app.js %targetpath%\main\scripts\ /s/y)

if not exist %targetpath%\main\scripts\config.js (xcopy %currentPath%\main\scripts\config.js %targetpath%\main\scripts\ /s/y)

if not exist %targetpath%\main\scripts\pageLoaded.js (xcopy %currentPath%\main\scripts\pageLoaded.js %targetpath%\main\scripts\ /s/y)

if not exist %targetpath%\main\scripts\main.js (xcopy %currentPath%\main\main.js %targetpath%\main\ /s/y)

	
