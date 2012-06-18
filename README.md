What is Unity.WF?
--------------------------------
Dependency injection with Windows Workflow is not as simple as with general classes. It requires some plumbing code. Unity.WF is a library that allows you to use Unity container to inject dependencies into workflows in a very simple way. 

Where can I get it?
--------------------------------
First, install [NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [Unity.WF](http://nuget.org/packages/Unity.WF) from the package manager console:

    PM> Install-Package Unity.WF

How do I use...
--------------------------------
1. [Workflow instance extension to inject dependencies into Wokflow Activity](https://github.com/dimaKudr/Unity.WF/wiki/How-to-use-Workflow-instance-extension-to-inject-dependencies-into-Wokflow-Activity)
2. [Unity container extension to inject dependencies into Wokflow Activity](https://github.com/dimaKudr/Unity.WF/wiki/How-to-use-Unity-container-extension-to-inject-dependencies-into-Wokflow-Activity)
3. [Workflow instance extension to inject dependencies into Wokflow Service](https://github.com/dimaKudr/Unity.WF/wiki/How-to-use-Workflow-instance-extension-to-inject-dependencies-into-Wokflow-Service)