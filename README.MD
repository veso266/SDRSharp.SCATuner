# SDRSharp.SCATuner
This plugin allows you to listen to [SCA Audio](https://en.wikipedia.org/wiki/Subsidiary_communications_authority) channels hidden inside regular FM Broadcast stations  
 
# How to install
Download [dll](https://github.com/veso266/SDRSharp.SCATuner/releases/download/1.1/SDRSharp.SCATuner.dll) from release page
## For latest SDR#
You just copy dll into Plugins directory and enjoy
## For SDR# 1785 and below 
You copy the plugin DLL into sdrsharp program directory and then edit plugins.xml and add the following line to it (people used to call this  MagicLine.txt)
 ```xml
<add key="SCATuner" value="SDRSharp.SCATuner.SCATunerPlugin,SDRSharp.SCATuner" />
 ```
 
 Exmplanation of MagicLine(if you want to write your own plugin someday)
 ```xml
 <add key="Whatever-you-want-that-is-unique" value="NameSpace.EntryPoint,DLLName" />
 ```
 
 
 ![SDRSharp.XDR](IMGS/Demonstration.PNG?raw=true "How it looks like when it works :)")

[Usage + install tutorial](https://youtu.be/n5Ifg6ncn2Y) -- Thanks to **Double A Labs** for his samples and this tutorial
