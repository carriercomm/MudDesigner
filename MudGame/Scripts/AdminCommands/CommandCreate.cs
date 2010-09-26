﻿/// <summary>
/// The Create command is used to dynamically create content within the game world.
/// Content is created at run-time while the server/game is running and players are connected.
/// Newly created content will be available for players to use/traverse immediately after creation is completed.
/// Rooms that are created may be linked together using the LinkRoom command.
/// </summary>
public class CommandCreate : IGameCommand
{
    /// <summary>
    /// Used by the Command Engine to allow for overriding any other commands that contain the same name.
    /// TODO: Does Overriding Commands still work? This is part of some old code I wrote several years back and might be broke.
    /// </summary>
    public Boolean Override { get; set; }

    /// <summary>
    /// The name of the command.
    /// If Override is set to true, this command will override any other command that contains the same name.
    /// </summary>
    public String Name { get; set; }

    /// <summary>
    /// A collection of strings that contains helpfull information for this Command.
    /// When the user enteres 'Help Exit' the game will print the content of this collection.
    /// This is treated like a virtual book, each entry in the collection is printed as a new line.
    /// </summary>
    public List<String> Help { get; set; }

    //Private fields that are used during the creation of the environments.
    private Realm realm;
    private Zone zone;
    private Room room;

    /// <summary>
    /// Constructor for the class.
    /// </summary>
    public CommandCreate()
    {
        Help = new List<string>();
        Help.Add("Provides Admins the ability to create content dynamically within the game world.");
        Help.Add("Content is created at run-time while the server/game is running and players are connected.");
        Help.Add("Newly created content will be available for players to use/traverse immediately after creation is completed.");
        Help.Add("Rooms that are created may be linked together using the LinkRoom command.");
        Help.Add("You may create Realms by simply supplying a Realm name. If you wish to create a Zone, you must specify the Realm name followed by a '>' then the Zone name.");
        Help.Add("Example: 'Create MyRealm>MyZone'");
        Help.Add("The same concept is applied for creating Rooms.");
        Help.Add("Example: 'Create MyRealm>MyZone>MyRoom'");
        Help.Add("Creating just a single Realm is used by supplying only the Realm name.");
        Help.Add("Example: 'Create MyRealm'");
    }

    /// <summary>
    /// This will execute the command allowing Admins to generate environment objects dynamically on-the-fly.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="player"></param>
    public void Execute(String command, BaseCharacter player)
    {
        //Check if the player has the proper security role in order to create content for the game world.
        if ((player.Role != SecurityRoles.Admin) && (player.Role != SecurityRoles.GM))
        {
            Log.Write("Player " + player.Name + " attempted to invoke the Create command without having the correct security role assigned!");
            return;
        }

        //Split the supplied string up. It wil give us an array of strings with the supplied
        //object names if the admin has specified environment objects for creation.
        String[] env = command.Substring("Create ".Length).Split('>');

        //No objects specified, so the admin didn't use the command correctly.
        if (env.Length == 0)
        {
            player.Send("Invalid use of the 'Create' command. Please try 'Help Create' for help using the command.");
            return;
        }
        //Only 1 object name supplied, so we assume the admin wants a Realm created with the supplied name.
        else if (env.Length == 1)
        {
            //Check if the supplied name is a valid Realm name, and if the Realm can be created.
            //If it's valid, the Realm is instanced and stored in our private Field 'realm'
            Boolean validRealm = ValidateRealm(env[0], player);

            if (validRealm)
            {
                player.ActiveGame.World.AddRealm(realm);
                Log.Write(player.Name + " created a Realm called " + realm.Filename);
                player.Send(env[0] + " created.");
            }
            //Add the 'realm' Field that was instanced via ValidateRealm
            else
            {
                Log.Write("Failed to validate realm during dynamic Creation.");
                player.Send("Failed to create Realm! Please ensure a duplicate file name does not exist!");
                return;
            }
        }
        //Recieved two names, so we assume the admin wants a Zone created.
        //If the Realm that is supplied for this Zone does not create, we will create it.
        else if (env.Length == 2)
        {
            //Check if the Realm name supplied already exists. If it does, this will return false (Invalid name due to already existing)
            //If it returns true, then the Realm is valid, meaning non already exists, so we will create it.
            Boolean validRealm = ValidateRealm(env[0], player);

            //Add the Realm to the game world since this Zone is being created in a non-existant Realm.
            if (validRealm)
            {
                player.ActiveGame.World.AddRealm(realm);
                player.Send(env[0] + " created.");
                Log.Write(player.Name + " created a Realm called " + realm.Filename);
            }

            //Check if this Zone is a valid Zone. if it returns true, then the 'zone' field will reference the new Zone
            Boolean validZone = ValidateZone(env[0], env[1], player);

            if (validZone)
            {
                realm.AddZone(zone);
                player.Send(env[1] + " created.");
                Log.Write(player.Name + " created a Zone called " + zone.Filename);
            }
            else
            {
                Log.Write("Failed to validate Zone during dynamic creation.");
                player.Send("Failed to create Zone! Please ensure a duplicate filename does not exist!");
                return;
            }
        }
        else if (env.Length == 3)
        {
            //Check if the Realm name supplied already exists. If it does, this will return false (Invalid name due to already existing)
            //If it returns true, then the Realm is valid, meaning non already exists, so we will create it.
            Boolean validRealm = ValidateRealm(env[0], player);

            //Add the Realm to the game world since this Zone is being created in a non-existant Realm.
            if (validRealm)
            {
                player.ActiveGame.World.AddRealm(realm);
                player.Send(env[0] + " created.");
                Log.Write(player.Name + " created a Realm called " + realm.Filename);
            }

            Boolean validZone = ValidateZone(env[0], env[1], player);

            if (validZone)
            {
                realm.AddZone(zone);
                player.Send(env[1] + " created.");
                Log.Write(player.Name + " created a Zone called " + zone.Filename);
            }

            Boolean validRoom = ValidateRoom(env[0], env[1], env[2], player);

            if (validRoom)
            {
                zone.AddRoom(room);
                player.Send(env[2] + " created.");
                Log.Write(player.Name + " created a Room called " + room.Filename);
            }
            else
            {
                Log.Write("Failed to validate Room during dynamic creation.");
                player.Send("Failed to create Room! Please ensure a duplicate filename does not exist!");
                return;
            }
        }
    }

