<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>PHP Number Guessing Game</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

</head>

<body>

    <div class="container bg-light" style="border:5px solid grey; border-radius: 10px;">

        <?php
        session_start();
        //create $emoji array for images for future use
        $emoji = [
            "happyFace" => '<img src="https://i.pinimg.com/originals/1d/3b/8e/1d3b8e3c20793a25a32de080956cb41a.png" width="130" height="120">',
            "sadFace" => '<img src="https://i.pinimg.com/originals/32/3e/3b/323e3b47f07fa1fb0a4b2ecb03b2c965.png" width="30" height="30"> ',
            "proudFace" => '<img src="https://i.pinimg.com/736x/44/ef/cd/44efcd7d646e517642baeb26bac84c32--happy-faces-emojis.jpg" width="120" height="120">',
            "thinkingFace" => '<img src="http://www.i2symbol.com/pictures/emojis/e/e/7/b/ee7b4fb9880ef3c8ee19626cdc14bf5c_384.png" width="120" height="120">',
            "cuteFace" => '<img src="https://i.pinimg.com/originals/42/2b/4d/422b4df8da712e33f92ad4f76005c6ab.jpg" width="120" height="120">',
            "frustratedFace" => '<img src="https://previews.123rf.com/images/yayayoy/yayayoy1512/yayayoy151200004/50083911-crying-face-emoticon-with-tear-Stock-Photo.jpg" width="120" height="120">',
            "goodjobFace" => '<img src="https://i.pinimg.com/736x/ac/1d/00/ac1d00fe479c04c579332149ac61b865--smiley-quotes-emotion-faces.jpg" width="120" height="120">'
        ];

        //if guessNumber is submitted, start to compare the guessNumber with the randomNumber
        if (isset($_POST['guessNumber']) && isset($_POST['guessSubmitted'])) {
            //if guessNumber equals to randomNumber, output a happy face to the top of the page   
            if ($_POST['guessNumber'] == $_SESSION['randomNumber']) {
                print "<h1>Number Guessing Game " . $emoji['happyFace'] . "</h1>";
            } elseif (!isset($_SESSION['counter']) || isset($_SESSION['counter'])) {
                //if guessNumber does not equal to randomNumber and the guess count is less than 4, output a thinking face emoji to the top of the page
                //if guessNumber does not equal to randomNumber and the guess count is greater than 4, output a frustratedface emoji to the top of the page
                //if guessNumber has not been submitted, output a cute face emoji to the top of the page
                if (!isset($_SESSION['counter']) || $_SESSION['counter'] < 4) {
                    print "<h1>Number Guessing Game " . $emoji['thinkingFace'] . "</h1>";
                } elseif ($_SESSION['counter'] = 4) {
                    print "<h1>Number Guessing Game " . $emoji['frustratedFace'] . "</h1>";
                }
            }
        } else {
            print "<h1>Number Guessing Game " . $emoji['cuteFace'] . "</h1>";
        }

        //output welcome greeting with the user's name after the user submitted his name
        if (isset($_POST['name'])) {
            $_SESSION['name'] = $_POST['name'];
        }
        print '<h2>Welcome ' . $_SESSION['name'] . '</h2><br>';

        //generate a random number and save it to session file for future comparison
        //use the function printGuessForm() to display guess form for user input
        //instruct user that he has 5 chances to guess
        if (!isset($_POST['guessNumber']) && !isset($_POST['guessSubmitted'])) {
            $random = rand(1, 20);
            $_SESSION['randomNumber'] = $random;

            printGuessForm();
            print "<b>You have 5 chances to guess</h3><b>";
        }

        //after user inputs and submits the guessNumber, start comparison
        if (isset($_POST['guessNumber']) && isset($_POST['guessSubmitted'])) {
            //use if - else statement to judge if the guessNumber is between 1 to 20
            //if yes, start comparison; if no, output message that the guessNumber is not between 1 to 20
            if ($_POST['guessNumber'] <= 20 && $_POST['guessNumber'] >= 1) {
                //if the guessNumber equals to the randomNumber, output message to congratulate and output "You win!!!" for 10 times
                //a smiling face emoji is added to each line of "You win!!!" message using json_decode()
                //use the function restarGame() to display a restart button to give user the chance to restart game after the user wins
                if ($_POST['guessNumber'] == $_SESSION['randomNumber']) {
                    $msg = '<h4 style="color:green;">the number ' . $_POST['guessNumber'] . " is correct! " . $emoji['goodjobFace'] . "</h4>";
                    print $msg;
                    for ($i = 0; $i < 10; $i++) {
                        print '<h4 style="color:green;">You win!!!' . json_decode('"\uD83D\uDE00"') . '</h4>';
                    }
                    print "<br>";
                    restartGame();
                    exit();
                }
                //if the guessNumber is greater than the randomNumber, display the form again, output message saying the guessNumber is too big
                //add a sad face emoji after the message
                elseif ($_POST['guessNumber'] > $_SESSION['randomNumber']) {

                    printGuessForm();
                    $msg = '<h4 style="color:red;">the number ' . $_POST['guessNumber'] . " is too big !
                                Please try again ! " . $emoji['sadFace'] . "</h4>";
                    print $msg;
                }
                //if the guessNumber is less than the randomNumber, display the form again, output message saying the guessNumber is too small
                //add a sad face emoji after the message
                elseif ($_POST['guessNumber'] < $_SESSION['randomNumber']) {

                    printGuessForm();
                    $msg = '<h4 style="color:red;">the number ' . $_POST['guessNumber'] . " is too small !
                                Please try again ! " . $emoji['sadFace'] . "</h4>";
                    print $msg;
                }
                //if submitted guessNumber is not between 1 and 20, output message that the guessNumber is not between 1 to 20
                //display the form again to give user another chance to guess
            } else {
                printGuessForm();
                print "<h4 style='color:red;'>The number you entered is not between 1 and 20. Please re-enter.</h4>";
            }
        }
        //the following if-else statement is to output message informing the user how much chances left as well as the record of guessed numbers
        //also use gameOver() and restartGame() to exit the game and display a restart button when the user failed after 5 guesses
        if (isset($_POST['guessNumber']) && isset($_POST['guessSubmitted'])) {

            if (isset($_SESSION['counter'])) {
                $_SESSION['counter'] = $_SESSION['counter'] + 1;
                if ($_SESSION['counter'] == 2) {
                    $_SESSION['guessNumber2'] = $_POST['guessNumber'];
                    print "<b>You have 3 chances left !<b><br><br>";
                    print "<b>Number Guessed: " . $_SESSION['guessNumber1']
                        . ", " . $_SESSION['guessNumber2'] . "<b>";
                } elseif ($_SESSION['counter'] == 3) {
                    $_SESSION['guessNumber3'] = $_POST['guessNumber'];
                    print "<b>You have 2 chances left !<b><br><br>";
                    print "<b>Number Guessed: " . $_SESSION['guessNumber1']
                        . ", " . $_SESSION['guessNumber2']
                        . ", " . $_SESSION['guessNumber3'] . "<b>";
                } elseif ($_SESSION['counter'] == 4) {
                    $_SESSION['guessNumber4'] = $_POST['guessNumber'];
                    print "<b>You have the last chance left !<b><br><br>";
                    print "<b>Number Guessed: " . $_SESSION['guessNumber1']
                        . ", " . $_SESSION['guessNumber2']
                        . ", " . $_SESSION['guessNumber3']
                        . ", " . $_SESSION['guessNumber4'] . "<b>";
                } elseif ($_SESSION['counter'] == 5) {
                    $_SESSION['guessNumber5'] = $_POST['guessNumber'];
                    gameOver();
                    restartGame();
                    exit();
                }
            } else {
                $_SESSION['counter'] = 1;
                print "<b>You have 4 chances left !</b><br><br>";
                $_SESSION['guessNumber1'] = $_POST['guessNumber'];
                $_SESSION['guessNumber2'] = " ";
                $_SESSION['guessNumber3'] = " ";
                $_SESSION['guessNumber4'] = " ";
                $_SESSION['guessNumber5'] = " ";
                print "<b>Number Guessed: " . $_SESSION['guessNumber1'] . "<b>";
            }
        }

        //the Guess Form is displayed repeatedly in this game, so printGuessForm() is created for it and is called when needed
        function printGuessForm()
        {
            print '<form action="number_guessing_game_2.php" method="post" id="guessInput">
                       <div class="form-group"><label>Guess a number between 1 to 20: </label>
                       <input type="number" id="guess" name="guessNumber" class="form-control"></div>
                       <button type="submit" class="btn btn-primary" name="guessSubmitted" value="submitted">Guess</button><br><br>
                       </form>';
        }

        //gameOver() will be used to exit the game when the user failed after 5 guess
        //Guess Form will be hidden to revoke guess chance, all 5 tried numbers will be displayed
        //the randomNumber, i.e. the answer, will be displayed to the user in consideration of  user experience
        function gameOver()
        {
            echo "<script>$('#guessInput').hide();</script>";
            print "<h4 style='color:red;'>Sorry, you've passed the maximum times.</h4>";
            print "<b>Number Guessed: " . $_SESSION['guessNumber1'] . " "
                . ", " . $_SESSION['guessNumber2'] . " "
                . ", " . $_SESSION['guessNumber3'] . " "
                . ", " . $_SESSION['guessNumber4'] . " "
                . ", " . $_SESSION['guessNumber5'] . " </b><br><br>";
            print "<b>the random number was " . $_SESSION['randomNumber'] . "</b><br><br>";
        }

        //restartGame() will be called either after the user wins or the user fails after 5 tries
        function restartGame()
        {
            session_destroy();
            print  '<button type="button" class="btn btn-primary">
                <a href="number_guessing_game_1.php" style="color:white">Restart</a></button>';
        }

        ?>

    </div>



</body>

</html>