using System;
using Firebase.Database;
using UnityEngine;

public static class FirebaseDbUtils
{
    private static string PLAYERS_NODE = "players";
    private static string PLAYER_1 = "player1";
    private static string PLAYER_2 = "player2";

    private static string registeredPlayer = null;
    private static PlayerDb player;
    private static PlayerDb opponent;
    private static int progressDbTracked = 0;

    private static DatabaseReference dbReference
    {
        get { return FirebaseDatabase.DefaultInstance.RootReference; }
    }

    private static DatabaseReference playersReference
    {
        get { return dbReference.Child(PLAYERS_NODE); }
    }

    public static void onBoardRecognized()
    {
        registerPlayer();
        subscribeToUpdateProgress();
    }

    public static int getProgress()
    {
        if (player != null && opponent != null)
        {
            return player.dmgMade - opponent.dmgMade;
        }

        return 0;
    }

    public static void attackBase(int dmgMade)
    {
        player.dmgMade += dmgMade;
        updatePlayer();
    }

    private static void subscribeToUpdateProgress()
    {
        // subscribe to event changes
        playersReference.ValueChanged += OnPlayersNodeChanged;
    }

    private static void OnPlayersNodeChanged(object Sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError("Error listening to players changes");
            return;
        }

        if (registeredPlayer != null)
        {
            String playerToFetch = registeredPlayer.Equals(PLAYER_1) ? PLAYER_2 : PLAYER_1;
            PlayerDb otherPlayer = args.Snapshot.Child(playerToFetch).Value as PlayerDb;
            if (otherPlayer != null)
            {
                opponent = otherPlayer;
            }
        }
    }

    private static void registerPlayer()
    {
        playersReference.Child(PLAYER_1).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("PLAYER 1 registering failed");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snap = task.Result;
                if (snap != null)
                {
                    registerAsSecondPlayer();
                }
                else
                {
                    pushPlayer(PLAYER_1);
                }
            }
        });
    }

    private static void registerAsSecondPlayer()
    {
        playersReference.Child(PLAYER_2).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("PLAYER 2 registering failed");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snap = task.Result;
                if (snap != null)
                {
                    resetPlayersNode();
                }
                else
                {
                    pushPlayer(PLAYER_2);
                }
            }
        });
    }

    private static void pushPlayer(string playerIdentifier)
    {
        player = new PlayerDb();
        registeredPlayer = playerIdentifier;
        playersReference.Child(playerIdentifier).SetValueAsync(player);
    }

    private static void updatePlayer()
    {
        if (registeredPlayer != null)
        {
            playersReference.Child(registeredPlayer).SetValueAsync(player);
        }
        else
        {
            Debug.LogError("Trying to update player when player identifier being null");
        }
    }

    private static void resetPlayersNode()
    {
        playersReference.SetValueAsync(null);
    }
}