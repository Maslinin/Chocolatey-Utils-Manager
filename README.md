[![Build Status](https://github.com/Maslinin/Chocolatey-Utils-Manager/workflows/Build/badge.svg)](https://github.com/Maslinin/Chocolatey-Utils-Manager/actions/workflows/build.yml) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Maslinin_Chocolatey-Utils-Manager&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Maslinin_Chocolatey-Utils-Manager) [![GitHub license](https://badgen.net/github/license/Maslinin/Chocolatey-Utils-Manager)](https://github.com/Maslinin/Chocolatey-Utils-Manager/blob/master/LICENSE)

# Description
**Chocolatey Utils Manager** - GUI Application, intended to simplify working with Chocolatey (packet manager)         
Using Chocolatey Utils Manager you can as install Chocolatey itself, but also install/update/delete Chocolatey packets

You can expand list of available packets of Chocolatey by yourself, 
and even customize categories in GUI, which will contain that or another packets group

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
