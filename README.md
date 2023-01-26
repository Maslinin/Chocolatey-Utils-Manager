[![Build Status](https://github.com/Maslinin/Chocolatey-Utils-Manager/workflows/Build/badge.svg)](https://github.com/Maslinin/Chocolatey-Utils-Manager/actions/workflows/build.yml) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Maslinin_Chocolatey-Utils-Manager&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Maslinin_Chocolatey-Utils-Manager) [![GitHub license](https://badgen.net/github/license/Maslinin/Chocolatey-Utils-Manager)](https://github.com/Maslinin/Chocolatey-Utils-Manager/blob/master/LICENSE)

# Description
**Chocolatey Utils Manager** - is a GUI application, designed to ease work with ***Chocolatey Package Manager***.
With Chocolatey-Utils-Manager you can *install/update/remove* Chocolatey packages from your computer.

![Screenshot of ChocolateyUtilsManager](https://github.com/Maslinin/Chocolatey-Utils-Manager/raw/master/screenshot.png "Screenshot of Chocolatey Utils Manager")

You can extend list of available Chocolatey packages by yourself, and customize the categories, that the packages will belong to.

# How do I extend list of available packages, displayed in GUI?
You need to open file **ProgramList.json**

> ProgramList.json file will be stored in ther directory with the executable after the project is built.

Each object in this *.json* file represents a different category of packages, displayed in the GUI.
All you need is simply write information about the new package into existing object or make a new object, as shown below.

Example of *json* object:

```
{
    "Category": "Browsers", - category to which the packages belong and which windows they will be displayed in
    "Packages": [ - list of entities, representing displayed packages
      {
        "PackageName": "Chrome", - package name, displayed in the window
        "PackageRefName": "googlechrome" - technical chocolatey package name
      },
      {
        "PackageName": "Opera",
        "PackageRefName": "opera"
      },
      {
        "PackageName": "Firefox",
        "PackageRefName": "firefox"
      }
    ]
  }
```
