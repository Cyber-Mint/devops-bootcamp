# Linux Cheat Sheet

## Basic Commands

* top - display Linux processes `top -u <user>`<br>
  z - show active process<br>
  c - show/toggle path of processes<br>
  k - kill process<br>
  `top -n 1 -b > processes.txt`<br>
* htop - interactive process viewer `htop`
* history - shows all the commands you have previously executed

It would be nice that history was kept across terminal sessions & remove duplicates.
Add these to your `~/.bashrc`
 
> ```
> # Avoid duplicates
> export HISTCONTROL=ignorespace:ignoredups:erasedups
> # don't add duplicate lines or lines starting with space.
> HISTCONTROL=ignoreboth
>
> HISTSIZE=10000
> HISTFILESIZE=2000000
>
> # When the shell exits, append to the history file instead of overwriting it
> shopt -s histappend
> 
> # After each command, append to the history file and reread it
> export PROMPT_COMMAND="${PROMPT_COMMAND:+$PROMPT_COMMAND$'\n'}history -a; history -c; history -r"
> 
> # I like to have the date-time in my history
> HISTTIMEFORMAT="%F %T "
> # %F : Equivalent to %Y – %m – %d
> # %T : Replaced by the time ( %H : %M : %S )
> ```

* `clear` / ctrl-l - clear the terminal screen (just adds blank lines)
* `reset` - clear terminal completely

* `sudo passwd [user]`
* `sudo apt update -y` and `sudo apt upgrade -y` and `sudo apt autoremove`
* apt-get is better behaved in bash scripts but apt is the new way ...
* `sudo reboot now` pretty much does what you think

* `exit` - exits the terminal session
* `nano [filename]`- a favorite editor of many ...<br>
  ctrl-a [begin of line]<br>
  ctrl-e [end of line]<br>

* `sudo apt install sl`
* `sudo apt install/remove cowsay` - we will revisit this when we get to "ansible".
* uname
* lsb_release -a
* `sudo adduser [newuser]` and `sudo usermod -aG sudo [newuser]`
* `usermod --expiredate 2020-01-30 [newuser]` will add an expiry to the user.
* `groups [user]` or `id [user]`
* `sudo userdel [user]`

* `bg` - Move jobs to the background.
* `fg` -Move jobs to the foreground.
* `ps aux | grep firefox`
* kill [pid]
* `killall firefox` or `killall -u [user-name]`
* `pkill ping` or more carefully kill `pkill -f 'ping google.com` without killing `'ping amazon.com'`
  

## Networking
* `tree` or `tree -L 2 [path]`
* `wget [url]`
* `netstat at/au` add l for listening ports or s for statistics
* `ping -c2 [ip/url]`
* run multiline [command] && [command]
* curl - requires a bigger discussion `https://curl.se/docs/httpscripting.html`
* dig - DNS lookup utility
* `nohup [command] &` will just carry on running piping stdout `1>` to `nohup.out`
* I am more a fan of `screen ssh user@server.cyber-mint.com`  and you can detach with CTRL-A-D<br>
  and reconnect with `screen -r` it can manage multiple connections. Even if session crashes it will reconnect.
* `ssh user@host` and `scp my/local/file user@server.host:/remote/path/file`


## File Management
* `ls -a -h -l`
* `cd ~`
* `cd ..`
* `touch [newfile]`
* `mkdir [folder]`
* `mkdir -p [parentfolder]/[childfolder]`

* `rm -rf [FOLDER/S]`
* `cp -a -R -i [FILE/S]`
* `mv -f -i [fromfile] [tofile]`

* `du -s ~/` - disk usage 
* `df -h | grep -v snap` - human readable disk free

* `file -b -i [FILE]` - give a brief list of file mime type

* pwd - print working directory
* cd - change directory
* cat [file] - concatenate files and print on the standard output


## File Permissions
* chown [user]:[group] [file] - change file owner and group
* chmod [user][group][others] [file] - change file permissions/mode bits
  
| Number | Permission | Representation |
| ------ | --------------------- | ----------------- |
| 0 | No Permissions | — |
| 1 | Execute Permission | –x |
| 2 | Write Permission | -w- |
| 3 | Write and Execute | -wx |
| 4 | Read Permission | r– |
| 5 | Read and Execute | r-x |
| 6 | Read and Write | rw- |
| 7 | Read, Write, and Execute | rwx |

eg. `chmod 640 myfile.txt`

## File Searching
* grep - "global regular expression print" can do some cool stuff but I use it to do three things:
  `grep 'text-to-find' ~/dev/myfiles-to-search` - find the text in files
  `ps aux | grep 'text'` - match the text
  `ls -l | grep -v 'except-this-text'` - negative match
