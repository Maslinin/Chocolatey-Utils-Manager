# Description
**Chocolatey Utils Manager** - GUI Application, intended to simplify working with Chocolatey (packet manager)         
Using Chocolatey Utils Manager you can as install Chocolatey itself, but also install/update/delete Chocolatey packets

You can expand list of available packets of Chocolatey by yourself, 
and even customize categories in GUI, which will contain that or another packets group

## Used technologies:    
**Platform:** DotNet 6.0   
**GUI:** WinForms    
**NuGet Referencies:** Newtonsoft.JSON (v. 13.0.1), NLog (v. 4.7.14), System.Management.Automation (v. 7.2.1), Microsoft.PowerShell.SDK (v. 7.2.1)     

# File structure
Whole source code is in *src* folder, in root of repository       

**files in src:**     
1. **Choco** - classes files for interacting with Chocolatey
2. **Installer** - graphics of GUI and it's business logic     
2.1. **EntityModels** - entity modelfs for Installer     
2.2. **InstallerContentModels** - files with content/models for Installer content,
such as list of programs and JSON categories      
3. **Program.cs** - program enter point 

# I want to expand list of packets, displayed in GUI and available for iteraction. How do I do it?
go to **src\Installer\InstallerContensModels** and open file **ProgramList.json**

> Files ProgramList.json and InstallerCategories.json will be in catalog with .exe file after build
> It supposed,that you'll customize packages and categories in files itself, generated after complilation.

**In general, there are 9 categories** - same as, windows for displaying them. 9 categories = 9 windows = 9 json objects. So, what does it mean?        
Every category is represented by JSON object: all you need to do is - add object into category file object, in field "Programs", which will represent your packet

Example:
```
{
    "Category": "Browsers", - Category, which packets are related and pointing on the window they will be displayed 
    "Programs": [ - list of entities, representing displayed packets
      {
        "ProgramName": "Chrome", - diaplayed name of a program
        "ChocolateyInstallName": "googlechrome" - name of packet in chocolatey
      },
      {
        "ProgramName": "Opera",
        "ChocolateyInstallName": "opera"
      },
      {
        "ProgramName": "Firefox",
        "ChocolateyInstallName": "firefox"
      }
    ]
  }
```

# Okey, but how do I change the name(type) of a category?
For that you need file **ProgramList.json** as well and another one, located in the same directory **InstallerCategories.json**

> Files ProgramList.json and InstallerCategories.json will be located in catalog with executive file after build    
> It's supposed, that you will customize packetsа and categories in these files, generated after compilation

You just simply need to specify the same categories names in both files. BUT!  
You, probably, noticed, that there are one category less in *InstallerCategories.json* file   
In fact, last category always will be called *Other*: 
if name category incorrectly in one of files, it won't be a mistake: packets from wrong-specified category will be transfered to *Other*

> It's unneccesary to worry about registers during categories customisation - all problems will be removed from categoies names in both files, 
then they will be transfered to one same register