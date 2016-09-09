echo off
rem DEL [/P] [/F] [/S] [/Q] [/A[[:]attributes]] names
rem   names         Specifies a list of one or more files or directories.
rem                 Wildcards may be used to delete multiple files. If a
rem                 directory is specified, all files within the directory
rem                 will be deleted.
rem 
rem   /P            Prompts for confirmation before deleting each file.
rem   /F            Force deleting of read-only files.
rem   /S            Delete specified files from all subdirectories.
rem   /Q            Quiet mode, do not ask if ok to delete on global wildcard
rem   /A            Selects files to delete based on attributes
rem   attributes    R  Read-only files            S  System files
rem                 H  Hidden files               A  Files ready for archiving
rem                 -  Prefix meaning not
REM RMDIR [/S] [/Q] [drive:]path
REM RD [/S] [/Q] [drive:]path

REM     /S      Removes all directories and files in the specified directory
REM             in addition to the directory itself.  Used to remove a directory
REM             tree.

REM     /Q      Quiet mode, do not ask if ok to remove a directory tree with /S
rem all cleanup should be performed in the following directories:
rem EX01-OPCFoundation_NETApi
rem PR21-CommServer
rem PR24-Biblioteka

rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$

echo "$URL$"

cd ..\..\
RD /S /Q .\bin
RD /S /Q .\PR33-CommServerUA\bin\Debug
RD /S /Q .\PR33-CommServerUA\bin\Release
RD /S /Q .\PR33-CommServerUA\Deliverables 
RD /S /Q .\PR33-CommServerUA\bin 
RD /S /Q .\PR33-CommServerUA\Samples\Server\bin 
RD /S /Q .\PR33-CommServerUA\Samples\Server\obj 
RD /S /Q .\PR33-CommServerUA\Scripts\bin 
RD /S /Q .\PR33-CommServerUA\Scripts\obj 
RD /S /Q .\PR33-CommServerUA\DataBindings\bin 
RD /S /Q .\PR33-CommServerUA\DataBindings\obj
RD /S /Q .\PR33-CommServerUA\UALibrary\bin 
RD /S /Q .\PR33-CommServerUA\UALibrary\obj
RD /S /Q .\PR33-CommServerUA\UAServer\bin 
RD /S /Q .\PR33-CommServerUA\UAServer\obj
RD /S /Q .\PR33-CommServerUA\UAServer\DemoConfiguration
RD /S /Q .\PR33-CommServerUA\ComInterop\Common\bin 
RD /S /Q .\PR33-CommServerUA\ComInterop\Common\obj 
RD /S /Q .\PR33-CommServerUA\LaunchTest_CommServer\bin 
RD /S /Q .\PR33-CommServerUA\LaunchTest_CommServer\obj

rem deleting project user files
del /F /S /Q /A:H .\PR33-CommServerUA\*.suo
del /F /S /Q /A:H .\PR33-CommServerUA\*.user
rem deleting objects
del /F /S /Q  .\PR33-CommServerUA\*.obj
rem deleting intellisence
del /F /S /Q  .\PR33-CommServerUA\*.ncb
rem deleting debuger informations
del /F /S /Q  .\PR33-CommServerUA\*.pdb
rem deletind desktop.ini
del /F /S /Q /A:H .\PR33-CommServerUA\*.ini

if /I "%1" NEQ "local" (
echo cleanup
echo $URL$
cd .\PR24-Biblioteka\Scripts
call clean.cmd 
cd ..\..
rem cd .\EX01-OPCFoundation_NETApi\Scripts
rem call clean.cmd 
rem cd ..\..
cd .\PR21-CommServer\Scripts
call clean.cmd 
cd ..\..

)
rem returning to base directory
cd .\PR21-CommServer\Scripts
echo on