|
* `which docker-compose` - find the executable path of a command
* `whereis [command]` - locate the binary, source, and manual page files for a command

* `locate [file]` - requires `updatedb` and finds files
* `find [path] -name [file-looking-for]`


## File Compression

* zip [archive] [file1] ...[filen]
* unzip [archive]

| Command | Synopsis |
| ------- | ------------------------------------------------------------------------------------------------- |
| 1 | tar –cvf newarchive.tar file 	Create new .tar archive with name newarchive and containing file. |
| 2 | tar –cvzf newarchive.tar.gz files 	Create new Gzip (.gz) file. |
| 3 | tar –cvjf newarchive.tar.bz2 files 	Create new Bzip2 (.bz2) file. |
| 4 | tar –xvf archive.tar 	Extract contents of .tar file to current folder. |
| 5 | tar –xvf archive.tar –C /dest/directory 	Extract contents of .tar file to specified folder. |
| 6 | tar –xvzf archive.tar 	Extract contents of .gz file. |
| 7 | tar –xvjf archive.tar 	Extract contents of .bz2 file. |
| 8 | tar –tvf archive.tar 	List contents of .tar archive. Same command can be used to view contents of .gz and .bz2 archives as well. |
| 9 | gzip file 	Compresses the file and renames it to file.gz. |
| 10 | gzip –d file.gz 	Decompresses file.gz |

Commonly used options with the tar command are given below.

-c – Create an archive file.

-x – Extract an archive file.

-v – Show the process verbosely.

-t – View contents of archive file.

-z – Filter archives through gzip (.gz).

-j – Filter archives through bzip2 (.bz2).

-r – Append files (or directories) to existing archive.

## Utilities
* `ls -l | tr "[:lower:]" "[:upper:]"` - translate or convert characters
* `uniq -c -u` - report or omit repeated lines
* `split` -  split a file into pieces
* `wc -l` - word count 
* `head -n` - output the first part of files 
* `cut -d ':' -f 1 /etc/passwd` - cut pieces from lines in a file
* `diff -q [file1] [file2]` -compare files line by line (see also `comm`)
* `more`, `less` - for paging through text one screenful at a time. less is better ...
* `sort -n` - sort lines of text files
* `tail -f` - output the last part of file (with follow as it changes eg in case of logs)
* `kill -9 [sigkill] /-15 [sigterm]` - send a signal to a process
* `ps aux | grep [process name]` - a snapshot of the current processes
* `sudo fdisk -l` - list disk partition table


## System Administration
* sudo - elevate priviledges (normally only possible if part of `sudoers` group)
* `man woman` - system reference manuals (seel also `info`)
* `whatis [command]` - display one-line manual page descriptions
* [cmd] & - run in background
* >> - redirect append
* > - redirect overwrite
* 1>2&  - redirect stdout to stderr
* ctrl-z - used to suspend task
* hostname - show or set the system's host name (see also `sudo nano /etc/hosts`)
* date
* whoami - indeed, who are you?
* w - who is connected
* uptime - how long the system has been running
* free - amount of free and used memory in the system
* `uname -a` - print system/kernel information
 
```
cat /proc/cpuinfo 	Displays CPU information.
cat /proc/meminfo 	Displays Memory information.
```

## Cool Things

**Colour Picker** 
```
zenity --color-selection &
```

Create a Launcher as follows:
`sudo nano /usr/share/applications/colour-picker.desktop`

and paste & save:
```
[Desktop Entry]
Version=1.0
Name=Colour Picker
Type=Application
Comment=Zenity olour Picker
Terminal=false
Type=Application
Exec=zenity --color-selection &
Icon=/usr/share/icons/Humanity/categories/32/applications-graphics.svg
Categories=Application;
GenericName=Colour Picker
Keywords=colour;color;picker;
```

---
references : 
* https://ubuntu.com/tutorials/command-line-for-beginners#1-overview
* https://ryanstutorials.net/linuxtutorial/
* [sh & cli cheatsheet](https://www.lolicatgirls.com/g/software/CLI-and-SH-Commands.png)

---
[Readme](../README.md) | [Session 1](s01e01.md)

---
[MIT Licensed](LICENSE) and prepared for Varsity College by [Cyber-Mint (Pty) Ltd](https://www.cyber-mint.com)<br>
TeamFu &trade; is trademark of Cyber-Mint (Pty) Ltd.<br>
&copy; Copyright 2020, Cyber-Mint (Pty) Ltd.  
