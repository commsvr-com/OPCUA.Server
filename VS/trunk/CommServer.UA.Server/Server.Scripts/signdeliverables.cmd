rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$
"%net20sdk%\signtool" sign /a ..\Deliverables\CommserverSetup\Release\CommServerUASetup.msi 
"%net20sdk%\signtool" sign /a ..\Deliverables\CommserverSetup\Release\Setup.exe
rem "%net20sdk%\signtool.exe" sign /n "CAS" /a "..\Deliverables\CommserverSetup\release\CommServerUASetup_1_00_22.exe"