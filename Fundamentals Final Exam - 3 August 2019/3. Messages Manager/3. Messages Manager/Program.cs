using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Messages_Manager
{
    class Program
    {
        static void Main()
        {
            int maxMessages = int.Parse(Console.ReadLine());
            var Users = new Dictionary<string, UserInfo>();
            List<string> allUsernames = new List<string>();

            var usersAndReceived = new Dictionary<string, int>();
            while (true)
            {
                string[] command = Console.ReadLine().Split('=').ToArray();

                if (command[0] == "Statistics")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    string username = command[1];
                    int sent = int.Parse(command[2]);
                    int received = int.Parse(command[3]);
                    int total = sent + received;

                    if (Users.ContainsKey(username) == false)
                    {
                        allUsernames.Add(username);
                        usersAndReceived[username] = received;

                        Users[username] = new UserInfo(sent, received, total)
                        {
                            Sent = sent,
                            Received = received,
                            Total = total
                        };
                    }                    
                }
                else if (command[0] == "Message")
                {
                    string sender = command[1];
                    string receiver = command[2];

                    if (Users.ContainsKey(sender) && Users.ContainsKey(receiver))
                    {
                        Users[sender].Sent += 1;
                        Users[sender].Total += 1;
                        Users[receiver].Received += 1;
                        Users[receiver].Total += 1;
                        usersAndReceived[receiver] += 1;

                        if (Users[sender].Total >= maxMessages)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            Users.Remove(sender);
                            allUsernames.Remove(sender);
                            usersAndReceived.Remove(sender);
                        }
                        if (Users[receiver].Total >= maxMessages)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            Users.Remove(receiver);
                            allUsernames.Remove(receiver);
                            usersAndReceived.Remove(receiver);
                        }
                    }
                }
                else if (command[0] == "Empty")
                {
                    string username = command[1];
                    if (username == "All")
                    {
                        foreach (var user in allUsernames)
                        {
                            Users.Remove(user);
                            usersAndReceived.Remove(user);
                        }
                    }
                    else if (Users.ContainsKey(username))
                    {
                        Users.Remove(username);
                        usersAndReceived.Remove(username);
                    }
                }
            }

            Console.WriteLine($"Users count: {Users.Count}");

            usersAndReceived = usersAndReceived.
                OrderByDescending(x => x.Value).
                ThenBy(x => x.Key).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in usersAndReceived)
            {
                Console.WriteLine($"{user.Key} - {Users[user.Key].Total}");
            }
        }

        class UserInfo
        {
            public UserInfo(int sent, int received, int total)
            {
                Sent = sent;
                Received = received;
                Total = total;
            }
            public int Sent { get; set; }
            public int Received { get; set; }
            public int Total { get; set; }

        }
    }
}
