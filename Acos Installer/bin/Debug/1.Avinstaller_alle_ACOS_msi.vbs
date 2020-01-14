Set WshShell =  CreateObject("WScript.Shell")
Set WshProcEnv = WshShell.Environment("Process")
Set fsoObject = CreateObject("Scripting.FileSystemObject") 

process_architecture= WshProcEnv("PROCESSOR_ARCHITECTURE") 

if process_architecture = "x86" Then
	strKey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\"
else
	strKey = "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\"
end if




Const HKLM = &H80000002 'HKEY_LOCAL_MACHINE 
strComputer = "." 
'strKey = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" 
strName = "DisplayName" 
strQuiet = "QuietDisplayName"
strVer = "DisplayVersion" 
strPub = "Publisher" 
strUninst = "UninstallString" 

ReDim arrNames(0)
ReDim arrAppIDs(0)
ReDim arrVersions(0)
 
Set objReg = GetObject("winmgmts://" & strComputer & _ 
 "/root/default:StdRegProv") 
objReg.EnumKey HKLM, strKey, arrSubkeys 
'WScript.Echo "Installed Applications" & VbCrLf
For Each strSubkey In arrSubkeys 
  strInfo = ""
  intRet1 = objReg.GetStringValue(HKLM, strKey & strSubkey, strName, strDisplayName) 
  If intRet1 <> 0 Then 
    objReg.GetStringValue HKLM, strKey & strSubkey, strQuiet, strDisplayName 
  End If 
  objReg.GetStringValue HKLM, strKey & strSubkey, strVer, strVersion
  objReg.GetStringValue HKLM, strKey & strSubkey, strPub, strPublisher 
  objReg.GetStringValue HKLM, strKey & strSubkey, strUninst, strUninstall 

  'wscript.echo "Publisher: " & strPublisher
  if strPublisher <> "" then
	  if instr(lcase(strPublisher), "acos") > 0 then
	  if not instr(lcase(strDisplayName), "acos oppgradering") > 0 and not instr(lcase(strDisplayName), "importservice") > 0 then
		redim preserve arrNames(ubound(arrNames)+1)
		redim preserve arrVersions(ubound(arrVersions)+1)
		redim preserve arrAppIDs(ubound(arrAppIDs)+1)

		If strDisplayName <> "" Then 
			arrNames(ubound(arrNames)) = strDisplayName
		  End If 
		  If strVersion <> "" Then 
			arrVersions(UBound(arrVersions)) = strVersion
		  End If 
		  If strUninstall <> "" Then 
			 arrAppIDs(UBound(arrAppIDs)) = mid(strUninstall, instr(strUninstall, "{"), 38)
		  End If
	  end if
	  end if
  end if
Next 

strMsgBoxString = "Trykk 'Avbryt' dersom noko ikkje stemmer!" & vbCrLf
for i=1 to ubound(arrAppIDs)
	strMsgBoxString = strMsgBoxString & VbCrLf & arrNames(i)
next

result = MsgBox(strMsgBoxString, 1, "Liste over applikasjoner for avinstallasjon")
if result = 1 then
	for i=1 to ubound(arrAppIDs)
		retkode = WshShell.Run("msiexec.exe /x" & arrAppIDs(i) & " /qb!", 1, true)
		if retkode <> 0 and retkode <> 3010 then
			wshshell.popup "Avinstallasjon av " & arrNames(i) & " feila med kode: " & retkode
		end if
	next
elseif result = 2 then
	wshshell.popup "Avinstallasjon avbrutt, før installasjonen kan fortsette må gamle MSI-pakker manuelt avinstallerast."
end if
