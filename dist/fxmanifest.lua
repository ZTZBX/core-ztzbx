fx_version 'bodacious'
game 'gta5'

file 'Client/bin/Release/**/publish/*.dll'

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx core'

dependencies {
    "fivem-mysql"
}

server_exports {"player"}
client_exports {"player"}


