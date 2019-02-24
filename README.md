# NameSorter
Name sorter .NET Core console app for code assessment. This console app was written on a Mac with VS Community Edition for Mac.

# Design Decisions
The following assumptions were made when designing the console app:
  - It must be extensible when it comes to consuming data from a different source and with different data format.
  - It must be extensible when it comes to sending data to a different output channel (any stream object that derives from the .NET Stream class) with a different data format.
  - It must be extensible when it comes to using different compare rules.
  - It must be extensible when it comes to comparing different types of object, e.g. comparing address, telephone numbers, etc.
  - It can handle some inconsistencies in provided name list, i.e. additional whitespaces or empty lines.
  - It demonstrates SOLID principles.
  

# Running the App
On a Mac:
```
dotnet name-sorter.dll ./unsorted-names-list.txt
```
On a PC (not tested, assuming the build will generate an .exe file):
```
name-sorter ./unsorted-names-list.txt
```

The file name must have the string 'unsorted'. It will then be replaced with 'sorted'.
