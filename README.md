# **OUTDATED**
I am unable to find new address using cheat engine after 1.4.2.3 update
# TerrariaFishingBot
  -Fishing bot for Terraria

## HOW TO USE:
1. Run Terraria, equip fishing pole and stand near water.
2. Open TerrariaFishingBot.exe.
3. Press "Enter" on keyboard to start fishing bot.
4. Get back to game and aim your mouse to water.
5. Fishing bot will automatically start fishing.
![](example.gif)


## HOW DOES IT WORK?
It's using library VAMemory, which is very helpful for reading/writing to memory.    
I used cheat engine to find bool that is **true** when fish is being caught **(0 = false, 1-255 = true)**  
![](example2.gif)  
So basically it is checking if it's something else than 0. If so, it will reel in using **Click()** function.  
I also had to find static pointer **0x00159B24** and offset **0x170** to adress of that bool using pointer scan.  
###### Sources:  
[Finding adress](https://www.cheatengine.org/forum/viewtopic.php?t=566966&sid=f8cfe7574a6bde4704b2a63979c0b7d6)  
[Using VAMemory](https://www.youtube.com/watch?v=JubDctjYb_Q&t)  
[Finding static pointers](https://www.youtube.com/watch?v=We3iuurMSVM&t)  
[Click() function](https://gamedev.stackexchange.com/questions/19906/how-do-i-simulate-the-mouse-and-keyboard-using-c-or-c)
