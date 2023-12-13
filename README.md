# Football World Cup Score Board

## How-to run
In root folder just open terminal copy-paste code lower and press enter:
```
dotnet run --project  .\src\FootballWorldCupScoreBoard.Client
```

Example output:
```
Started match: Spain 0 - Italy 0
Spain 0 - Italy 1
Spain 1 - Italy 1
Spain 2 - Italy 1
Finished match: Spain 2 - Italy 1

Started match: Germany 0 - England 0
Finished match: Germany 0 - England 0

0. Germany 0 - England 0
1. Spain 2 - Italy 1
```

## Instructions
You are working on a sports data company, and we would like you to develop a new Live
Football World Cup Score Board that shows matches and scores.
The board supports the following operations:
1. Start a game. When a game starts, it should capture (being initial score 0 – 0):
   1. Home team
   2. Away team
2. Finish game. It will remove a match from the scoreboard.
3. Update score. Receiving the pair score; home team score and away team score updates a game score.
4. Get a summary of games by total score. Those games with the same total score will be returned ordered by the most recently added to our system. 

As an example, being the current data in the system:
```
- Mexico - Canada: 0 - 5
- Spain - Brazil: 10 – 2
- Germany - France: 2 – 2
- Uruguay - Italy: 6 – 6
- Argentina - Australia: 3 - 1
```
   

The summary would provide with the following information:
```
1. Uruguay 6 - Italy 6
2. Spain 10 - Brazil 2
3. Mexico 0 - Canada 5
4. Argentina 3 - Australia 1
5. Germany 2 - France
```