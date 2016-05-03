# WUManager

This software helps the System Administrators patching all Windows Servers that have Wsus approved pending
updates.
You can start the process, follow the instalation and reboot the server using the same Dashboard.
Is important to metion that WuManager only makes easier the update installation process, even so, you must
have in your network the Wsus Server properly configured.

# Requisites

- All the servers must be members of Active Directory domain.(Only supports integrated authetication)
- .Net 3.5 installed
- Admin Share working (\\server\admin$)
- RPC ports opened (it uses Psexec)

# Features

![Img1](https://github.com/fzavalloni/WUManager/blob/master/img/wumanager1.png)

- Ping remote servers
- Check if any server has pending boot
- Check how many updates the server has to be installed
- Check last boot, it helps to check if the machine rebooted and is UP
- Start the patching process and reporting the percent of the process





