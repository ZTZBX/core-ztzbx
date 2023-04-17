# core_ztzbx for CitizenFX

### **Requirements**
- [fivem-mysql](https://github.com/ZTZBX/fivem-mysql)

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\core_ztzbx dist
```

Afterwards, you can use `ensure core_ztzbx` in your server.cfg or server console to start the resource.

### **Guide**
---

In your script you need to add the dependency in the fxmanifest.lua

```
dependencies {
    "core-ztzbx"
}
```

### **Client Side**

**Send Message on concret User Chat**

```cs
Exports["core-ztzbx"].sendOnUserChat("Your chat message");
```

**Get The Player Token**

This will be fundamental to make interactions with the database

```cs
string token = Exports["core-ztzbx"].playerToken();
```

### **Server Side**

**Send Message on concret User Chat**

```cs
int source_id = Player.id;
Exports["core-ztzbx"].sendOnUserChat(source_id, "Your chat message");
```

**Login**
This will be use to login a user in the server

```cs
// this is the player id
int source_id = Player.id;

string username = "user";
string password = "pas1234";

List<string> user_pass = new List<string> {};

// first the username and after the password
user_pass.Add(username);
user_pass.Add(password);

Exports["core-ztzbx"].login(source_id, user_pass);
```

**Register**
This will be use to register a user in the server

```cs
// this is the player id
int source_id = Player.id;

string username = "user";
string password = "pas1234";

List<string> user_pass = new List<string> {};

// first the username and after the password
user_pass.Add(username);
user_pass.Add(password);

Exports["core-ztzbx"].register(source_id, user_pass);
```

**Get The Player Token**

```cs
// this is the player id
int source_id = Player.id;

// if token return "" thats mean the user isn't logged.
string token = Exports["core-ztzbx"].playerToken(source_id);
```
