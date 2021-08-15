<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Number Guessing Game</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
</head>
<!-- this file will generate a form for the number gussing game player to enter his name -->
<!-- after the user's name is submitted, the user will be directed to the other page for number guessing -->
<!-- all the php codes are in the other file: number_guessing_game_2.php  -->
<body>

    <div class="container bg-light" style="border:5px solid grey; border-radius: 10px;">
        <h1>Number Guessing Game <img src="https://i.pinimg.com/originals/42/2b/4d/422b4df8da712e33f92ad4f76005c6ab.jpg" width="120" height="120"></h1><br>

        <form action="number_guessing_game_2.php" method="post" id="nameInput">
            <div class="form-group">
                <label for="name">Please enter your name:</label>
                <input type="text" class="form-control" id="name" name="name">
            </div>
            <button type="submit" class="btn btn-primary" name="submit" value="submitted">Submit</button><br><br>
        </form>
        
    </div>
    
</body>
</html>


