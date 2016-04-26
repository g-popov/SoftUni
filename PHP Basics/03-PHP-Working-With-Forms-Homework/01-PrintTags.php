<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Print Tags</title>
    </head>
    <body>
        <form method="get">
            <p>Enter Tags:</p>
            <input type="text" name="tags" />
            <input type="submit" />
        </form>
    </body>
</html>

<?php 
if (isset($_GET["tags"])) {
	$tagsStr = htmlentities($_GET["tags"]);
    $tags = explode(", ", $tagsStr);
    for ($i=0; $i < count($tags); $i++) { 
        echo "$i : $tags[$i]<br>";
    }
}
?>
