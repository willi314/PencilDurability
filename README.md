# PencilDurability
Pencil Durability kata for Pillar Technology application

The simplest way to compile and run the code in this project is to open the project in Visual Studio, build the project, and run the tests

If Visual Studio isn't an option then a Windows .NET Framework is required. First download the projec then navigate to your .NET Framework folder, for example:

\Windows\Microsoft.NET\Framework\v4*

Then use MSBuild.exe to compile the solution, for example:

msbuild "C:\Users\Alex\Documents\PencilDurability-master\PencilDurability\PencilDurability.sln" /t:Build

Running tests without Visual Studio is a very tricky process, if you really want to do it you can follow the guide here:

http://blog.anthonybaker.me/2013/05/running-mstest-without-visual-studio.html

Otherwise you can install Visual Studio test agent or just Regular Visual Studio. To run tests outside of the Visual Studio app you can use MSTest in the Visual Studio Command Line. Navigate to \PencilDurability-master\PencilDurabilityTest\bin\Debug and run the following command:

MSTest /testcontainer:PencilDurabilityTest
