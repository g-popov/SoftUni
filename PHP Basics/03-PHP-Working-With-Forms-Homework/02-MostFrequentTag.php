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
        <?php 
        if (isset($_GET["tags"])) {
            $tagsStr = htmlentities($_GET["tags"]);
            $tags = explode(", ", $tagsStr);
            $tagsFrequency = array();
            for ($i=0; $i < count($tags); $i++) {
                $currentTag = $tags[$i]; 
                if (!isset($tagsFrequency[$currentTag])) {
                    $tagsFrequency[$currentTag] = 1;
                } else {
                    $tagsFrequency[$currentTag] += 1;
                }
            }
            arsort($tagsFrequency);
            $maxTimes = 0;
            foreach ($tagsFrequency as $key => $value) {
                echo "$key : $value times<br>";
                if ($value > $maxTimes) {
                    $maxTimes = $value;
                    $maxTag = $key;
                }
            }
            echo "<p>Most Frequent Tag is: ${maxTag}</p>";
        }
        ?>
    </body>
</html>

