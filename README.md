# csharp-wpf-mvvm
tracking code related to wpf using (when possible) mvvm design pattern


## General 

~~~mermaid
flowchart LR
    ViewX["View"]:::bg1
    ViewModelX["ViewModel"]:::bg2
    ModelX["Model class
    and business logic"]:::bg3
    ViewX --Command Bindings--> ViewModelX
    ViewModelX -- Data Bindings --> ViewX
    ViewModelX --Methods (Retrieve and Update)--> ModelX
    ModelX --Properties--> ViewModelX
    classDef fs1 font-size:12pt;
    classDef bg1 fill:purple, font-size:22pt, color:#FFF;
    classDef bg2 fill:green, font-size:22pt, color:#FFF;
    classDef bg3 fill:orange, font-size:22pt, color:#FFF;
~~~

## MISC Resources

### MISC Resources

- [https://www.go4expert.com/articles/c-sharp-tutorials/]
- [https://dotnet.microsoft.com/en-us/languages/csharp]
- [https://www.tutorialsteacher.com/csharp]
- [https://www.codecademy.com/learn/learn-c-sharp]
- [https://www.geeksforgeeks.org/csharp-programming-language/]
- [https://www.c-sharpcorner.com/]
- [https://dotnettutorials.net/lesson/dotnet-framework/]
- [https://codewithmosh.com/]
- [https://help.syncfusion.com/wpf/datagrid/styles-and-templates]
- [https://wpf-tutorial.com/wpf-application/resources/]


### MISC ghs

- [https://github.com/CSharpDesignPro/WPF---Responsive-UI-Design]
- [https://github.com/TacticDevGit/Record-Book-App-WPF-MVVM]
- [https://github.com/rmsmech/Tutorials/tree/master/WPF]





