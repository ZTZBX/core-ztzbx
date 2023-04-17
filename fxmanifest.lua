fx_version 'bodacious'
game 'gta5'

file 'Client/*.dll'

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx core'

dependencies {
    "fivem-mysql",
    "language"
}

server_exports {"login", "register", "playerToken"}
client_exports {"playerToken", "sendOnUserChat", "sendOnUserChat"}
