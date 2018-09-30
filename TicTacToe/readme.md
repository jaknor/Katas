Tic Tac Toe kata
Rules:
- Players alternate placing X’s and O’s on a 3x3 board, with X starting first
- Players cannot play on already taken positions
- A player wins when it has three symbols in a row, either
- Horizontally
- Vertically
- Diagonally
- If all squares are taken and there are not three symbols in a row, then the
outcome is a draw

Caveat: try to make invalid state unrepresentable

Object Calisthenics rules

➔ Only one level of indentation per method
➔ Don’t use the ELSE keyword
➔ Wrap all primitives and strings
➔ First class collections (wrap all collections)
➔ Only one dot per line dog.Body.Tail.Wag() => dog.ExpressHappiness()
➔ No abbreviations
➔ Keep all entities small => [10 files per package, 50 lines per class, 5 lines per method, 2 arguments per method]
➔ No classes with more than two instance variables
➔ No public getters/setters/properties