@echo off

cd ..

set currentPath=%cd%\SohoWeb.AngularFramework\www

set targetpath=%cd%\ZhongJiuCRM\www


::xcopy %currentPath%\css\*.* %targetpath%\css\*.* /s/y
xcopy %currentPath%\controllers\*.* %targetpath%\controllers\*.* /s/y
::xcopy %currentPath%\main\scripts\N.js %targetpath%\main\scripts\ /s/y

if not exist %targetpath%\bower_components\ (xcopy %currentPath%\bower_components\*.* %targetpath%\bower_components\ /s/y)

if not exist %targetpath%\main\main.js (xcopy %currentPath%\main\scripts\app.js %targetpath%\main\ /s/y)

xcopy %currentPath%\main\app.js %targetpath%\main\ /s/y

xcopy %currentPath%\main\main.css %targetpath%\main\ /s/y


pause
