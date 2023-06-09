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

server_exports {
    "login",
    "register",
    "playerToken",
    "playerAdmin",
    "getPlayersUsernames",
    "getPlayerHandleFromUsername",
    "getPlayerNetworkIdFromUsername",
    "freezePlayerSwitch"
}

client_exports {
    "playerToken",
    "playerUsername",
    "sendOnUserChat",
    "sendOnUserChat" 
}
