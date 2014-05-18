@echo off

cd ..

set currentPath=%cd%\SohoWeb.AngularFramework\www

echo current path : %currentPath%

set excludePath=%cd%\SohoWeb.AngularFramework\exclude.txt

echo exclude path : %excludePath%

set targetpath=%cd%\SohoWeb.WebUI

echo target path : %targetpath%

xcopy %currentPath%\controllers\*.* %targetpath%\Controllers\*.* /s/y/exclude:%excludePath%

if not exist %targetpath%\bower_components\ (xcopy %currentPath%\bower_components\*.* %targetpath%\bower_components\ /s/y)

if not exist %targetpath%\main\main.js (xcopy %currentPath%\main\main.js %targetpath%\main\ /s/y)

xcopy %currentPath%\main\app.js %targetpath%\main\ /s/y

xcopy %currentPath%\main\main.css %targetpath%\main\ /s/y

pause
