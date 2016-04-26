<?php function isPalindrome($value) {
    $revStr = strrev($value);
    if ($revStr == $value) {
        return "$value is a palindrome!";
    } else {
        return "$value is not a palindrome!";
    }
}
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Modifier</title>
    </head>
    <body>
        <form method="get" action="">
            <input type="text" name="str" />
            <input type="radio" name="mod" value="palindrome" />Check Palindrome
            <input type="radio" name="mod" value="reverse" />Reverse String
            <input type="radio" name="mod" value="split" />Split
            <input type="radio" name="mod" value="hash" />Hash String
            <input type="radio" name="mod" value="shuffle" />Shuffle String
            <input type="submit" name="submit" />
        </form>
        <?php
        if (isset($_GET['str']) && isset($_GET['mod'])) {
            $str = $_GET['str'];
            $mod = $_GET['mod'];
            
            switch ($mod) {
                case 'palindrome':
                    echo isPalindrome($str);
                    break;
                case 'reverse':
                    echo strrev($str);
                    break;
                case 'split':
                    $arr = str_split($str);
                    echo implode(' ', $arr);
                    break;
                case 'hash':
                    echo crypt($str);
                    break;
                case 'shuffle':
                    echo str_shuffle($str);
                    break;
            }
        }
        ?>
    </body>
</html>