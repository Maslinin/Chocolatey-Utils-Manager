# Description
**Chocolatey Utils Manager** - GUI Application, intended to simplify working with Chocolatey (packet manager)         
Using Chocolatey Utils Manager you can as install Chocolatey itself, but also install/update/delete Chocolatey packets

You can expand list of available packets of Chocolatey by yourself, 
and even customize categories in GUI, which will contain that or another packets group

## Used technologies:    
**Platform:** DotNet Core 3.1      
**GUI:** WinForms    
**NuGet Referencies:** Newtonsoft.JSON     

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
    "Category": "Browsers", - Категория, к которой относятся пакеты и указывающая, в каком окне они будут отображаться 
    "Programs": [ - лист сущностей, представляюший отображаемые пакеты
      {
        "ProgramName": "Chrome", - отображаемое имя программы в окне
        "ChocolateyInstallName": "googlechrome" - имя пакета в chocolatey
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
Для этого Вам все также нужен файл **ProgramList.json** и еще один файл, находящийся в этой же директории - **InstallerCategories.json**.

> Файлы ProgramList.json и InstallerCategories.json будут находиться в каталоге с исполняемым файлом после сборки.    
> Предполагается, что Вы будете кастомизировать пакеты и категории уже в этих файлах, сгенерированных после компиляции.

Вам просто нужно указать в обоих файлах одинаковые имена категорий. НО!  
Вы, наверное, заметили, что в *InstallerCategories.json* на одну категорию меньше!    
На самом деле, последняя категория всегда будет *Other*: 
если в одном из файлов Вы неправильно укажете имя категории, ошибки не будет: пакеты из неправильно указанной категории будут просто переброшены в *Other*.

> Вам не обязательно беспокоиться о пробелах и регистре при кастомизации категорий - из имен категорий из двух файлов убираются все пробелы, 
а затем они приводятся к одному регистру