    /// <summary>
    /// Validates if the supplied Realm filename exists in the game world or not.
    /// Returns True if it does not exist; False if it does exist (As if it exists it's not a valid name to use during creation).
    /// </summary>
    /// <param name="name"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    private Boolean ValidateRealm(String name, BaseCharacter player)
    {
        if (player.ActiveGame.World.GetRealm(name + ".Realm") != null)
        {
            realm = player.ActiveGame.World.GetRealm(name + ".Realm");
            return false;
        }

        realm = new Realm(player.ActiveGame);
        realm.Name = name;

        return true;
    }

    /// <summary>
    /// Validates if the supplied Zone filename exists in the game world or not.
    /// Returns True if it does not exist; False if it does exist (As if it exists it's not a valid name to use during creation).
    /// If the Zones owning Realm does not exist, it returns false and fails.
    /// </summary>
    /// <param name="realmName"></param>
    /// <param name="zoneName"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    private Boolean ValidateZone(String realmName, String zoneName, BaseCharacter player)
    {
        if (realm == null)
        {
            player.Send("Unable to validate Zone due to invalid Realm.");
            return false;
        }

        if (realm.GetZone(zoneName + ".Zone").Count != 0)
        {
            zone = realm.GetZone(zoneName + ".Zone")[0];
            return false;
        }

        zone = new Zone(player.ActiveGame);
        zone.Name = zoneName;

        return true;
    }

    /// <summary>
    /// Validates if the supplied Room filename exists in the game world or not.
    /// Returns True if it does not exist; False if it does exist (As if it exists it's not a valid name to use during creation).
    /// If the Rooms owning Zone or Realm does not exist, it returns false and fails.
    /// </summary>
    /// <param name="realmName"></param>
    /// <param name="zoneName"></param>
    /// <param name="roomName"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    private Boolean ValidateRoom(String realmName, String zoneName, String roomName, BaseCharacter player)
    {
        if ((realm == null) || (zone == null))
        {
            player.Send("Unable to validate Room due to invalid Realm or Zone.");
            return false;
        }

        if (zone.GetRoom(roomName + ".Room").Count != 0)
        {
            room = zone.GetRoom(roomName + ".Room")[0];
            return false;
        }

        room = new Room(player.ActiveGame);
        room.Name = roomName;

        return true;
    }
}