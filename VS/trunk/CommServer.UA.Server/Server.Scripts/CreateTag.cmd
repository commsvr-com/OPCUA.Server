
rem//  $LastChangedDate: 2009-10-27 13:31:11 +0100 (Wt, 27 paü 2009) $
rem//  $Rev: 4116 $
rem//  $LastChangedBy: mzbrzezny $
rem//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/PR31-DataProviders/Scripts/create_branch.cmd $
rem//  $Id: create_branch.cmd 4116 2009-10-27 12:31:11Z mzbrzezny $


set branchtype=tags
set TagFolder=Rel_1_00_33
set TagPath=svn://svnserver.hq.cas.com.pl/VS/%branchtype%/CommServerUA/rel_1_00_33
set trunkPath=svn://svnserver.hq.cas.com.pl/VS/trunk

svn mkdir %TagPath%  -m "created new %TagPath% (in %branchtype% folder)"

svn copy %trunkPath%/EX02-MAML %TagPath%/EX02-MAML -m "created copy in %TagPath% of the project EX02-MAML"
svn copy %trunkPath%/EX03-3DTools %TagPath%/EX03-3DTools -m "created copy in %TagPath% of the project EX03-3DTools"
svn copy %trunkPath%/EX05-MeshDiagram3D %TagPath%/EX05-MeshDiagram3D -m "created copy in %TagPath% of the project EX05-MeshDiagram3D"
svn copy %trunkPath%/ImageLibrary %TagPath%/ImageLibrary -m "created copy in %TagPath% of the project ImageLibrary"
svn copy %trunkPath%/PR21-CommServer %TagPath%/PR21-CommServer -m "created copy in %TagPath% of the project PR21-CommServer"
svn copy %trunkPath%/PR24-Biblioteka %TagPath%/PR24-Biblioteka -m "created copy in %TagPath% of the project PR24-Biblioteka"
svn copy %trunkPath%/PR30-OPCViever %TagPath%/PR30-OPCViever -m "created copy in %TagPath% of the project PR30-OPCViever"
svn copy %trunkPath%/PR31-DataProviders  %TagPath%/PR31-DataProviders -m "created copy in %TagPath% of the project PR31-DataProviders"
svn copy %trunkPath%/PR32-ModelDesigner %TagPath%/PR32-ModelDesigner -m "created copy in %TagPath% of the project PR32-ModelDesigner"
svn copy %trunkPath%/PR33-CommServerUA %TagPath%/PR33-CommServerUA -m "created copy in %TagPath% of the project PR33-CommServerUA"
svn copy %trunkPath%/PR35-ASMD_Plugins %TagPath%/PR35-ASMD_Plugins -m "created copy in %TagPath% of the project PR35-ASMD_Plugins"
svn copy %trunkPath%/PR38-OPCUAViewer %TagPath%/PR38-OPCUAViewer -m "created copy in %TagPath% of the project PR38-OPCUAViewer"
svn copy %trunkPath%/PR39-CommonResources %TagPath%/PR39-CommonResources -m "created copy in %TagPath% of the project PR39-CommonResources"
svn copy %trunkPath%/PR46-UA.Common %TagPath%/PR46-UA.Common -m "created copy in %TagPath% of the project PR46-UA.Common"

pause ....

