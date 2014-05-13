@echo off

cd ..

set currentPath=%cd%\SohoWeb.AngularFramework\www

set targetpath=%cd%\SohoWeb.AngularFramework.Test\www


xcopy %currentPath%\css\*.* %targetpath%\css\*.* /s/y
xcopy %currentPath%\controllers\*.* %targetpath%\controllers\*.* /s/y
xcopy %currentPath%\main\*.* %targetpath%\main\ /s/y
xcopy %currentPath%\views\*.* %targetpath%\views\ /s/y
	
