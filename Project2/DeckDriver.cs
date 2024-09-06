////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Lab2
// File Name: Driver.cs
// Description: Lab1 
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 08/31/22
// Copyright: Christian Rock, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////



/// <summary>
/// Implementation of Suit and Face enums with Card Class objects and Deck objects. Creates a deck object and calls methods to perform actions on the deck object.
/// Deck constist of card objects.
/// 
/// </summary>

using Project2;
using System.Runtime.CompilerServices;


string repeat = "Y"; // Initial value to enter the loop

while (repeat == "Y" || repeat == "y")
{
    // Creates a new Deck object and shuffles it
    Deck deck = new Deck();
    deck.Shuffle();

    // Create a list of lists to hold the hands of the players
    List<List<Card>> playersHands = new List<List<Card>>();

    // Initialize hands for 5 players
    for (int i = 0; i < 5; i++)
    {
        playersHands.Add(new List<Card>());
    }

    // Deal 5 cards per player, but 1 card to each player in each round
    for (int cardNumber = 0; cardNumber < 5; cardNumber++) // Each player will receive 5 cards
    {
        for (int player = 0; player < 5; player++) // Loop over the 5 players
        {
            Card card = deck.DealACard();
            playersHands[player].Add(card); // Add the card to the player's hand
        }
    }

    // Sorting by suit and then by face in descending order
    foreach (var hand in playersHands)
    {
        hand.Sort((card1, card2) =>
        {
            // First compare by suit
            int suitComparison = card1.Suit.CompareTo(card2.Suit);

            // If suits are the same, then compare by face in descending order
            if (suitComparison == 0)
            {
                return card2.Face.CompareTo(card1.Face); // Reverse the comparison for descending order
            }

            return suitComparison;
        });
    }

    // Display all players' hands
    for (int player = 0; player < 5; player++)
    {
        Console.Write($"Player {player + 1}: ");
        for (int i = 0; i < playersHands[player].Count; i++)
        {
            Console.Write(playersHands[player][i]);

            if (i < playersHands[player].Count - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine(); // Move to the next line for the next player
    }

    // Input validation loop for repeating
    do
    {
        Console.WriteLine("Do you want to deal the cards again? (Y/N): ");
        repeat = Console.ReadLine().Trim();

        if (repeat.ToUpper() != "Y" && repeat.ToUpper() != "N")
        {
            Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
        }

    } while (repeat.ToUpper() != "Y" && repeat.ToUpper() != "N");

}
/*
Console.WriteLine("------------");
Console.WriteLine();

int UserInput;
Console.WriteLine("What size hand?");
UserInput = Convert.ToInt32(Console.ReadLine());
Hand PlayerHand = new Hand(UserInput);
Console.WriteLine(PlayerHand);

*/