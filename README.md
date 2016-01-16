# vs2015-binding-update-script
Small script `fix vs2015 bindings.linq` to update the binding redirects for visual studio 2015 after update one, based on the instructions from Sergey Tihon.

I didnt read Sergey's post properly and discovered for myself that the binding gets reset if you install any extensions and updates, hence why I wrote this linqpad script so that I can quickly reset it (them) each time. See Sergey's blogpost below.

https://sergeytihon.wordpress.com/2015/12/01/how-to-restore-viual-studio-2015-after-update-1-dependency-dance/

To use the script, simply open the linqpad script in linqpad, change the name, to your username, and run the script. The is small enough you can read the script to see what it does. I'm expecting there will be a few more of these type of hacks that one will need, depending on what extensions you install, and I'm assuming the hack fix might be along the same lines each time and I can modify my script each time.



